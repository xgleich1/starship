using Starship.Telemetry;

namespace Starship.Sensor.Attitude
{
    public interface IAttitudeSensor : ITelemetryProvider
    {
        /**
         * Yaw angle starts with 0.
         * Positive yaw: To the right with yaw angle getting more.
         * Negative yaw: To The left with yaw angle getting less.
         */
        float YawAngleInDegrees { get; }
        /**
         * Roll angle starts with 0.
         * Positive roll: With the clock (right), roll angle getting more.
         * Negative roll: Against the clock (left), roll angle getting less.
         */
        float RollAngleInDegrees { get; }
        /**
         * Pitch angle starts with 0.
         * Positive pitch: To the back, pitch angle getting more.
         * Negative pitch: To the front, pitch angle getting less.
         */
        float PitchAngleInDegrees { get; }
    }
}