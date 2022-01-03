using System.Collections.Generic;
using Starship.Control;
using Starship.Flight.Command;
using Starship.Flight.Segment;
using Starship.Flight.Segment.Ascent;
using Starship.Flight.Segment.Flip;
using Starship.Flight.Segment.Flop;
using Starship.Mission;
using Starship.Sensor;
using Starship.Telemetry;

namespace Starship.Flight
{
    // Currently under development
    public sealed class FlightCommander
    {
        private readonly IMissionTimer _missionTimer;
        private readonly ITelemetryEmitter _telemetryEmitter;


        public FlightCommander(
            IMissionTimer missionTimer,
            ITelemetryEmitter telemetryEmitter)
        {
            _missionTimer = missionTimer;
            _telemetryEmitter = telemetryEmitter;
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
            var flightSegmentCommanders = new List<FlightSegmentCommander>
            {
                new AscentFlightCommander(),
                new FlipFlightCommander(),
                new FlopFlightCommander()
            };

            var responsibleFlightSegmentCommander =
                FindResponsibleFlightSegmentCommander(flightSegmentCommanders);

            return responsibleFlightSegmentCommander.CommandFlight(sensorSuite);
        }

        private FlightSegmentCommander FindResponsibleFlightSegmentCommander(
            List<FlightSegmentCommander> flightSegmentCommanders
        ) => flightSegmentCommanders.FindLast(commander =>
            commander.TakeoverSecondsInMission <= _missionTimer.GetElapsedSeconds());
    }
}