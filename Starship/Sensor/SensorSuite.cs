using System.Collections.Generic;
using Starship.Sensor.Attitude;
using Starship.Sensor.Velocity;
using Starship.Telemetry;

namespace Starship.Sensor
{
    public sealed class SensorSuite : ISensorSuite
    {
        public IVelocitySensor VelocitySensor { get; }
        public IAttitudeSensor AttitudeSensor { get; }


        public SensorSuite(
            IVelocitySensor velocitySensor,
            IAttitudeSensor attitudeSensor)
        {
            VelocitySensor = velocitySensor;
            AttitudeSensor = attitudeSensor;
        }

        public IEnumerable<TelemetryMessage> ProvideTelemetry()
        {
            var telemetry = new List<TelemetryMessage>();

            telemetry.AddRange(VelocitySensor.ProvideTelemetry());
            telemetry.AddRange(AttitudeSensor.ProvideTelemetry());

            return telemetry;
        }
    }
}