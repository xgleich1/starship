using Starship.Flight.Command;

namespace Starship.Control.RcsEnginesThrottle
{
    public interface IRcsEnginesThrottleControl
    {
        void ControlRcsEnginesThrottle(IFlightCommand flightCommand);
    }
}