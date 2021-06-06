namespace Starship.Utility.Timing
{
    public sealed class Stopwatch : IStopwatch
    {
        private readonly System.Diagnostics.Stopwatch _stopwatch;


        public Stopwatch(System.Diagnostics.Stopwatch stopwatch)
        {
            _stopwatch = stopwatch;
        }

        public void Restart() => _stopwatch.Restart();

        public long GetElapsedMilliseconds() => _stopwatch.ElapsedMilliseconds;
    }
}