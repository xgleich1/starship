using Starship.Telemetry;

namespace Starship.Sensor.Altitude
{
    public interface IAltitudeSensor : ITelemetryProvider
    {
        float AltitudeAboveTerrainInMeters { get; }
    }
}