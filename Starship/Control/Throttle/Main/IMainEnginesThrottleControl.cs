using Starship.Flight.Command.Throttle.Main;

namespace Starship.Control.Throttle.Main
{
    public interface IMainEnginesThrottleControl
    {
        void ThrottleMainEngines(
            TopMainEngineThrottleCommand topMainEngineThrottleCommand,
            BottomLeftMainEngineThrottleCommand bottomLeftMainEngineThrottleCommand,
            BottomRightMainEngineThrottleCommand bottomRightMainEngineThrottleCommand);
    }
}