using Starship.Flight.Command.Throttle.Rcs;

namespace Starship.Control.Throttle.Rcs
{
    public interface IRcsEnginesThrottleControl
    {
        void ControlRcsEnginesThrottle(
            TopLeftRcsEngineThrottleCommand topLeftRcsEngineThrottleCommand,
            TopRightRcsEngineThrottleCommand topRightRcsEngineThrottleCommand,
            BottomLeftRcsEngineThrottleCommand bottomLeftRcsEngineThrottleCommand,
            BottomRightRcsEngineThrottleCommand bottomRightRcsEngineThrottleCommand);
    }
}