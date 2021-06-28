using Starship.Control;
using Starship.Flight.Command;
using Starship.Sensor;
using static Starship.Flight.Command.AttitudeCommand;
using static Starship.Flight.Command.ThrottleCommand;

namespace Starship.Flight
{
    // Currently under development
    public sealed class FlightCommander
    {
        private readonly FlightDependencies _flightDependencies;

        private bool _started;


        public FlightCommander(FlightDependencies flightDependencies)
        {
            _flightDependencies = flightDependencies;
        }

        public void CommandFlight(
            SensorSuite sensorSuite,
            IControlSuite controlSuite)
        {
            // Do certain things only once.
            // This will become a state machine
            if (!_started)
            {
                _flightDependencies.MissionClock.StartWithZeroSeconds();

                _started = true;
            }

            _flightDependencies.TelemetryEmitter.EmitTelemetry(sensorSuite);

            var flightCommand = new FlightCommand(
                new TopLeftRcsEngineThrottle(0.0f),
                new TopRightRcsEngineThrottle(0.0f),
                new BottomLeftRcsEngineThrottle(0.0f),
                new BottomRightRcsEngineThrottle(0.0f),
                new TopMainEngineThrottle(0.0f),
                new BottomLeftMainEngineThrottle(0.0f),
                new BottomRightMainEngineThrottle(0.0f),
                new MainEngineAttitudeYaw(0.0f),
                new MainEngineAttitudeRoll(0.0f),
                new MainEngineAttitudePitch(0.0f));

            // Emit Flight Command Telemetry

            controlSuite.ExertControl(flightCommand);
        }
    }
}