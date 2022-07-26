using System.Linq;
using System.Collections.Generic;
using Starship.Flight.Segment.Config;

namespace Starship.Flight.Segment
{
    public sealed class FlightSegmentCommandersLoader : IFlightSegmentCommandersLoader
    {
        private readonly IFlightSegmentConfigsLoader _flightSegmentConfigsLoader;


        public FlightSegmentCommandersLoader(IFlightSegmentConfigsLoader flightSegmentConfigsLoader)
        {
            _flightSegmentConfigsLoader = flightSegmentConfigsLoader;
        }

        public List<IFlightSegmentCommander> LoadFlightSegmentCommanders() =>
            _flightSegmentConfigsLoader
                .LoadFlightSegmentConfigs()
                .Select(config => new FlightSegmentCommander(config) as IFlightSegmentCommander)
                .ToList();
    }
}