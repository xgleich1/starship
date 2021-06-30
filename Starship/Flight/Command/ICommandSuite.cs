using Starship.Flight.Command.Attitude;
using Starship.Flight.Command.Throttle.Main;
using Starship.Flight.Command.Throttle.Rcs;
using Starship.Telemetry;

namespace Starship.Flight.Command
{
    public interface ICommandSuite : ITelemetryProvider
    {
        TopLeftRcsEngineThrottleCommand TopLeftRcsEngineThrottleCommand { get; }
        TopRightRcsEngineThrottleCommand TopRightRcsEngineThrottleCommand { get; }
        BottomLeftRcsEngineThrottleCommand BottomLeftRcsEngineThrottleCommand { get; }
        BottomRightRcsEngineThrottleCommand BottomRightRcsEngineThrottleCommand { get; }
        TopMainEngineThrottleCommand TopMainEngineThrottleCommand { get; }
        BottomLeftMainEngineThrottleCommand BottomLeftMainEngineThrottleCommand { get; }
        BottomRightMainEngineThrottleCommand BottomRightMainEngineThrottleCommand { get; }
        MainEngineAttitudeYawCommand MainEngineAttitudeYawCommand { get; }
        MainEngineAttitudeRollCommand MainEngineAttitudeRollCommand { get; }
        MainEngineAttitudePitchCommand MainEngineAttitudePitchCommand { get; }
    }
}