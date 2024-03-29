using Starship.Flight.Command.Activation.Rcs;
using Starship.Flight.Command.Actuation.Engine;
using Starship.Flight.Command.Actuation.Flap;
using Starship.Flight.Command.Actuation.Leg;
using Starship.Flight.Command.Throttle.Main;
using Starship.Telemetry;

namespace Starship.Flight.Command
{
    public interface ICommandSuite : ITelemetryProvider
    {
        TopLeftRcsActivationCommand TopLeftRcsActivationCommand { get; }
        TopRightRcsActivationCommand TopRightRcsActivationCommand { get; }
        BottomLeftRcsActivationCommand BottomLeftRcsActivationCommand { get; }
        BottomRightRcsActivationCommand BottomRightRcsActivationCommand { get; }
        LegsActuationCommand LegsActuationCommand { get; }
        TopLeftFlapActuationCommand TopLeftFlapActuationCommand { get; }
        TopRightFlapActuationCommand TopRightFlapActuationCommand { get; }
        BottomLeftFlapActuationCommand BottomLeftFlapActuationCommand { get; }
        BottomRightFlapActuationCommand BottomRightFlapActuationCommand { get; }
        MainEnginesYawCommand MainEnginesYawCommand { get; }
        MainEnginesRollCommand MainEnginesRollCommand { get; }
        MainEnginesPitchCommand MainEnginesPitchCommand { get; }
        TopMainEngineThrottleCommand TopMainEngineThrottleCommand { get; }
        BottomLeftMainEngineThrottleCommand BottomLeftMainEngineThrottleCommand { get; }
        BottomRightMainEngineThrottleCommand BottomRightMainEngineThrottleCommand { get; }
    }
}