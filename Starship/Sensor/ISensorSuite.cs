using Starship.Sensor.Attitude;
using Starship.Sensor.Velocity;
using Starship.Telemetry;

namespace Starship.Sensor
{
    public interface ISensorSuite : ITelemetryProvider
    {
        IVelocitySensor VelocitySensor { get; }
        IAttitudeSensor AttitudeSensor { get; }
    }
}