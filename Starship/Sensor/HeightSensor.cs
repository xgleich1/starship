using System;
using System.Collections.Generic;
using Starship.Telemetry;

namespace Starship.Sensor
{
    public sealed class HeightSensor : ITelemetryProvider
    {
        public int HeightInMeters { get; }


        public HeightSensor(int heightInMeters)
        {
            HeightInMeters = heightInMeters;
        }

        public HeightSensor(Vessel vessel) : this(CalculateHeightInMeters(vessel))
        {
            // Other options:
            // vessel.altitude;
            // vessel.heightFromSurface;
            // vessel.heightFromTerrain;
            // vessel.RevealAltitude();
            // vessel.GetHeightFromSurface();
            // vessel.GetHeightFromTerrain();
        }

        public IEnumerable<TelemetryMessage> ProvideTelemetry() =>
            new List<TelemetryMessage> {new TelemetryMessage($"Height:{HeightInMeters}")};

        private static int CalculateHeightInMeters(Vessel vessel) => Convert.ToInt32(vessel.heightFromTerrain);
    }
}