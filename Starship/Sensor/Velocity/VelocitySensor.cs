using System;
using System.Collections.Generic;
using Starship.Telemetry;

namespace Starship.Sensor.Velocity
{
    public sealed class VelocitySensor : IVelocitySensor
    {
        public float VerticalVelocityInMetrePerSecond { get; private set; }


        public void Update(Vessel vessel)
        {
            VerticalVelocityInMetrePerSecond = Convert.ToSingle(vessel.verticalSpeed);
        }

        public IEnumerable<TelemetryMessage> ProvideTelemetry() =>
            new List<TelemetryMessage>
            {
                new TelemetryMessage($"VerticalVelocity:{VerticalVelocityInMetrePerSecond}")
            };
    }
}