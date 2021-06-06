namespace Starship.Utility.Timing
{
    public interface IStopwatch
    {
        void Restart();

        long GetElapsedMilliseconds();
    }
}