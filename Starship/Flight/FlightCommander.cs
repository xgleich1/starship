using Starship.Control;
using Starship.Flight.Command;
using Starship.Flight.Command.Attitude;
using Starship.Flight.Command.Throttle.Main;
using Starship.Flight.Command.Throttle.Rcs;
using Starship.Sensor;

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
            ISensorSuite sensorSuite,
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

            var commandSuite = new CommandSuite(
                new TopLeftRcsEngineThrottleCommand(0.0f),
                new TopRightRcsEngineThrottleCommand(0.0f),
                new BottomLeftRcsEngineThrottleCommand(0.0f),
                new BottomRightRcsEngineThrottleCommand(0.0f),
                new TopMainEngineThrottleCommand(0.0f),
                new BottomLeftMainEngineThrottleCommand(0.0f),
                new BottomRightMainEngineThrottleCommand(0.0f),
                new MainEngineAttitudeYawCommand(0.0f),
                new MainEngineAttitudeRollCommand(0.0f),
                new MainEngineAttitudePitchCommand(0.0f));

            _flightDependencies.TelemetryEmitter.EmitTelemetry(commandSuite);

            controlSuite.ExertControl(commandSuite);
        }
    }
}