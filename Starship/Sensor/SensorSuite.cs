using System.Collections.Generic;
using Starship.Sensor.Attitude.Pitch;
using Starship.Sensor.Attitude.Roll;
using Starship.Sensor.Attitude.Yaw;
using Starship.Sensor.Position.Height;
using Starship.Telemetry;

namespace Starship.Sensor
{
    public sealed class SensorSuite : ISensorSuite
    {
        public IYawSensor YawSensor { get; }
        public IRollSensor RollSensor { get; }
        public IPitchSensor PitchSensor { get; }
        public IHeightSensor HeightSensor { get; }


        public SensorSuite(
            IYawSensor yawSensor,
            IRollSensor rollSensor,
            IPitchSensor pitchSensor,
            IHeightSensor heightSensor)
        {
            YawSensor = yawSensor;
            RollSensor = rollSensor;
            PitchSensor = pitchSensor;
            HeightSensor = heightSensor;
        }

        public IEnumerable<TelemetryMessage> ProvideTelemetry()
        {
            var telemetry = new List<TelemetryMessage>();

            telemetry.AddRange(YawSensor.ProvideTelemetry());
            telemetry.AddRange(RollSensor.ProvideTelemetry());
            telemetry.AddRange(PitchSensor.ProvideTelemetry());
            telemetry.AddRange(HeightSensor.ProvideTelemetry());

            return telemetry;
        }
    }
}