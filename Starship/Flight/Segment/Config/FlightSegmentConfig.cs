using System.Collections.Generic;
using Starship.Telemetry;

namespace Starship.Flight.Segment.Config
{
    // Currently under development
    public readonly struct FlightSegmentConfig : ITelemetryProvider
    {
        public float? HandoverYawAngleInDegreesEqualOrOver { get; }
        public float? HandoverYawAngleInDegreesEqualOrUnder { get; }
        public float? HandoverRollAngleInDegreesEqualOrOver { get; }
        public float? HandoverRollAngleInDegreesEqualOrUnder { get; }
        public float? HandoverPitchAngleInDegreesEqualOrOver { get; }
        public float? HandoverPitchAngleInDegreesEqualOrUnder { get; }

        public float? HandoverAltitudeAboveTerrainInMetersEqualOrOver { get; }
        public float? HandoverAltitudeAboveTerrainInMetersEqualOrUnder { get; }

        public float? HandoverLateralVelocityInMetrePerSecondEqualOrOver { get; }
        public float? HandoverLateralVelocityInMetrePerSecondEqualOrUnder { get; }
        public float? HandoverVerticalVelocityInMetrePerSecondEqualOrOver { get; }
        public float? HandoverVerticalVelocityInMetrePerSecondEqualOrUnder { get; }
        public float? HandoverHorizontalVelocityInMetrePerSecondEqualOrOver { get; }
        public float? HandoverHorizontalVelocityInMetrePerSecondEqualOrUnder { get; }

        public bool DesiredLegsExtendedState { get; }

        public float DesiredYawAngleInDegrees { get; }
        public float DesiredRollAngleInDegrees { get; }
        public float DesiredPitchAngleInDegrees { get; }

        public float? DesiredLateralVelocityInMetrePerSecond { get; }
        public float? DesiredVerticalVelocityInMetrePerSecond { get; }
        public float? DesiredHorizontalVelocityInMetrePerSecond { get; }

        public float? TopLeftFlapDeployPercentOverwrite { get; }
        public float? TopRightFlapDeployPercentOverwrite { get; }
        public float? BottomLeftFlapDeployPercentOverwrite { get; }
        public float? BottomRightFlapDeployPercentOverwrite { get; }

        public float? MainEnginesYawPercentOverwrite { get; }
        public float? MainEnginesRollPercentOverwrite { get; }
        public float? MainEnginesPitchPercentOverwrite { get; }

        public float? TopMainEngineThrottlePercentOverwrite { get; }
        public float? BottomLeftMainEngineThrottlePercentOverwrite { get; }
        public float? BottomRightMainEngineThrottlePercentOverwrite { get; }

        public float? FlapsActuationPidRegulatorProportionalGain { get; }
        public float? FlapsActuationPidRegulatorIntegralGain { get; }
        public float? FlapsActuationPidRegulatorDerivativeGain { get; }

        public float? MainEnginesGimbalPidRegulatorProportionalGain { get; }
        public float? MainEnginesGimbalPidRegulatorIntegralGain { get; }
        public float? MainEnginesGimbalPidRegulatorDerivativeGain { get; }

        public float? LateralVelocityOffsetPidRegulatorProportionalGain { get; }
        public float? LateralVelocityOffsetPidRegulatorIntegralGain { get; }
        public float? LateralVelocityOffsetPidRegulatorDerivativeGain { get; }

        public float? MainEnginesThrottlePidRegulatorProportionalGain { get; }
        public float? MainEnginesThrottlePidRegulatorIntegralGain { get; }
        public float? MainEnginesThrottlePidRegulatorDerivativeGain { get; }

        public float? HorizontalVelocityOffsetPidRegulatorProportionalGain { get; }
        public float? HorizontalVelocityOffsetPidRegulatorIntegralGain { get; }
        public float? HorizontalVelocityOffsetPidRegulatorDerivativeGain { get; }


        public FlightSegmentConfig(
            float? handoverYawAngleInDegreesEqualOrOver,
            float? handoverYawAngleInDegreesEqualOrUnder,
            float? handoverRollAngleInDegreesEqualOrOver,
            float? handoverRollAngleInDegreesEqualOrUnder,
            float? handoverPitchAngleInDegreesEqualOrOver,
            float? handoverPitchAngleInDegreesEqualOrUnder,
            float? handoverAltitudeAboveTerrainInMetersEqualOrOver,
            float? handoverAltitudeAboveTerrainInMetersEqualOrUnder,
            float? handoverLateralVelocityInMetrePerSecondEqualOrOver,
            float? handoverLateralVelocityInMetrePerSecondEqualOrUnder,
            float? handoverVerticalVelocityInMetrePerSecondEqualOrOver,
            float? handoverVerticalVelocityInMetrePerSecondEqualOrUnder,
            float? handoverHorizontalVelocityInMetrePerSecondEqualOrOver,
            float? handoverHorizontalVelocityInMetrePerSecondEqualOrUnder,
            bool desiredLegsExtendedState,
            float desiredYawAngleInDegrees,
            float desiredRollAngleInDegrees,
            float desiredPitchAngleInDegrees,
            float? desiredLateralVelocityInMetrePerSecond,
            float? desiredVerticalVelocityInMetrePerSecond,
            float? desiredHorizontalVelocityInMetrePerSecond,
            float? topLeftFlapDeployPercentOverwrite,
            float? topRightFlapDeployPercentOverwrite,
            float? bottomLeftFlapDeployPercentOverwrite,
            float? bottomRightFlapDeployPercentOverwrite,
            float? mainEnginesYawPercentOverwrite,
            float? mainEnginesRollPercentOverwrite,
            float? mainEnginesPitchPercentOverwrite,
            float? topMainEngineThrottlePercentOverwrite,
            float? bottomLeftMainEngineThrottlePercentOverwrite,
            float? bottomRightMainEngineThrottlePercentOverwrite,
            float? flapsActuationPidRegulatorProportionalGain,
            float? flapsActuationPidRegulatorIntegralGain,
            float? flapsActuationPidRegulatorDerivativeGain,
            float? mainEnginesGimbalPidRegulatorProportionalGain,
            float? mainEnginesGimbalPidRegulatorIntegralGain,
            float? mainEnginesGimbalPidRegulatorDerivativeGain,
            float? lateralVelocityOffsetPidRegulatorProportionalGain,
            float? lateralVelocityOffsetPidRegulatorIntegralGain,
            float? lateralVelocityOffsetPidRegulatorDerivativeGain,
            float? mainEnginesThrottlePidRegulatorProportionalGain,
            float? mainEnginesThrottlePidRegulatorIntegralGain,
            float? mainEnginesThrottlePidRegulatorDerivativeGain,
            float? horizontalVelocityOffsetPidRegulatorProportionalGain,
            float? horizontalVelocityOffsetPidRegulatorIntegralGain,
            float? horizontalVelocityOffsetPidRegulatorDerivativeGain)
        {
            HandoverYawAngleInDegreesEqualOrOver = handoverYawAngleInDegreesEqualOrOver;
            HandoverYawAngleInDegreesEqualOrUnder = handoverYawAngleInDegreesEqualOrUnder;
            HandoverRollAngleInDegreesEqualOrOver = handoverRollAngleInDegreesEqualOrOver;
            HandoverRollAngleInDegreesEqualOrUnder = handoverRollAngleInDegreesEqualOrUnder;
            HandoverPitchAngleInDegreesEqualOrOver = handoverPitchAngleInDegreesEqualOrOver;
            HandoverPitchAngleInDegreesEqualOrUnder = handoverPitchAngleInDegreesEqualOrUnder;
            HandoverAltitudeAboveTerrainInMetersEqualOrOver = handoverAltitudeAboveTerrainInMetersEqualOrOver;
            HandoverAltitudeAboveTerrainInMetersEqualOrUnder = handoverAltitudeAboveTerrainInMetersEqualOrUnder;
            HandoverLateralVelocityInMetrePerSecondEqualOrOver = handoverLateralVelocityInMetrePerSecondEqualOrOver;
            HandoverLateralVelocityInMetrePerSecondEqualOrUnder = handoverLateralVelocityInMetrePerSecondEqualOrUnder;
            HandoverVerticalVelocityInMetrePerSecondEqualOrOver = handoverVerticalVelocityInMetrePerSecondEqualOrOver;
            HandoverVerticalVelocityInMetrePerSecondEqualOrUnder = handoverVerticalVelocityInMetrePerSecondEqualOrUnder;
            HandoverHorizontalVelocityInMetrePerSecondEqualOrOver = handoverHorizontalVelocityInMetrePerSecondEqualOrOver;
            HandoverHorizontalVelocityInMetrePerSecondEqualOrUnder = handoverHorizontalVelocityInMetrePerSecondEqualOrUnder;
            DesiredLegsExtendedState = desiredLegsExtendedState;
            DesiredYawAngleInDegrees = desiredYawAngleInDegrees;
            DesiredRollAngleInDegrees = desiredRollAngleInDegrees;
            DesiredPitchAngleInDegrees = desiredPitchAngleInDegrees;
            DesiredLateralVelocityInMetrePerSecond = desiredLateralVelocityInMetrePerSecond;
            DesiredVerticalVelocityInMetrePerSecond = desiredVerticalVelocityInMetrePerSecond;
            DesiredHorizontalVelocityInMetrePerSecond = desiredHorizontalVelocityInMetrePerSecond;
            TopLeftFlapDeployPercentOverwrite = topLeftFlapDeployPercentOverwrite;
            TopRightFlapDeployPercentOverwrite = topRightFlapDeployPercentOverwrite;
            BottomLeftFlapDeployPercentOverwrite = bottomLeftFlapDeployPercentOverwrite;
            BottomRightFlapDeployPercentOverwrite = bottomRightFlapDeployPercentOverwrite;
            MainEnginesYawPercentOverwrite = mainEnginesYawPercentOverwrite;
            MainEnginesRollPercentOverwrite = mainEnginesRollPercentOverwrite;
            MainEnginesPitchPercentOverwrite = mainEnginesPitchPercentOverwrite;
            TopMainEngineThrottlePercentOverwrite = topMainEngineThrottlePercentOverwrite;
            BottomLeftMainEngineThrottlePercentOverwrite = bottomLeftMainEngineThrottlePercentOverwrite;
            BottomRightMainEngineThrottlePercentOverwrite = bottomRightMainEngineThrottlePercentOverwrite;
            FlapsActuationPidRegulatorProportionalGain = flapsActuationPidRegulatorProportionalGain;
            FlapsActuationPidRegulatorIntegralGain = flapsActuationPidRegulatorIntegralGain;
            FlapsActuationPidRegulatorDerivativeGain = flapsActuationPidRegulatorDerivativeGain;
            MainEnginesGimbalPidRegulatorProportionalGain = mainEnginesGimbalPidRegulatorProportionalGain;
            MainEnginesGimbalPidRegulatorIntegralGain = mainEnginesGimbalPidRegulatorIntegralGain;
            MainEnginesGimbalPidRegulatorDerivativeGain = mainEnginesGimbalPidRegulatorDerivativeGain;
            LateralVelocityOffsetPidRegulatorProportionalGain = lateralVelocityOffsetPidRegulatorProportionalGain;
            LateralVelocityOffsetPidRegulatorIntegralGain = lateralVelocityOffsetPidRegulatorIntegralGain;
            LateralVelocityOffsetPidRegulatorDerivativeGain = lateralVelocityOffsetPidRegulatorDerivativeGain;
            MainEnginesThrottlePidRegulatorProportionalGain = mainEnginesThrottlePidRegulatorProportionalGain;
            MainEnginesThrottlePidRegulatorIntegralGain = mainEnginesThrottlePidRegulatorIntegralGain;
            MainEnginesThrottlePidRegulatorDerivativeGain = mainEnginesThrottlePidRegulatorDerivativeGain;
            HorizontalVelocityOffsetPidRegulatorProportionalGain = horizontalVelocityOffsetPidRegulatorProportionalGain;
            HorizontalVelocityOffsetPidRegulatorIntegralGain = horizontalVelocityOffsetPidRegulatorIntegralGain;
            HorizontalVelocityOffsetPidRegulatorDerivativeGain = horizontalVelocityOffsetPidRegulatorDerivativeGain;
        }

        public IEnumerable<TelemetryMessage> ProvideTelemetry() => new List<TelemetryMessage>
        {
            new TelemetryMessage($"HandoverYawAngleInDegreesEqualOrOver:{HandoverYawAngleInDegreesEqualOrOver}"),
            new TelemetryMessage($"HandoverYawAngleInDegreesEqualOrUnder:{HandoverYawAngleInDegreesEqualOrUnder}"),
            new TelemetryMessage($"HandoverRollAngleInDegreesEqualOrOver:{HandoverRollAngleInDegreesEqualOrOver}"),
            new TelemetryMessage($"HandoverRollAngleInDegreesEqualOrUnder:{HandoverRollAngleInDegreesEqualOrUnder}"),
            new TelemetryMessage($"HandoverPitchAngleInDegreesEqualOrOver:{HandoverPitchAngleInDegreesEqualOrOver}"),
            new TelemetryMessage($"HandoverPitchAngleInDegreesEqualOrUnder:{HandoverPitchAngleInDegreesEqualOrUnder}"),
            new TelemetryMessage($"HandoverAltitudeAboveTerrainInMetersEqualOrOver:{HandoverAltitudeAboveTerrainInMetersEqualOrOver}"),
            new TelemetryMessage($"HandoverAltitudeAboveTerrainInMetersEqualOrUnder:{HandoverAltitudeAboveTerrainInMetersEqualOrUnder}"),
            new TelemetryMessage($"HandoverLateralVelocityInMetrePerSecondEqualOrOver:{HandoverLateralVelocityInMetrePerSecondEqualOrOver}"),
            new TelemetryMessage($"HandoverLateralVelocityInMetrePerSecondEqualOrUnder:{HandoverLateralVelocityInMetrePerSecondEqualOrUnder}"),
            new TelemetryMessage($"HandoverVerticalVelocityInMetrePerSecondEqualOrOver:{HandoverVerticalVelocityInMetrePerSecondEqualOrOver}"),
            new TelemetryMessage($"HandoverVerticalVelocityInMetrePerSecondEqualOrUnder:{HandoverVerticalVelocityInMetrePerSecondEqualOrUnder}"),
            new TelemetryMessage($"HandoverHorizontalVelocityInMetrePerSecondEqualOrOver:{HandoverHorizontalVelocityInMetrePerSecondEqualOrOver}"),
            new TelemetryMessage($"HandoverHorizontalVelocityInMetrePerSecondEqualOrUnder:{HandoverHorizontalVelocityInMetrePerSecondEqualOrUnder}"),
            new TelemetryMessage($"DesiredLegsExtendedState:{DesiredLegsExtendedState}"),
            new TelemetryMessage($"DesiredYawAngleInDegrees:{DesiredYawAngleInDegrees}"),
            new TelemetryMessage($"DesiredRollAngleInDegrees:{DesiredRollAngleInDegrees}"),
            new TelemetryMessage($"DesiredPitchAngleInDegrees:{DesiredPitchAngleInDegrees}"),
            new TelemetryMessage($"DesiredLateralVelocityInMetrePerSecond:{DesiredLateralVelocityInMetrePerSecond}"),
            new TelemetryMessage($"DesiredVerticalVelocityInMetrePerSecond:{DesiredVerticalVelocityInMetrePerSecond}"),
            new TelemetryMessage($"DesiredHorizontalVelocityInMetrePerSecond:{DesiredHorizontalVelocityInMetrePerSecond}"),
            new TelemetryMessage($"TopLeftFlapDeployPercentOverwrite:{TopLeftFlapDeployPercentOverwrite}"),
            new TelemetryMessage($"TopRightFlapDeployPercentOverwrite:{TopRightFlapDeployPercentOverwrite}"),
            new TelemetryMessage($"BottomLeftFlapDeployPercentOverwrite:{BottomLeftFlapDeployPercentOverwrite}"),
            new TelemetryMessage($"BottomRightFlapDeployPercentOverwrite:{BottomRightFlapDeployPercentOverwrite}"),
            new TelemetryMessage($"MainEnginesYawPercentOverwrite:{MainEnginesYawPercentOverwrite}"),
            new TelemetryMessage($"MainEnginesRollPercentOverwrite:{MainEnginesRollPercentOverwrite}"),
            new TelemetryMessage($"MainEnginesPitchPercentOverwrite:{MainEnginesPitchPercentOverwrite}"),
            new TelemetryMessage($"TopMainEngineThrottlePercentOverwrite:{TopMainEngineThrottlePercentOverwrite}"),
            new TelemetryMessage($"BottomLeftMainEngineThrottlePercentOverwrite:{BottomLeftMainEngineThrottlePercentOverwrite}"),
            new TelemetryMessage($"BottomRightMainEngineThrottlePercentOverwrite:{BottomRightMainEngineThrottlePercentOverwrite}"),
            new TelemetryMessage($"FlapsActuationPidRegulatorProportionalGain:{FlapsActuationPidRegulatorProportionalGain}"),
            new TelemetryMessage($"FlapsActuationPidRegulatorIntegralGain:{FlapsActuationPidRegulatorIntegralGain}"),
            new TelemetryMessage($"FlapsActuationPidRegulatorDerivativeGain:{FlapsActuationPidRegulatorDerivativeGain}"),
            new TelemetryMessage($"MainEnginesGimbalPidRegulatorProportionalGain:{MainEnginesGimbalPidRegulatorProportionalGain}"),
            new TelemetryMessage($"MainEnginesGimbalPidRegulatorIntegralGain:{MainEnginesGimbalPidRegulatorIntegralGain}"),
            new TelemetryMessage($"MainEnginesGimbalPidRegulatorDerivativeGain:{MainEnginesGimbalPidRegulatorDerivativeGain}"),
            new TelemetryMessage($"LateralVelocityOffsetPidRegulatorProportionalGain:{LateralVelocityOffsetPidRegulatorProportionalGain}"),
            new TelemetryMessage($"LateralVelocityOffsetPidRegulatorIntegralGain:{LateralVelocityOffsetPidRegulatorIntegralGain}"),
            new TelemetryMessage($"LateralVelocityOffsetPidRegulatorDerivativeGain:{LateralVelocityOffsetPidRegulatorDerivativeGain}"),
            new TelemetryMessage($"MainEnginesThrottlePidRegulatorProportionalGain:{MainEnginesThrottlePidRegulatorProportionalGain}"),
            new TelemetryMessage($"MainEnginesThrottlePidRegulatorIntegralGain:{MainEnginesThrottlePidRegulatorIntegralGain}"),
            new TelemetryMessage($"MainEnginesThrottlePidRegulatorDerivativeGain:{MainEnginesThrottlePidRegulatorDerivativeGain}"),
            new TelemetryMessage($"HorizontalVelocityOffsetPidRegulatorProportionalGain:{HorizontalVelocityOffsetPidRegulatorProportionalGain}"),
            new TelemetryMessage($"HorizontalVelocityOffsetPidRegulatorIntegralGain:{HorizontalVelocityOffsetPidRegulatorIntegralGain}"),
            new TelemetryMessage($"HorizontalVelocityOffsetPidRegulatorDerivativeGain:{HorizontalVelocityOffsetPidRegulatorDerivativeGain}")
        };
    }
}