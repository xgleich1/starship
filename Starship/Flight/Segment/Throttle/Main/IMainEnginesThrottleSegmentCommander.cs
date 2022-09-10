using Starship.Sensor;
using Starship.Telemetry;

namespace Starship.Flight.Segment.Throttle.Main
{
    public interface IMainEnginesThrottleSegmentCommander : ITelemetryProvider
    {
        MainEnginesThrottleSegmentCommands CommandMainEnginesThrottle(ISensorSuite sensorSuite);
    }
}