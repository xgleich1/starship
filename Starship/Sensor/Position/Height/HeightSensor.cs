using System.Collections.Generic;
using Starship.Telemetry;

namespace Starship.Sensor.Position.Height
{
    public sealed class HeightSensor : IHeightSensor
    {
        public float HeightInMeters { get; private set; }


        public void Update(Vessel vessel) =>
            HeightInMeters = vessel.heightFromTerrain;

        public IEnumerable<TelemetryMessage> ProvideTelemetry() =>
            new List<TelemetryMessage> { new TelemetryMessage($"Height:{HeightInMeters}") };
    }
}