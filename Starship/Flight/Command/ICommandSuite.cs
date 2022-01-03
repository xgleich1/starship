using Starship.Flight.Command.Actuation.Engine;
using Starship.Flight.Command.Actuation.Flap;
using Starship.Flight.Command.Throttle.Main;
using Starship.Flight.Command.Throttle.Rcs;
using Starship.Telemetry;

namespace Starship.Flight.Command
{
    public interface ICommandSuite : ITelemetryProvider
    {
        ThrottleTopLeftRcsEngineCommand ThrottleTopLeftRcsEngineCommand { get; }
        ThrottleTopRightRcsEngineCommand ThrottleTopRightRcsEngineCommand { get; }
        ThrottleBottomLeftRcsEngineCommand ThrottleBottomLeftRcsEngineCommand { get; }
        ThrottleBottomRightRcsEngineCommand ThrottleBottomRightRcsEngineCommand { get; }
        ThrottleTopMainEngineCommand ThrottleTopMainEngineCommand { get; }
        ThrottleBottomLeftMainEngineCommand ThrottleBottomLeftMainEngineCommand { get; }
        ThrottleBottomRightMainEngineCommand ThrottleBottomRightMainEngineCommand { get; }
        YawMainEnginesCommand YawMainEnginesCommand { get; }
        RollMainEnginesCommand RollMainEnginesCommand { get; }
        PitchMainEnginesCommand PitchMainEnginesCommand { get; }
        ActuateTopLeftFlapCommand ActuateTopLeftFlapCommand { get; }
        ActuateTopRightFlapCommand ActuateTopRightFlapCommand { get; }
        ActuateBottomLeftFlapCommand ActuateBottomLeftFlapCommand { get; }
        ActuateBottomRightFlapCommand ActuateBottomRightFlapCommand { get; }
    }
}