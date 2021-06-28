using static Starship.Flight.Command.AttitudeCommand;
using static Starship.Flight.Command.ThrottleCommand;

namespace Starship.Flight.Command
{
    // Currently under development
    public readonly struct FlightCommand : IFlightCommand
    {
        public TopLeftRcsEngineThrottle TopLeftRcsEngineThrottle { get; }
        public TopRightRcsEngineThrottle TopRightRcsEngineThrottle { get; }
        public BottomLeftRcsEngineThrottle BottomLeftRcsEngineThrottle { get; }
        public BottomRightRcsEngineThrottle BottomRightRcsEngineThrottle { get; }
        public TopMainEngineThrottle TopMainEngineThrottle { get; }
        public BottomLeftMainEngineThrottle BottomLeftMainEngineThrottle { get; }
        public BottomRightMainEngineThrottle BottomRightMainEngineThrottle { get; }
        public MainEngineAttitudeYaw MainEngineAttitudeYaw { get; }
        public MainEngineAttitudeRoll MainEngineAttitudeRoll { get; }
        public MainEngineAttitudePitch MainEngineAttitudePitch { get; }


        public FlightCommand(
            TopLeftRcsEngineThrottle topLeftRcsEngineThrottle,
            TopRightRcsEngineThrottle topRightRcsEngineThrottle,
            BottomLeftRcsEngineThrottle bottomLeftRcsEngineThrottle,
            BottomRightRcsEngineThrottle bottomRightRcsEngineThrottle,
            TopMainEngineThrottle topMainEngineThrottle,
            BottomLeftMainEngineThrottle bottomLeftMainEngineThrottle,
            BottomRightMainEngineThrottle bottomRightMainEngineThrottle,
            MainEngineAttitudeYaw mainEngineAttitudeYaw,
            MainEngineAttitudeRoll mainEngineAttitudeRoll,
            MainEngineAttitudePitch mainEngineAttitudePitch)
        {
            TopLeftRcsEngineThrottle = topLeftRcsEngineThrottle;
            TopRightRcsEngineThrottle = topRightRcsEngineThrottle;
            BottomLeftRcsEngineThrottle = bottomLeftRcsEngineThrottle;
            BottomRightRcsEngineThrottle = bottomRightRcsEngineThrottle;
            TopMainEngineThrottle = topMainEngineThrottle;
            BottomLeftMainEngineThrottle = bottomLeftMainEngineThrottle;
            BottomRightMainEngineThrottle = bottomRightMainEngineThrottle;
            MainEngineAttitudeYaw = mainEngineAttitudeYaw;
            MainEngineAttitudeRoll = mainEngineAttitudeRoll;
            MainEngineAttitudePitch = mainEngineAttitudePitch;
        }
    }
}