using System;
using System.Collections.Generic;
using Starship.Telemetry;
using UnityEngine;

namespace Starship.Sensor.Attitude
{
    public sealed class RollSensor : ITelemetryProvider
    {
        public int RollAngle { get; }


        public RollSensor(int rollAngle)
        {
            RollAngle = rollAngle;
        }

        public RollSensor(Vessel vessel) : this(CalculateRollAngle(vessel))
        {
        }

        public IEnumerable<TelemetryMessage> ProvideTelemetry() =>
            new List<TelemetryMessage> {new TelemetryMessage($"Roll:{RollAngle}")};

        // Starts with 90.
        // Get's more with roll(q) and less with roll(e).
        // Get's less after 180 is reached and more after reaching 0. 
        private static int CalculateRollAngle(Vessel vessel) =>
            Convert.ToInt32(Vector3.Angle(vessel.vesselTransform.rotation * Vector3.right,
                Vector3.ProjectOnPlane(vessel.mainBody.transform.up, vessel.upAxis)));
    }
}