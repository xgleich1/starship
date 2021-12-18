using Starship.Telemetry;

namespace Starship.Sensor.Attitude.Yaw
{
    public interface IYawSensor : ITelemetryProvider
    {
        float YawAngleInDegrees { get; }
    }
}