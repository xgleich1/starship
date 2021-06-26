namespace Starship.Flight
{
    // Currently under development
    public readonly struct FlightCommand
    {
        // TODO: Strongly type and clamp values
        public float TopLeftRcsThrottle { get; }
        public float TopRightRcsThrottle { get; }
        public float BottomLeftRcsThrottle { get; }
        public float BottomRightRcsThrottle { get; }
        public float TopMainEngineThrottle { get; }
        public float BottomLeftMainEngineThrottle { get; }
        public float BottomRightMainEngineThrottle { get; }
        public float MainEngineGimbalYaw { get; }
        public float MainEngineGimbalRoll { get; }
        public float MainEngineGimbalPitch { get; }


        public FlightCommand(
            float topLeftRcsThrottle,
            float topRightRcsThrottle,
            float bottomLeftRcsThrottle,
            float bottomRightRcsThrottle,
            float topMainEngineThrottle,
            float bottomLeftMainEngineThrottle,
            float bottomRightMainEngineThrottle,
            float mainEngineGimbalYaw,
            float mainEngineGimbalRoll,
            float mainEngineGimbalPitch)
        {
            TopLeftRcsThrottle = topLeftRcsThrottle;
            TopRightRcsThrottle = topRightRcsThrottle;
            BottomLeftRcsThrottle = bottomLeftRcsThrottle;
            BottomRightRcsThrottle = bottomRightRcsThrottle;
            TopMainEngineThrottle = topMainEngineThrottle;
            BottomLeftMainEngineThrottle = bottomLeftMainEngineThrottle;
            BottomRightMainEngineThrottle = bottomRightMainEngineThrottle;
            MainEngineGimbalYaw = mainEngineGimbalYaw;
            MainEngineGimbalRoll = mainEngineGimbalRoll;
            MainEngineGimbalPitch = mainEngineGimbalPitch;
        }
    }
}