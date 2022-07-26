using System.Collections.Generic;
using Starship.Telemetry;

namespace Starship.Flight.Segment.Config
{
    // Currently under development
    public readonly struct FlightSegmentConfig : IFlightSegmentConfig
    {
        // public float? TakeoverVerticalVelocityEqual { get; }
        //
        // public float? TakeoverVerticalVelocityTollerance { get; }
        public float? TakeoverVerticalVelocityEqualOrOver { get; }
        public float? TakeoverVerticalVelocityEqualOrUnder { get; }
        
        public float? TakeoverYawAngleEqualOrOver { get; }
        public float? TakeoverYawAngleEqualOrUnder { get; }

        public float? TakeoverRollAngleEqualOrOver { get; }
        public float? TakeoverRollAngleEqualOrUnder { get; }

        public float? TakeoverPitchAngleEqualOrOver { get; }
        public float? TakeoverPitchAngleEqualOrUnder { get; }

        public float? TakeoverAltitudeEqualOrOver { get; }
        public float? TakeoverAltitudeEqualOrUnder { get; }

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
            float? takeoverVerticalVelocityEqualOrOver,
            float? takeoverVerticalVelocityEqualOrUnder,
            float? takeoverYawAngleEqualOrOver,
            float? takeoverYawAngleEqualOrUnder,
            float? takeoverRollAngleEqualOrOver,
            float? takeoverRollAngleEqualOrUnder,
            float? takeoverPitchAngleEqualOrOver,
            float? takeoverPitchAngleEqualOrUnder,
            float? takeoverAltitudeEqualOrOver,
            float? takeoverAltitudeEqualOrUnder,
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
            TakeoverVerticalVelocityEqualOrOver = takeoverVerticalVelocityEqualOrOver;
            TakeoverVerticalVelocityEqualOrUnder = takeoverVerticalVelocityEqualOrUnder;
            TakeoverYawAngleEqualOrOver = takeoverYawAngleEqualOrOver;
            TakeoverYawAngleEqualOrUnder = takeoverYawAngleEqualOrUnder;
            TakeoverRollAngleEqualOrOver = takeoverRollAngleEqualOrOver;
            TakeoverRollAngleEqualOrUnder = takeoverRollAngleEqualOrUnder;
            TakeoverPitchAngleEqualOrOver = takeoverPitchAngleEqualOrOver;
            TakeoverPitchAngleEqualOrUnder = takeoverPitchAngleEqualOrUnder;
            TakeoverAltitudeEqualOrOver = takeoverAltitudeEqualOrOver;
            TakeoverAltitudeEqualOrUnder = takeoverAltitudeEqualOrUnder;
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
            new TelemetryMessage($"TakeoverVerticalVelocityEqualOrOver:{TakeoverVerticalVelocityEqualOrOver}"),
            new TelemetryMessage($"TakeoverVerticalVelocityEqualOrUnder:{TakeoverVerticalVelocityEqualOrUnder}"),
            new TelemetryMessage($"TakeoverYawAngleEqualOrOver:{TakeoverYawAngleEqualOrOver}"),
            new TelemetryMessage($"TakeoverYawAngleEqualOrUnder:{TakeoverYawAngleEqualOrUnder}"),
            new TelemetryMessage($"TakeoverRollAngleEqualOrOver:{TakeoverRollAngleEqualOrOver}"),
            new TelemetryMessage($"TakeoverRollAngleEqualOrUnder:{TakeoverRollAngleEqualOrUnder}"),
            new TelemetryMessage($"TakeoverPitchAngleEqualOrOver:{TakeoverPitchAngleEqualOrOver}"),
            new TelemetryMessage($"TakeoverPitchAngleEqualOrUnder:{TakeoverPitchAngleEqualOrUnder}"),
            new TelemetryMessage($"TakeoverAltitudeEqualOrOver:{TakeoverAltitudeEqualOrOver}"),
            new TelemetryMessage($"TakeoverAltitudeEqualOrUnder:{TakeoverAltitudeEqualOrUnder}"),
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