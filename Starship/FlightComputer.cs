using Starship.Control;
using Starship.Control.MainEnginesAttitude;
using Starship.Control.MainEnginesThrottle;
using Starship.Control.RcsEnginesThrottle;
using Starship.Flight;
using Starship.Sensor;
using Starship.Sensor.Attitude;
using Starship.Sensor.Position;
using static Vessel.Situations;

namespace Starship
{
    // Currently under development
    public sealed class FlightComputer : PartModule
    {
        private readonly FlightCommander _flightCommander =
            new FlightCommander(new FlightDependencies());


        public override void OnStart(StartState state)
        {
            if (vessel == null)
            {
                return;
            }

            vessel.OnFlyByWire += flightControlState =>
            {
                if (vessel.situation == PRELAUNCH)
                {
                    return;
                }

                // What sensors can I sense in a real rocket?
                // Position Sensor?
                // Acceleration Sensor?
                // Speed Sensor?
                // Throttle Sensor?
                // Center Of MassSensor?
                // Center Of Lift Sensor?
                // Thrust Sensor?
                // Gimbal Sensor?
                // Mass Sensor?
                // Thrust To Weight?
                var sensorSuite = new SensorSuite(
                    new YawSensor(vessel),
                    new RollSensor(vessel),
                    new PitchSensor(vessel),
                    new HeightSensor(vessel));

                // What can I control in a real rocket?
                var controlSuite = new ControlSuite(
                    new RcsEnginesThrottleControl(vessel),
                    new MainEnginesThrottleControl(vessel),
                    new MainEnginesAttitudeControl(vessel));

                _flightCommander
                    .CommandFlight(sensorSuite, controlSuite);
            };
        }
    }
}