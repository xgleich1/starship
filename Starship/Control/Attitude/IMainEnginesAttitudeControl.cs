using Starship.Flight.Command.Attitude;

namespace Starship.Control.Attitude
{
    public interface IMainEnginesAttitudeControl
    {
        void ControlMainEnginesAttitude(
            MainEngineAttitudeYawCommand mainEngineAttitudeYawCommand,
            MainEngineAttitudeRollCommand mainEngineAttitudeRollCommand,
            MainEngineAttitudePitchCommand mainEngineAttitudePitchCommand);
    }
}