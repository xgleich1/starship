using Starship.Telemetry;

namespace Starship.Sensor.Velocity
{
    public interface IVelocitySensor : ITelemetryProvider
    {
        /**
         * Vertical velocity starts with 0.
         * Positive velocity: Upward motion.
         * Negative velocity: Downward motion.
         */
        float VerticalVelocityInMetrePerSecond { get; }
    }
}