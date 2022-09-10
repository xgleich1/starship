using System.Collections.Generic;
using Starship.Sensor.Altitude;
using Starship.Sensor.Attitude;
using Starship.Sensor.Velocity;
using Starship.Telemetry;

namespace Starship.Sensor
{
    public sealed class SensorSuite : ISensorSuite
    {
        public IAttitudeSensor AttitudeSensor { get; }
        public IAltitudeSensor AltitudeSensor { get; }
        public IVelocitySensor VelocitySensor { get; }


        public SensorSuite(
            IAttitudeSensor attitudeSensor,
            IAltitudeSensor altitudeSensor,
            IVelocitySensor velocitySensor)
        {
            AttitudeSensor = attitudeSensor;
            AltitudeSensor = altitudeSensor;
            VelocitySensor = velocitySensor;
        }

        public IEnumerable<TelemetryMessage> ProvideTelemetry()
        {
            var telemetry = new List<TelemetryMessage>();

            telemetry.AddRange(AttitudeSensor.ProvideTelemetry());
            telemetry.AddRange(AltitudeSensor.ProvideTelemetry());
            telemetry.AddRange(VelocitySensor.ProvideTelemetry());

            return telemetry;
        }
    }
}