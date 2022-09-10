using System.Collections.Generic;
using System.Linq;
using Starship.Sensor;

namespace Starship.Flight.Segment
{
    // Currently under development
    public sealed class FlightSegmentCommanders : IFlightSegmentCommanders
    {
        private readonly List<IFlightSegmentCommander> _flightSegmentCommanders;


        public FlightSegmentCommanders(IFlightSegmentCommandersLoader flightSegmentCommandersLoader) =>
            _flightSegmentCommanders = flightSegmentCommandersLoader.LoadFlightSegmentCommanders();

        public IFlightSegmentCommander GetCurrentFlightSegmentCommander(ISensorSuite sensorSuite)
        {
            if (_flightSegmentCommanders.First().CanHandover(sensorSuite))
            {
                _flightSegmentCommanders.RemoveAt(0);
            }

            return _flightSegmentCommanders.First();
        }
    }
}