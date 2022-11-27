using Starship.Sensor;
using Starship.Telemetry;

namespace Starship.Flight.Segment.Activation.Rcs
{
    public interface IRcsActivationSegmentCommander : ITelemetryProvider
    {
        RcsActivationSegmentCommands CommandRcsActivation(ISensorSuite sensorSuite);
    }
}