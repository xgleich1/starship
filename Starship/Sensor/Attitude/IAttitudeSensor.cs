using Starship.Telemetry;

namespace Starship.Sensor.Attitude
{
    public interface IAttitudeSensor : ITelemetryProvider
    {
        /**
         * More yaw: To the right.
         * Less yaw: To the left.
         */
        float YawAngleInDegrees { get; }
        /**
         * More roll: With the clock (right).
         * Less roll: Against the clock (left).
         */
        float RollAngleInDegrees { get; }
        /**
         * More pitch: To the back.
         * Less pitch: To the front.
         */
        float PitchAngleInDegrees { get; }
    }
}