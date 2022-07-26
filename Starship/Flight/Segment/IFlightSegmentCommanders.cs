using Starship.Sensor;

namespace Starship.Flight.Segment
{
    public interface IFlightSegmentCommanders
    {
        IFlightSegmentCommander GetCurrentFlightSegmentCommander(ISensorSuite sensorSuite);
    }
}