namespace Starship.Utility.Timing
{
    public interface IStopwatch
    {
        bool IsRunning { get; }


        void Restart();

        long GetElapsedMilliseconds();
    }
}