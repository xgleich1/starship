using Starship.Telemetry;

namespace Starship.Sensor.Attitude.Roll
{
    public interface IRollSensor : ITelemetryProvider
    {
        float RollAngleInDegrees { get; }
    }
}