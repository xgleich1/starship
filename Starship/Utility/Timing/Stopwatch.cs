namespace Starship.Utility.Timing
{
    public sealed class Stopwatch : IStopwatch
    {
        private readonly System.Diagnostics.Stopwatch _stopwatch =
            new System.Diagnostics.Stopwatch();


        public void Restart() => _stopwatch.Restart();

        public long GetElapsedMilliseconds() => _stopwatch.ElapsedMilliseconds;
    }
}