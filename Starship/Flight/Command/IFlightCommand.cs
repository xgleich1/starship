using static Starship.Flight.Command.AttitudeCommand;
using static Starship.Flight.Command.ThrottleCommand;

namespace Starship.Flight.Command
{
    // Currently under development
    public interface IFlightCommand
    {
        TopLeftRcsEngineThrottle TopLeftRcsEngineThrottle { get; }
        TopRightRcsEngineThrottle TopRightRcsEngineThrottle { get; }
        BottomLeftRcsEngineThrottle BottomLeftRcsEngineThrottle { get; }
        BottomRightRcsEngineThrottle BottomRightRcsEngineThrottle { get; }
        TopMainEngineThrottle TopMainEngineThrottle { get; }
        BottomLeftMainEngineThrottle BottomLeftMainEngineThrottle { get; }
        BottomRightMainEngineThrottle BottomRightMainEngineThrottle { get; }
        MainEngineAttitudeYaw MainEngineAttitudeYaw { get; }
        MainEngineAttitudeRoll MainEngineAttitudeRoll { get; }
        MainEngineAttitudePitch MainEngineAttitudePitch { get; }
    }
}