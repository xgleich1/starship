namespace Starship.Flight.Segment.Config
{
    public sealed class FlightSegmentConfigModel
    {
        public long TakeoverSecondsInMission;

        public float DesiredVerticalVelocityInMetrePerSecond;

        public float ThrottleTopMainEngineProportionalGain;
        public float ThrottleBottomLeftMainEngineProportionalGain;
        public float ThrottleBottomRightMainEngineProportionalGain;

        public float? TopMainEngineThrottlePercentOverwrite;
        public float? BottomLeftMainEngineThrottlePercentOverwrite;
        public float? BottomRightMainEngineThrottlePercentOverwrite;

        public float DesiredYawAngleInDegrees;
        public float DesiredRollAngleInDegrees;
        public float DesiredPitchAngleInDegrees;

        public float YawWithMainEnginesProportionalGain;
        public float RollWithMainEnginesProportionalGain;
        public float PitchWithMainEnginesProportionalGain;

        public float? MainEnginesYawPercentOverwrite;
        public float? MainEnginesRollPercentOverwrite;
        public float? MainEnginesPitchPercentOverwrite;

        public float YawWithFlapsProportionalGain;
        public float RollWithFlapsProportionalGain;
        public float PitchWithFlapsProportionalGain;

        public float? TopLeftFlapDeployPercentOverwrite;
        public float? TopRightFlapDeployPercentOverwrite;
        public float? BottomLeftFlapDeployPercentOverwrite;
        public float? BottomRightFlapDeployPercentOverwrite;
    }
}