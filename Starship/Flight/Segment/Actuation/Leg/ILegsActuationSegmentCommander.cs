using Starship.Flight.Command.Actuation.Leg;
using Starship.Sensor;
using Starship.Telemetry;

namespace Starship.Flight.Segment.Actuation.Leg
{
    public interface ILegsActuationSegmentCommander : ITelemetryProvider
    {
        LegsActuationCommand CommandLegsActuation(ISensorSuite sensorSuite);
    }
}