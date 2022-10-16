using System.Collections.Generic;
using System.Linq;
using Starship.Flight.Segment.Actuation.Engine;
using Starship.Flight.Segment.Actuation.Flap;
using Starship.Flight.Segment.Actuation.Leg;
using Starship.Flight.Segment.Config;
using Starship.Flight.Segment.Handover;
using Starship.Flight.Segment.Throttle.Main;
using Starship.Sensor;

namespace Starship.Flight.Segment
{
    public sealed class FlightSegmentCommanders : IFlightSegmentCommanders
    {
        private readonly List<IFlightSegmentCommander> _flightSegmentCommanders;


        public FlightSegmentCommanders(IFlightSegmentConfigsLoader flightSegmentConfigsLoader) =>
            _flightSegmentCommanders = flightSegmentConfigsLoader
                .LoadFlightSegmentConfigs()
                .Select(CreateFlightSegmentCommander)
                .ToList();

        public IFlightSegmentCommander GetCurrentFlightSegmentCommander(ISensorSuite sensorSuite)
        {
            if (_flightSegmentCommanders[0].CanHandover(sensorSuite))
            {
                _flightSegmentCommanders.RemoveAt(0);
            }

            return _flightSegmentCommanders[0];
        }

        private static IFlightSegmentCommander CreateFlightSegmentCommander(FlightSegmentConfig config) =>
            new FlightSegmentCommander(
                new FlightSegmentHandoverDecider(config),
                new LegsActuationSegmentCommander(config),
                new FlapsActuationSegmentCommander(config),
                new MainEnginesGimbalSegmentCommander(config),
                new MainEnginesThrottleSegmentCommander(config));
    }
}