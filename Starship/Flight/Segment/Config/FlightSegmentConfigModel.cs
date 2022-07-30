namespace Starship.Flight.Segment.Config
{
    public sealed class FlightSegmentConfigModel
    {
        public float? HandoverVerticalVelocityInMetrePerSecondEqualOrOver;
        public float? HandoverVerticalVelocityInMetrePerSecondEqualOrUnder;

        public float? HandoverYawAngleInDegreesEqualOrOver;
        public float? HandoverYawAngleInDegreesEqualOrUnder;

        public float? HandoverRollAngleInDegreesEqualOrOver;
        public float? HandoverRollAngleInDegreesEqualOrUnder;

        public float? HandoverPitchAngleInDegreesEqualOrOver;
        public float? HandoverPitchAngleInDegreesEqualOrUnder;

        public float? HandoverAltitudeInMetersEqualOrOver;
        public float? HandoverAltitudeInMetersEqualOrUnder;

        public float DesiredVerticalVelocityInMetrePerSecond;

        public float MainEnginesThrottleProportionalGain;
        public float MainEnginesThrottleIntegralGain;
        public float MainEnginesThrottleDerivativeGain;

        public float? TopMainEngineThrottlePercentOverwrite;
        public float? BottomLeftMainEngineThrottlePercentOverwrite;
        public float? BottomRightMainEngineThrottlePercentOverwrite;

        public float DesiredYawAngleInDegrees;
        public float DesiredRollAngleInDegrees;
        public float DesiredPitchAngleInDegrees;

        public float MainEnginesGimbalProportionalGain;
        public float MainEnginesGimbalIntegralGain;
        public float MainEnginesGimbalDerivativeGain;

        public float? MainEnginesYawPercentOverwrite;
        public float? MainEnginesRollPercentOverwrite;
        public float? MainEnginesPitchPercentOverwrite;

        public float FlapsActuationProportionalGain;
        public float FlapsActuationIntegralGain;
        public float FlapsActuationDerivativeGain;

        public float? TopLeftFlapDeployPercentOverwrite;
        public float? TopRightFlapDeployPercentOverwrite;
        public float? BottomLeftFlapDeployPercentOverwrite;
        public float? BottomRightFlapDeployPercentOverwrite;

        public bool LegsActuationExtendedState;
    }
}