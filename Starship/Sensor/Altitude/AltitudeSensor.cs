using System.Collections.Generic;
using Starship.Telemetry;

namespace Starship.Sensor.Altitude
{
    public sealed class AltitudeSensor : IAltitudeSensor
    {
        public float AltitudeInMeters { get; private set; }


        public void Update(Vessel vessel)
        {
            AltitudeInMeters = vessel.heightFromTerrain;
        }

        public IEnumerable<TelemetryMessage> ProvideTelemetry() =>
            new List<TelemetryMessage>
            {
                new TelemetryMessage($"Altitude:{AltitudeInMeters}")
            };
    }
}