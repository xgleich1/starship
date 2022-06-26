using System.Collections.Generic;
using System.Linq;
using Starship.Flight.Segment.Config;
using Starship.Mission;

namespace Starship.Flight.Segment
{
    public sealed class FlightSegmentCommanders : IFlightSegmentCommanders
    {
        private readonly IMissionTimer _missionTimer;
        private readonly List<FlightSegmentCommander> _flightSegmentCommanders;


        public FlightSegmentCommanders(
            IMissionTimer missionTimer,
            IFlightSegmentConfigsLoader flightSegmentConfigsLoader)
        {
            _missionTimer = missionTimer;

            _flightSegmentCommanders = flightSegmentConfigsLoader
                .LoadFlightSegmentConfigs()
                .Select(config => new FlightSegmentCommander(config))
                .ToList();
        }

        public IFlightSegmentCommander GetCurrentFlightSegmentCommander()
        {
            var elapsedSecondsInMission = _missionTimer.GetElapsedSeconds();

            return _flightSegmentCommanders.Last(commander =>
                commander.TakeoverSecondsInMission <= elapsedSecondsInMission);
        }
    }
}