using System.Collections.Generic;
using Starship.Telemetry;

namespace Starship.Sensor.Altitude
{
    public sealed class AltitudeSensor : IAltitudeSensor
    {
        public float AltitudeAboveTerrainInMeters { get; private set; }


        public void Update(Vessel vessel) =>
            // The height is +6.9 meters off the lowest part of
            // starship when it's vertical. Offset is subtracted to
            // sense an altitude of zero after an successful landing
            AltitudeAboveTerrainInMeters = vessel.heightFromTerrain - 6.9F;

        public IEnumerable<TelemetryMessage> ProvideTelemetry() => new List<TelemetryMessage>
        {
            new TelemetryMessage($"Altitude:{AltitudeAboveTerrainInMeters}")
        };
    }
}