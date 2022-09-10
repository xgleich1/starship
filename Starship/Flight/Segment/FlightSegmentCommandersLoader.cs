using System.Linq;
using System.Collections.Generic;
using Starship.Flight.Segment.Actuation.Engine;
using Starship.Flight.Segment.Actuation.Flap;
using Starship.Flight.Segment.Actuation.Leg;
using Starship.Flight.Segment.Config;
using Starship.Flight.Segment.Handover;
using Starship.Flight.Segment.Throttle.Main;

namespace Starship.Flight.Segment
{
    // Currently under development
    public sealed class FlightSegmentCommandersLoader : IFlightSegmentCommandersLoader
    {
        private readonly IFlightSegmentConfigsLoader _flightSegmentConfigsLoader;


        public FlightSegmentCommandersLoader(IFlightSegmentConfigsLoader flightSegmentConfigsLoader) =>
            _flightSegmentConfigsLoader = flightSegmentConfigsLoader;

        public List<IFlightSegmentCommander> LoadFlightSegmentCommanders() => _flightSegmentConfigsLoader
            .LoadFlightSegmentConfigs()
            .Select(CreateFlightSegmentCommander)
            .ToList();

        private static IFlightSegmentCommander CreateFlightSegmentCommander(FlightSegmentConfig config) =>
            new FlightSegmentCommander(
                new FlightSegmentHandoverDecider(config),
                new LegsActuationSegmentCommander(config),
                new FlapsActuationSegmentCommander(config),
                new MainEnginesGimbalSegmentCommander(config),
                new MainEnginesThrottleSegmentCommander(config));
    }
}