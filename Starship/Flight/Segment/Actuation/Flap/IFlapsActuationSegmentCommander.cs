using Starship.Sensor;
using Starship.Telemetry;

namespace Starship.Flight.Segment.Actuation.Flap
{
    public interface IFlapsActuationSegmentCommander : ITelemetryProvider
    {
        FlapsActuationSegmentCommands CommandFlapsActuation(ISensorSuite sensorSuite);
    }
}