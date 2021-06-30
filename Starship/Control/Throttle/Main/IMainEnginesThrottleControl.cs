using Starship.Flight.Command;

namespace Starship.Control.Throttle.Main
{
    public interface IMainEnginesThrottleControl
    {
        void ControlMainEnginesThrottle(ICommandSuite commandSuite);
    }
}