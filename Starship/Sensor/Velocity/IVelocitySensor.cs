using Starship.Telemetry;

namespace Starship.Sensor.Velocity
{
    public interface IVelocitySensor : ITelemetryProvider
    {
        /**
         * Positive velocity: Upward motion.
         * Negative velocity: Downward motion.
         */
        float VerticalVelocityInMetrePerSecond { get; }
        
        float ForwardVelocityInMetrePerSecond { get; } // Naming
        
        float LateralVelocityInMetrePerSecond { get; }
    }
}