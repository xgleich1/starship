using Starship.Sensor;
using Starship.Telemetry;

namespace Starship.Flight.Segment.Handover
{
    public interface IFlightSegmentHandoverDecider : ITelemetryProvider
    {
        bool CanHandover(ISensorSuite sensorSuite);
    }
}