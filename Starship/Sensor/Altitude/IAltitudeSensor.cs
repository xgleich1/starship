using Starship.Telemetry;

namespace Starship.Sensor.Altitude
{
    public interface IAltitudeSensor : ITelemetryProvider
    {
        float AltitudeInMeters { get; } // from terrain? Be specific
    }
}