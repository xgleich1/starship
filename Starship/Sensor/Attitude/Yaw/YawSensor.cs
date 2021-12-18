using System.Collections.Generic;
using Starship.Telemetry;
using UnityEngine;

namespace Starship.Sensor.Attitude.Yaw
{
    public sealed class YawSensor : IYawSensor
    {
        public float YawAngleInDegrees { get; private set; }


        public void Update(Vessel vessel) =>
            YawAngleInDegrees = CalculateYawAngleInDegrees(vessel);

        public IEnumerable<TelemetryMessage> ProvideTelemetry() =>
            new List<TelemetryMessage> { new TelemetryMessage($"Yaw:{YawAngleInDegrees}") };

        // Yaw angle starts with 90.
        // Positive yaw: To the right with yaw angle getting more.
        // Negative yaw: To The left with yaw angle getting less.
        private static float CalculateYawAngleInDegrees(Vessel vessel) =>
            Vector3.Angle(vessel.vesselTransform.rotation * Vector3.right, vessel.upAxis);
    }
}