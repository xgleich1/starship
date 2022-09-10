using Starship.Control;
using Starship.Flight.Command;
using Starship.Flight.Segment;
using Starship.Mission;
using Starship.Sensor;
using Starship.Telemetry;

namespace Starship.Flight
{
    public sealed class FlightCommander
    {
        private readonly IMissionTimer _missionTimer;
        private readonly ITelemetryEmitter _telemetryEmitter;
        private readonly IFlightSegmentCommanders _flightSegmentCommanders;


        public FlightCommander(
            IMissionTimer missionTimer,
            ITelemetryEmitter telemetryEmitter,
            IFlightSegmentCommanders flightSegmentCommanders)
        {
            _missionTimer = missionTimer;
            _telemetryEmitter = telemetryEmitter;
            _flightSegmentCommanders = flightSegmentCommanders;
        }

        public void CommandFlight(
            ISensorSuite sensorSuite,
            IControlSuite controlSuite)
        {
            if (!_missionTimer.IsRunning)
            {
                _missionTimer.StartWithZeroSeconds();
            }

            _telemetryEmitter.EmitTelemetry(sensorSuite);

            var commandSuite = CommandFlight(sensorSuite);

            _telemetryEmitter.EmitTelemetry(commandSuite);

            controlSuite.ExertControl(commandSuite);
        }

        private ICommandSuite CommandFlight(ISensorSuite sensorSuite)
        {
            var currentFlightSegmentCommander = _flightSegmentCommanders
                .GetCurrentFlightSegmentCommander(sensorSuite);

            _telemetryEmitter.EmitTelemetry(currentFlightSegmentCommander);

            return currentFlightSegmentCommander.CommandFlight(sensorSuite);
        }
    }
}