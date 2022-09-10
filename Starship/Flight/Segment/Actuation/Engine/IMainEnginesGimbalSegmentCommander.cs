using Starship.Sensor;
using Starship.Telemetry;

namespace Starship.Flight.Segment.Actuation.Engine
{
    public interface IMainEnginesGimbalSegmentCommander : ITelemetryProvider
    {
        MainEnginesGimbalSegmentCommands CommandMainEnginesGimbal(ISensorSuite sensorSuite);
    }
}