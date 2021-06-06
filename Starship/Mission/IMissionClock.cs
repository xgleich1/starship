using Starship.Utility.Timing.Units;

namespace Starship.Mission
{
    public interface IMissionClock
    {
        void StartWithZeroSeconds();

        Seconds GetElapsedSecondsInMission();
    }
}