using System;
using System.Collections.Generic;
using Starship.Telemetry;
using UnityEngine;

namespace Starship.Sensor.Velocity
{
    public sealed class VelocitySensor : IVelocitySensor
    {
        public float LateralVelocityInMetrePerSecond { get; private set; }
        public float VerticalVelocityInMetrePerSecond { get; private set; }
        public float HorizontalVelocityInMetrePerSecond { get; private set; }


        public void Update(Vessel vessel)
        {
            var surfaceVelocityInMetrePerSecond = GetSurfaceVelocityInMetrePerSecond(vessel);

            LateralVelocityInMetrePerSecond = surfaceVelocityInMetrePerSecond.x;
            VerticalVelocityInMetrePerSecond = Convert.ToSingle(vessel.verticalSpeed);
            HorizontalVelocityInMetrePerSecond = surfaceVelocityInMetrePerSecond.y;
        }

        public IEnumerable<TelemetryMessage> ProvideTelemetry() => new List<TelemetryMessage>
        {
            new TelemetryMessage($"LateralVelocity:{LateralVelocityInMetrePerSecond}"),
            new TelemetryMessage($"VerticalVelocity:{VerticalVelocityInMetrePerSecond}"),
            new TelemetryMessage($"HorizontalVelocity:{HorizontalVelocityInMetrePerSecond}")
        };

        private static Vector3 GetSurfaceVelocityInMetrePerSecond(Vessel vessel) =>
            Vector3.ProjectOnPlane(vessel.srf_velocity, vessel.upAxis);
    }
}