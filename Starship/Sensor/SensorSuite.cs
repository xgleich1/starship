using System.Collections.Generic;
using Starship.Telemetry;

namespace Starship.Sensor
{
    public sealed class SensorSuite : ITelemetryProvider
    {
        public YawSensor YawSensor { get; }
        public RollSensor RollSensor { get; }
        public PitchSensor PitchSensor { get; }
        public HeightSensor HeightSensor { get; }


        public SensorSuite(
            YawSensor yawSensor,
            RollSensor rollSensor,
            PitchSensor pitchSensor,
            HeightSensor heightSensor)
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