using Starship.Telemetry;

namespace Starship.Sensor.Position.Height
{
    public interface IHeightSensor : ITelemetryProvider
    {
        float HeightInMeters { get; }
    }
}