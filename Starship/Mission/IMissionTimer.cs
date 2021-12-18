using Starship.Utility.Timing.Units;

namespace Starship.Mission
{
    public interface IMissionTimer
    {
        void StartWithZeroSeconds();

        Seconds GetElapsedSecondsInMission();
    }
}