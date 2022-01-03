using Starship.Flight.Command.Throttle.Rcs;

namespace Starship.Control.Throttle.Rcs
{
    public interface IRcsEnginesThrottleControl
    {
        void ThrottleRcsEngines(
            ThrottleTopLeftRcsEngineCommand throttleTopLeftRcsEngineCommand,
            ThrottleTopRightRcsEngineCommand throttleTopRightRcsEngineCommand,
            ThrottleBottomLeftRcsEngineCommand throttleBottomLeftRcsEngineCommand,
            ThrottleBottomRightRcsEngineCommand throttleBottomRightRcsEngineCommand);
    }
}