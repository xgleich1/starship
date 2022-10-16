using Starship.Telemetry;

namespace Starship.Sensor.Altitude
{
    public interface IAltitudeSensor : ITelemetryProvider
    {
        /**
         * Beware: The surface of water doesn't count as terrain.
         */
        float AltitudeAboveTerrainInMeters { get; }
    }
}