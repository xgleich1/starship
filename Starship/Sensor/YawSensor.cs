using System;
using System.Collections.Generic;
using Starship.Telemetry;
using UnityEngine;

namespace Starship.Sensor
{
    public sealed class YawSensor : ITelemetryProvider
    {
        public int YawAngle { get; }


        public YawSensor(int yawAngle)
        {
            YawAngle = yawAngle;
        }

        public YawSensor(Vessel vessel) : this(CalculateYawAngle(vessel))
        {
        }

        public IEnumerable<TelemetryMessage> ProvideTelemetry() =>
            new List<TelemetryMessage> {new TelemetryMessage($"Yaw:{YawAngle}")};

        // Starts with 90, which is straight up.
        // Get's more with yaw(d) and less with yaw(a).
        private static int CalculateYawAngle(Vessel vessel) =>
            Convert.ToInt32(Vector3.Angle(vessel.vesselTransform.rotation * Vector3.right, vessel.upAxis));
    }
}