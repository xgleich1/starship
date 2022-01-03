using Starship.Control;
using Starship.Control.Actuation.Engine;
using Starship.Control.Actuation.Flap;
using Starship.Control.Throttle.Main;
using Starship.Control.Throttle.Rcs;
using Starship.Flight;
using Starship.Mission;
using Starship.Sensor;
using Starship.Sensor.Attitude.Pitch;
using Starship.Sensor.Attitude.Roll;
using Starship.Sensor.Attitude.Yaw;
using Starship.Sensor.Position.Height;
using Starship.Telemetry;
using Starship.Utility.Timing;
using static UnityEngine.Debug;
using static Vessel.Situations;

namespace Starship
{
    // Currently under development
    public sealed class FlightComputer : PartModule
    {
        private readonly YawSensor _yawSensor = new YawSensor();
        private readonly RollSensor _rollSensor = new RollSensor();
        private readonly PitchSensor _pitchSensor = new PitchSensor();
        private readonly HeightSensor _heightSensor = new HeightSensor();

        private readonly RcsEnginesThrottleControl _rcsEnginesThrottleControl =
            new RcsEnginesThrottleControl();
        private readonly MainEnginesThrottleControl _mainEnginesThrottleControl =
            new MainEnginesThrottleControl();
        private readonly MainEnginesGimbalControl _mainEnginesGimbalControl =
            new MainEnginesGimbalControl();
        private readonly FlapsActuationControl _flapsActuationControl =
            new FlapsActuationControl();

        private readonly FlightCommander _flightCommander = BuildFlightCommander();

        private ScreenMessage _screenMessage;


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
                // Position?
                // Acceleration?
                // Speed?
                // Center Of Mass?
                // Center Of Lift?
                // Thrust?
                // Mass?
                // Thrust To Weight?
                _yawSensor.Update(vessel);
                _rollSensor.Update(vessel);
                _pitchSensor.Update(vessel);
                _heightSensor.Update(vessel);

                var sensorSuite = new SensorSuite(
                    _yawSensor,
                    _rollSensor,
                    _pitchSensor,
                    _heightSensor);

                // What can I control in a real rocket?
                _rcsEnginesThrottleControl.Bind(vessel);
                _mainEnginesThrottleControl.Bind(vessel);
                _mainEnginesGimbalControl.Bind(vessel);
                _flapsActuationControl.Bind(vessel);

                var controlSuite = new ControlSuite(
                    _rcsEnginesThrottleControl,
                    _mainEnginesThrottleControl,
                    _mainEnginesGimbalControl,
                    _flapsActuationControl);

                _flightCommander
                    .CommandFlight(sensorSuite, controlSuite);


                ScreenMessages.RemoveMessage(_screenMessage);
                _screenMessage = ScreenMessages.PostScreenMessage(
                    $"pitch angle:{_pitchSensor.PitchAngleInDegrees}," +
                    $"\nyaw angle:{_yawSensor.YawAngleInDegrees}," +
                    $"\nroll angle:{_rollSensor.RollAngleInDegrees},",
                    5, ScreenMessageStyle.UPPER_LEFT);
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