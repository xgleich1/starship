using Starship.Telemetry;

namespace Starship.Sensor.Attitude.Pitch
{
    public interface IPitchSensor : ITelemetryProvider
    {
        float PitchAngleInDegrees { get; }
    }
}