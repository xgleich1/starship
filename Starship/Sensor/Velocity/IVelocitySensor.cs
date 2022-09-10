using Starship.Telemetry;

namespace Starship.Sensor.Velocity
{
    public interface IVelocitySensor : ITelemetryProvider
    {
        /**
         * Positive velocity: To the left.
         * Negative velocity: To the right.
         */
        float LateralVelocityInMetrePerSecond { get; }
        /**
         * Positive velocity: Upward.
         * Negative velocity: Downward.
         */
        float VerticalVelocityInMetrePerSecond { get; }
        /**
         * Positive velocity: To the front.
         * Negative velocity: To the back.
         */
        float HorizontalVelocityInMetrePerSecond { get; }
    }
}