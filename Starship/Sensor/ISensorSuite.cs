using Starship.Sensor.Attitude;
using Starship.Sensor.Position;
using Starship.Telemetry;

namespace Starship.Sensor
{
    public interface ISensorSuite : ITelemetryProvider
    {
        YawSensor YawSensor { get; }
        RollSensor RollSensor { get; }
        PitchSensor PitchSensor { get; }
        HeightSensor HeightSensor { get; }
    }
}