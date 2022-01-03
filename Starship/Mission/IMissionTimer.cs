using Starship.Utility.Timing.Units;

namespace Starship.Mission
{
    public interface IMissionTimer
    {
        bool IsRunning { get; }


        void StartWithZeroSeconds();

        Seconds GetElapsedSeconds();
    }
}