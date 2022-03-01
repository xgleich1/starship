using Starship.Utility.Timing;
using Starship.Utility.Timing.Units;

namespace Starship.Mission
{
    public sealed class MissionTimer : IMissionTimer
    {
        public bool IsRunning => _stopwatch.IsRunning;

        private readonly IStopwatch _stopwatch;


        public MissionTimer(IStopwatch stopwatch) => _stopwatch = stopwatch;

        public void StartWithZeroSeconds() => _stopwatch.Restart();

        public Seconds GetElapsedSeconds() => new Seconds(_stopwatch.GetElapsedMilliseconds() / 1000L);
    }
}