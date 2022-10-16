namespace Starship.Utility.Time
{
    public interface IStopwatch
    {
        bool IsRunning { get; }


        void Restart();

        long GetElapsedMilliseconds();
    }
}