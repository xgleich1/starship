using Starship.Sensor.Attitude.Pitch;
using Starship.Sensor.Attitude.Roll;
using Starship.Sensor.Attitude.Yaw;
using Starship.Sensor.Position.Height;
using Starship.Telemetry;

namespace Starship.Sensor
{
    public interface ISensorSuite : ITelemetryProvider
    {
        IYawSensor YawSensor { get; }
        IRollSensor RollSensor { get; }
        IPitchSensor PitchSensor { get; }
        IHeightSensor HeightSensor { get; }
    }
}