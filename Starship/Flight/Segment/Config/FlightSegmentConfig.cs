using System.Collections.Generic;
using Starship.Telemetry;

namespace Starship.Flight.Segment.Config
{
    // Currently under development
    public readonly struct FlightSegmentConfig : IFlightSegmentConfig
    {
        public float? TakeoverVerticalVelocity { get; }
        public float? TakeoverVerticalVelocityTolerance { get; }

        public float? TakeoverYawAngle { get; }
        public float? TakeoverYawAngleTolerance { get; }

        public float? TakeoverRollAngle { get; }
        public float? TakeoverRollAngleTolerance { get; }

        public float? TakeoverPitchAngle { get; }
        public float? TakeoverPitchAngleTolerance { get; }

        public float? TakeoverAltitude { get; }
        public float? TakeoverAltitudeTolerance { get; }

        public float DesiredVerticalVelocityInMetrePerSecond { get; }

        public float MainEnginesThrottleProportionalGain { get; }
        public float MainEnginesThrottleIntegralGain { get; }
        public float MainEnginesThrottleDerivativeGain { get; }

        public float? TopMainEngineThrottlePercentOverwrite { get; }
        public float? BottomLeftMainEngineThrottlePercentOverwrite { get; }
        public float? BottomRightMainEngineThrottlePercentOverwrite { get; }

        public float DesiredYawAngleInDegrees { get; }
        public float DesiredRollAngleInDegrees { get; }
        public float DesiredPitchAngleInDegrees { get; }

        public float MainEnginesGimbalProportionalGain { get; }
        public float MainEnginesGimbalIntegralGain { get; }
        public float MainEnginesGimbalDerivativeGain { get; }

        public float? MainEnginesYawPercentOverwrite { get; }
        public float? MainEnginesRollPercentOverwrite { get; }
        public float? MainEnginesPitchPercentOverwrite { get; }

        public float FlapsActuationProportionalGain { get; }
        public float FlapsActuationIntegralGain { get; }
        public float FlapsActuationDerivativeGain { get; }

        public float? TopLeftFlapDeployPercentOverwrite { get; }
        public float? TopRightFlapDeployPercentOverwrite { get; }
        public float? BottomLeftFlapDeployPercentOverwrite { get; }
        public float? BottomRightFlapDeployPercentOverwrite { get; }

        public bool LegsActuationExtendedState { get; }


        public FlightSegmentConfig(
            float? takeoverVerticalVelocity,
            float? takeoverVerticalVelocityTolerance,
            float? takeoverYawAngle,
            float? takeoverYawAngleTolerance,
            float? takeoverRollAngle,
            float? takeoverRollAngleTolerance,
            float? takeoverPitchAngle,
            float? takeoverPitchAngleTolerance,
            float? takeoverAltitude,
            float? takeoverAltitudeTolerance,
            float desiredVerticalVelocityInMetrePerSecond,
            float mainEnginesThrottleProportionalGain,
            float mainEnginesThrottleIntegralGain,
            float mainEnginesThrottleDerivativeGain,
            float? topMainEngineThrottlePercentOverwrite,
            float? bottomLeftMainEngineThrottlePercentOverwrite,
            float? bottomRightMainEngineThrottlePercentOverwrite,
            float desiredYawAngleInDegrees,
            float desiredRollAngleInDegrees,
            float desiredPitchAngleInDegrees,
            float mainEnginesGimbalProportionalGain,
            float mainEnginesGimbalIntegralGain,
            float mainEnginesGimbalDerivativeGain,
            float? mainEnginesYawPercentOverwrite,
            float? mainEnginesRollPercentOverwrite,
            float? mainEnginesPitchPercentOverwrite,
            float flapsActuationProportionalGain,
            float flapsActuationIntegralGain,
            float flapsActuationDerivativeGain,
            float? topLeftFlapDeployPercentOverwrite,
            float? topRightFlapDeployPercentOverwrite,
            float? bottomLeftFlapDeployPercentOverwrite,
            float? bottomRightFlapDeployPercentOverwrite,
            bool legsActuationExtendedState)
        {
            TakeoverVerticalVelocity = takeoverVerticalVelocity;
            TakeoverVerticalVelocityTolerance = takeoverVerticalVelocityTolerance;
            TakeoverYawAngle = takeoverYawAngle;
            TakeoverYawAngleTolerance = takeoverYawAngleTolerance;
            TakeoverRollAngle = takeoverRollAngle;
            TakeoverRollAngleTolerance = takeoverRollAngleTolerance;
            TakeoverPitchAngle = takeoverPitchAngle;
            TakeoverPitchAngleTolerance = takeoverPitchAngleTolerance;
            TakeoverAltitude = takeoverAltitude;
            TakeoverAltitudeTolerance = takeoverAltitudeTolerance;
            DesiredVerticalVelocityInMetrePerSecond = desiredVerticalVelocityInMetrePerSecond;
            MainEnginesThrottleProportionalGain = mainEnginesThrottleProportionalGain;
            MainEnginesThrottleIntegralGain = mainEnginesThrottleIntegralGain;
            MainEnginesThrottleDerivativeGain = mainEnginesThrottleDerivativeGain;
            TopMainEngineThrottlePercentOverwrite = topMainEngineThrottlePercentOverwrite;
            BottomLeftMainEngineThrottlePercentOverwrite = bottomLeftMainEngineThrottlePercentOverwrite;
            BottomRightMainEngineThrottlePercentOverwrite = bottomRightMainEngineThrottlePercentOverwrite;
            DesiredYawAngleInDegrees = desiredYawAngleInDegrees;
            DesiredRollAngleInDegrees = desiredRollAngleInDegrees;
            DesiredPitchAngleInDegrees = desiredPitchAngleInDegrees;
            MainEnginesGimbalProportionalGain = mainEnginesGimbalProportionalGain;
            MainEnginesGimbalIntegralGain = mainEnginesGimbalIntegralGain;
            MainEnginesGimbalDerivativeGain = mainEnginesGimbalDerivativeGain;
            MainEnginesYawPercentOverwrite = mainEnginesYawPercentOverwrite;
            MainEnginesRollPercentOverwrite = mainEnginesRollPercentOverwrite;
            MainEnginesPitchPercentOverwrite = mainEnginesPitchPercentOverwrite;
            FlapsActuationProportionalGain = flapsActuationProportionalGain;
            FlapsActuationIntegralGain = flapsActuationIntegralGain;
            FlapsActuationDerivativeGain = flapsActuationDerivativeGain;
            TopLeftFlapDeployPercentOverwrite = topLeftFlapDeployPercentOverwrite;
            TopRightFlapDeployPercentOverwrite = topRightFlapDeployPercentOverwrite;
            BottomLeftFlapDeployPercentOverwrite = bottomLeftFlapDeployPercentOverwrite;
            BottomRightFlapDeployPercentOverwrite = bottomRightFlapDeployPercentOverwrite;
            LegsActuationExtendedState = legsActuationExtendedState;
        }

        public IEnumerable<TelemetryMessage> ProvideTelemetry() => new List<TelemetryMessage>
        {
            new TelemetryMessage($"TakeoverVerticalVelocity:{TakeoverVerticalVelocity}"),
            new TelemetryMessage($"TakeoverVerticalVelocityTolerance:{TakeoverVerticalVelocityTolerance}"),
            new TelemetryMessage($"TakeoverYawAngle:{TakeoverYawAngle}"),
            new TelemetryMessage($"TakeoverYawAngleTolerance:{TakeoverYawAngleTolerance}"),
            new TelemetryMessage($"TakeoverRollAngle:{TakeoverRollAngle}"),
            new TelemetryMessage($"TakeoverRollAngleTolerance:{TakeoverRollAngleTolerance}"),
            new TelemetryMessage($"TakeoverPitchAngle:{TakeoverPitchAngle}"),
            new TelemetryMessage($"TakeoverPitchAngleTolerance:{TakeoverPitchAngleTolerance}"),
            new TelemetryMessage($"TakeoverAltitude:{TakeoverAltitude}"),
            new TelemetryMessage($"TakeoverAltitudeTolerance:{TakeoverAltitudeTolerance}"),
            new TelemetryMessage($"DesiredVerticalVelocityInMetrePerSecond:{DesiredVerticalVelocityInMetrePerSecond}"),
            new TelemetryMessage($"MainEnginesThrottleProportionalGain:{MainEnginesThrottleProportionalGain}"),
            new TelemetryMessage($"MainEnginesThrottleIntegralGain:{MainEnginesThrottleIntegralGain}"),
            new TelemetryMessage($"MainEnginesThrottleDerivativeGain:{MainEnginesThrottleDerivativeGain}"),
            new TelemetryMessage($"TopMainEngineThrottlePercentOverwrite:{TopMainEngineThrottlePercentOverwrite}"),
            new TelemetryMessage($"BottomLeftMainEngineThrottlePercentOverwrite:{BottomLeftMainEngineThrottlePercentOverwrite}"),
            new TelemetryMessage($"BottomRightMainEngineThrottlePercentOverwrite:{BottomRightMainEngineThrottlePercentOverwrite}"),
            new TelemetryMessage($"DesiredYawAngleInDegrees:{DesiredYawAngleInDegrees}"),
            new TelemetryMessage($"DesiredRollAngleInDegrees:{DesiredRollAngleInDegrees}"),
            new TelemetryMessage($"DesiredPitchAngleInDegrees:{DesiredPitchAngleInDegrees}"),
            new TelemetryMessage($"MainEnginesGimbalProportionalGain:{MainEnginesGimbalProportionalGain}"),
            new TelemetryMessage($"MainEnginesGimbalIntegralGain:{MainEnginesGimbalIntegralGain}"),
            new TelemetryMessage($"MainEnginesGimbalDerivativeGain:{MainEnginesGimbalDerivativeGain}"),
            new TelemetryMessage($"MainEnginesYawPercentOverwrite:{MainEnginesYawPercentOverwrite}"),
            new TelemetryMessage($"MainEnginesRollPercentOverwrite:{MainEnginesRollPercentOverwrite}"),
            new TelemetryMessage($"MainEnginesPitchPercentOverwrite:{MainEnginesPitchPercentOverwrite}"),
            new TelemetryMessage($"FlapsActuationProportionalGain:{FlapsActuationProportionalGain}"),
            new TelemetryMessage($"FlapsActuationIntegralGain:{FlapsActuationIntegralGain}"),
            new TelemetryMessage($"FlapsActuationDerivativeGain:{FlapsActuationDerivativeGain}"),
            new TelemetryMessage($"TopLeftFlapDeployPercentOverwrite:{TopLeftFlapDeployPercentOverwrite}"),
            new TelemetryMessage($"TopRightFlapDeployPercentOverwrite:{TopRightFlapDeployPercentOverwrite}"),
            new TelemetryMessage($"BottomLeftFlapDeployPercentOverwrite:{BottomLeftFlapDeployPercentOverwrite}"),
            new TelemetryMessage($"BottomRightFlapDeployPercentOverwrite:{BottomRightFlapDeployPercentOverwrite}"),
            new TelemetryMessage($"LegsActuationExtendedState:{LegsActuationExtendedState}")
        };
    }
}