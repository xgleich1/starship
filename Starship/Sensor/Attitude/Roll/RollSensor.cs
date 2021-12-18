using System.Collections.Generic;
using Starship.Telemetry;
using UnityEngine;

namespace Starship.Sensor.Attitude.Roll
{
    public sealed class RollSensor : IRollSensor
    {
        public float RollAngleInDegrees { get; private set; }


        public void Update(Vessel vessel) =>
            RollAngleInDegrees = CalculateRollAngleInDegrees(vessel);

        public IEnumerable<TelemetryMessage> ProvideTelemetry() =>
            new List<TelemetryMessage> { new TelemetryMessage($"Roll:{RollAngleInDegrees}") };

        // Roll angle starts with 90.
        // Positive roll: Against the clock, roll angle getting more.
        // Negative roll: With the clock, roll angle getting less.
        private static float CalculateRollAngleInDegrees(Vessel vessel) =>
            Vector3.Angle(vessel.vesselTransform.rotation * Vector3.left,
                Vector3.ProjectOnPlane(vessel.mainBody.transform.up, vessel.upAxis));
    }
}