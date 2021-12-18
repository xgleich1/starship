using System.Collections.Generic;
using Starship.Telemetry;
using UnityEngine;

namespace Starship.Sensor.Attitude.Pitch
{
    public sealed class PitchSensor : IPitchSensor
    {
        public float PitchAngleInDegrees { get; private set; }


        public void Update(Vessel vessel) =>
            PitchAngleInDegrees = CalculatePitchAngleInDegrees(vessel);

        public IEnumerable<TelemetryMessage> ProvideTelemetry() =>
            new List<TelemetryMessage> { new TelemetryMessage($"Pitch:{PitchAngleInDegrees}") };

        // Pitch angle starts with 90.
        // Positive pitch: To the back, pitch angle getting more.
        // Negative pitch: To the front, pitch angle getting less.
        private static float CalculatePitchAngleInDegrees(Vessel vessel) =>
            Vector3.Angle(vessel.vesselTransform.rotation * Vector3.back, vessel.upAxis);
    }
}