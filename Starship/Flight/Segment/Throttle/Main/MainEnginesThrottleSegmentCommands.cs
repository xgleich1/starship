using Starship.Flight.Command.Throttle.Main;

namespace Starship.Flight.Segment.Throttle.Main
{
    public sealed class MainEnginesThrottleSegmentCommands
    {
        public TopMainEngineThrottleCommand TopMainEngineThrottleCommand { get; }
        public BottomLeftMainEngineThrottleCommand BottomLeftMainEngineThrottleCommand { get; }
        public BottomRightMainEngineThrottleCommand BottomRightMainEngineThrottleCommand { get; }


        public MainEnginesThrottleSegmentCommands(
            TopMainEngineThrottleCommand topMainEngineThrottleCommand,
            BottomLeftMainEngineThrottleCommand bottomLeftMainEngineThrottleCommand,
            BottomRightMainEngineThrottleCommand bottomRightMainEngineThrottleCommand)
        {
            TopMainEngineThrottleCommand = topMainEngineThrottleCommand;
            BottomLeftMainEngineThrottleCommand = bottomLeftMainEngineThrottleCommand;
            BottomRightMainEngineThrottleCommand = bottomRightMainEngineThrottleCommand;
        }
    }
}