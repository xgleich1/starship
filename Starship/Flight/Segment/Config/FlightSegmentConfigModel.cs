namespace Starship.Flight.Segment.Config
{
    public sealed class FlightSegmentConfigModel
    {
        public float? HandoverYawAngleInDegreesEqualOrOver;
        public float? HandoverYawAngleInDegreesEqualOrUnder;
        public float? HandoverRollAngleInDegreesEqualOrOver;
        public float? HandoverRollAngleInDegreesEqualOrUnder;
        public float? HandoverPitchAngleInDegreesEqualOrOver;
        public float? HandoverPitchAngleInDegreesEqualOrUnder;

        public float? HandoverAltitudeAboveTerrainInMetersEqualOrOver;
        public float? HandoverAltitudeAboveTerrainInMetersEqualOrUnder;

        public float? HandoverLateralVelocityInMetrePerSecondEqualOrOver;
        public float? HandoverLateralVelocityInMetrePerSecondEqualOrUnder;
        public float? HandoverVerticalVelocityInMetrePerSecondEqualOrOver;
        public float? HandoverVerticalVelocityInMetrePerSecondEqualOrUnder;
        public float? HandoverHorizontalVelocityInMetrePerSecondEqualOrOver;
        public float? HandoverHorizontalVelocityInMetrePerSecondEqualOrUnder;

        public bool DesiredLegsExtendedState;

        public float DesiredYawAngleInDegrees;
        public float DesiredRollAngleInDegrees;
        public float DesiredPitchAngleInDegrees;

        public float? DesiredLateralVelocityInMetrePerSecond;
        public float? DesiredVerticalVelocityInMetrePerSecond;
        public float? DesiredHorizontalVelocityInMetrePerSecond;

        public float? TopLeftFlapDeployPercentOverwrite;
        public float? TopRightFlapDeployPercentOverwrite;
        public float? BottomLeftFlapDeployPercentOverwrite;
        public float? BottomRightFlapDeployPercentOverwrite;

        public float? MainEnginesYawPercentOverwrite;
        public float? MainEnginesRollPercentOverwrite;
        public float? MainEnginesPitchPercentOverwrite;

        public float? TopMainEngineThrottlePercentOverwrite;
        public float? BottomLeftMainEngineThrottlePercentOverwrite;
        public float? BottomRightMainEngineThrottlePercentOverwrite;

        public float? FlapsActuationPidRegulatorProportionalGain;
        public float? FlapsActuationPidRegulatorIntegralGain;
        public float? FlapsActuationPidRegulatorDerivativeGain;

        public float? MainEnginesGimbalPidRegulatorProportionalGain;
        public float? MainEnginesGimbalPidRegulatorIntegralGain;
        public float? MainEnginesGimbalPidRegulatorDerivativeGain;

        public float? LateralVelocityOffsetPidRegulatorProportionalGain;
        public float? LateralVelocityOffsetPidRegulatorIntegralGain;
        public float? LateralVelocityOffsetPidRegulatorDerivativeGain;

        public float? MainEnginesThrottlePidRegulatorProportionalGain;
        public float? MainEnginesThrottlePidRegulatorIntegralGain;
        public float? MainEnginesThrottlePidRegulatorDerivativeGain;

        public float? HorizontalVelocityOffsetPidRegulatorProportionalGain;
        public float? HorizontalVelocityOffsetPidRegulatorIntegralGain;
        public float? HorizontalVelocityOffsetPidRegulatorDerivativeGain;
    }
}