using System.Collections.Generic;
using Starship.Sensor.Altitude;
using Starship.Sensor.Attitude;
using Starship.Sensor.Velocity;
using Starship.Telemetry;

namespace Starship.Sensor
{
    public sealed class SensorSuite : ISensorSuite
    {
        public IVelocitySensor VelocitySensor { get; }
        public IAttitudeSensor AttitudeSensor { get; }
        public IAltitudeSensor AltitudeSensor { get; }

        public float VerticalVelocityInMetrePerSecond => VelocitySensor.VerticalVelocityInMetrePerSecond;
        public float YawAngleInDegrees => AttitudeSensor.YawAngleInDegrees;
        public float RollAngleInDegrees => AttitudeSensor.RollAngleInDegrees;
        public float PitchAngleInDegrees => AttitudeSensor.PitchAngleInDegrees;
        public float AltitudeInMeters => AltitudeSensor.AltitudeInMeters;


        public SensorSuite(
            IVelocitySensor velocitySensor,
            IAttitudeSensor attitudeSensor,
            IAltitudeSensor altitudeSensor)
        {
            VelocitySensor = velocitySensor;
            AttitudeSensor = attitudeSensor;
            AltitudeSensor = altitudeSensor;
        }

        public IEnumerable<TelemetryMessage> ProvideTelemetry()
        {
            var telemetry = new List<TelemetryMessage>();

            telemetry.AddRange(VelocitySensor.ProvideTelemetry());
            telemetry.AddRange(AttitudeSensor.ProvideTelemetry());
            telemetry.AddRange(AltitudeSensor.ProvideTelemetry());

            return telemetry;
        }
    }
}