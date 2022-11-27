using Starship.Telemetry;

namespace Starship.Sensor.Attitude
{
    public interface IAttitudeSensor : ITelemetryProvider
    {
        /**
         * More yaw angle: To the right.
         * Less yaw angle: To the left.
         */
        float YawAngleInDegrees { get; }
        /**
         * More roll angle: With the clock, seen from below.
         * Less roll angle: Against the clock, seen from below.
         */
        float RollAngleInDegrees { get; }
        /**
         * More pitch angle: To the back.
         * Less pitch angle: To the front.
         */
        float PitchAngleInDegrees { get; }
    }
}