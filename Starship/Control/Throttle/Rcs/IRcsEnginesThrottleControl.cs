using Starship.Flight.Command;

namespace Starship.Control.Throttle.Rcs
{
    public interface IRcsEnginesThrottleControl
    {
        void ControlRcsEnginesThrottle(ICommandSuite commandSuite);
    }
}