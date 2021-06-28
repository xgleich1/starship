using Starship.Flight.Command;

namespace Starship.Control.MainEnginesThrottle
{
    public interface IMainEnginesThrottleControl
    {
        void ControlMainEnginesThrottle(IFlightCommand flightCommand);
    }
}