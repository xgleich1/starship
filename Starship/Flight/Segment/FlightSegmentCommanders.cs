using System.Collections.Generic;
using System.Linq;
using Starship.Flight.Segment.Config;
using Starship.Mission;
using Starship.Sensor;

namespace Starship.Flight.Segment
{
    public sealed class FlightSegmentCommanders : IFlightSegmentCommanders
    {
        private readonly List<IFlightSegmentCommander> _flightSegmentCommanders;

        private IFlightSegmentCommander _currentFlightSegmentCommander;


        public FlightSegmentCommanders(IFlightSegmentCommandersLoader flightSegmentCommandersLoader)
        {
            _flightSegmentCommanders = flightSegmentCommandersLoader
                .LoadFlightSegmentCommanders();

            _currentFlightSegmentCommander = _flightSegmentCommanders.First();

            // Test for when this line is missing
            _flightSegmentCommanders.Remove(_currentFlightSegmentCommander);
        }

        public IFlightSegmentCommander GetCurrentFlightSegmentCommander(ISensorSuite sensorSuite)
        {
            var nextFlightSegmentCommander = _flightSegmentCommanders.FirstOrDefault();

            if (nextFlightSegmentCommander?.CanTakeover(sensorSuite) == true)
            {
                _flightSegmentCommanders.Remove(nextFlightSegmentCommander);

                _currentFlightSegmentCommander = nextFlightSegmentCommander;
            }

            return _currentFlightSegmentCommander;
        }
    }
}