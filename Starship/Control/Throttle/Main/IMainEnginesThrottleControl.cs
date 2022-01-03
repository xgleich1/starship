using Starship.Flight.Command.Throttle.Main;

namespace Starship.Control.Throttle.Main
{
    public interface IMainEnginesThrottleControl
    {
        void ThrottleMainEngines(
            ThrottleTopMainEngineCommand throttleTopMainEngineCommand,
            ThrottleBottomLeftMainEngineCommand throttleBottomLeftMainEngineCommand,
            ThrottleBottomRightMainEngineCommand throttleBottomRightMainEngineCommand);
    }
}