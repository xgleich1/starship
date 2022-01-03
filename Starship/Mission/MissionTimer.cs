using Starship.Utility.Timing;
using Starship.Utility.Timing.Units;

namespace Starship.Mission
{
    public sealed class MissionTimer : IMissionTimer
    {
        public bool IsRunning => _stopwatch.IsRunning;

        private readonly IStopwatch _stopwatch;


        public MissionTimer(IStopwatch stopwatch) => _stopwatch = stopwatch;

        // What happens when this method is called twice?
        // Emit telemetry? Return result code? Throw exception?
        public void StartWithZeroSeconds() => _stopwatch.Restart();

        // Is the precision loss due to the long division acceptable?
        public Seconds GetElapsedSeconds() =>
            new Seconds(_stopwatch.GetElapsedMilliseconds() / 1000L);
    }
}