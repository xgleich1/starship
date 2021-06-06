using Starship.Sensors;

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

        public FlightCommand CommandFlight(SensorSuite sensorSuite)
        {
            // Do certain things only once.
            // This will become a state machine
            if (!_started)
            {
                _flightDependencies.MissionClock.StartWithZeroSeconds();

                _started = true;
            }

            _flightDependencies.TelemetryEmitter.EmitTelemetry(sensorSuite);

            return new FlightCommand(mainThrottle: 0.5f);
        }
    }
}