using System;
using System.Collections.Generic;
using Starship.Telemetry;

namespace Starship.Sensor.Velocity
{
    public sealed class VelocitySensor : IVelocitySensor
    {
        public float VerticalVelocityInMetrePerSecond { get; private set; }
        
        public float ForwardVelocityInMetrePerSecond { get; private set; }
        
        public float LateralVelocityInMetrePerSecond { get; private set; }


        public void Update(Vessel vessel)
        {
            VerticalVelocityInMetrePerSecond = Convert.ToSingle(vessel.verticalSpeed);
            ForwardVelocityInMetrePerSecond = Convert.ToSingle(vessel.srf_velocity.x);
            LateralVelocityInMetrePerSecond = Convert.ToSingle(vessel.srf_velocity.y);
            
            // srf_vel_direction


            // public Vector3d obt_velocity;

            /// <summary>
            /// Presumably, the horizontal component of srf_velocity, in m/s.
            /// </summary>
            // horizontalSrfSpeed
        }

        public IEnumerable<TelemetryMessage> ProvideTelemetry() =>
            new List<TelemetryMessage>
            {
                new TelemetryMessage($"VerticalVelocity:{VerticalVelocityInMetrePerSecond}")
            };
    }
}