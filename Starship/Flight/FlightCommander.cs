using Starship.Control;
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

        public void CommandFlight(SensorSuite sensorSuite, ControlSuite controlSuite)
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
                topLeftRcsThrottle: 1.0f, 
                topRightRcsThrottle: 1.0f,
                bottomLeftRcsThrottle: 1.0f,
                bottomRightRcsThrottle: 1.0f,
                topMainEngineThrottle: 0.0f,
                bottomLeftMainEngineThrottle: 0.0f,
                bottomRightMainEngineThrottle: 0.0f,
                mainEngineGimbalYaw: 0.0f,
                mainEngineGimbalRoll: 0.0f,
                mainEngineGimbalPitch: 0.0f);
            
            controlSuite.ExertControl(flightCommand);
        }
    }
}