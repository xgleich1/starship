using Starship.Sensor.Altitude;
using Starship.Sensor.Attitude;
using Starship.Sensor.Velocity;
using Starship.Telemetry;

namespace Starship.Sensor
{
    public interface ISensorSuite : ITelemetryProvider
    {
        IAttitudeSensor AttitudeSensor { get; }
        IAltitudeSensor AltitudeSensor { get; }
        IVelocitySensor VelocitySensor { get; }
    }
}