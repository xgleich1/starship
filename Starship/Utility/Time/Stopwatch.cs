namespace Starship.Utility.Time
{
    public sealed class Stopwatch : IStopwatch
    {
        public bool IsRunning => _stopwatch.IsRunning;

        private readonly System.Diagnostics.Stopwatch _stopwatch =
            new System.Diagnostics.Stopwatch();


        public void Restart() => _stopwatch.Restart();

        public long GetElapsedMilliseconds() => _stopwatch.ElapsedMilliseconds;
    }
}