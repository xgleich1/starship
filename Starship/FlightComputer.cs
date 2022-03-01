using Starship.Control;
using Starship.Control.Actuation.Engine;
using Starship.Control.Actuation.Flap;
using Starship.Control.Throttle.Main;
using Starship.Flight;
using Starship.Mission;
using Starship.Sensor;
using Starship.Sensor.Attitude;
using Starship.Telemetry;
using Starship.Utility.Timing;
using static UnityEngine.Debug;
using static Vessel.Situations;

namespace Starship
{
    // Currently under development
    public sealed class FlightComputer : PartModule
    {
        private readonly AttitudeSensor _attitudeSensor = new AttitudeSensor();

        private readonly MainEnginesThrottleControl _mainEnginesThrottleControl =
            new MainEnginesThrottleControl();
        private readonly MainEnginesGimbalControl _mainEnginesGimbalControl =
            new MainEnginesGimbalControl();
        private readonly FlapsActuationControl _flapsActuationControl =
            new FlapsActuationControl();

        private readonly FlightCommander _flightCommander = BuildFlightCommander();


        public override void OnStart(StartState state)
        {
            if (vessel == null)
            {
                return;
            }

            vessel.OnFlyByWire += delegate
            {
                if (vessel.situation == PRELAUNCH)
                {
                    return;
                }

                // What can I sense in a real rocket?
                // Height?
                // Position?
                // Acceleration?
                // Speed?
                // Center Of Mass?
                // Center Of Lift?
                // Thrust?
                // Mass?
                // Thrust To Weight?
                _attitudeSensor.Update(vessel);

                var sensorSuite = new SensorSuite(
                    _attitudeSensor);

                // What can I control in a real rocket?
                // Reaction Control System?
                _mainEnginesThrottleControl.Bind(vessel);
                _mainEnginesGimbalControl.Bind(vessel);
                _flapsActuationControl.Bind(vessel);

                var controlSuite = new ControlSuite(
                    _mainEnginesThrottleControl,
                    _mainEnginesGimbalControl,
                    _flapsActuationControl);

                _flightCommander
                    .CommandFlight(sensorSuite, controlSuite);
            };
        }

        private static FlightCommander BuildFlightCommander()
        {
            var missionTimer = new MissionTimer(
                new Stopwatch());

            var telemetryEmitter = new TelemetryEmitter(
                unityLogger,
                missionTimer);

            return new FlightCommander(
                missionTimer,
                telemetryEmitter);
        }
    }
}