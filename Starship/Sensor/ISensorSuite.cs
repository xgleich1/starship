using Starship.Sensor.Attitude;
using Starship.Telemetry;

namespace Starship.Sensor
{
    public interface ISensorSuite : ITelemetryProvider
    {
        IAttitudeSensor AttitudeSensor { get; }
    }
}