using Starship.Flight.Command.Actuation.Engine;

namespace Starship.Control.Actuation.Engine
{
    public interface IMainEnginesGimbalControl
    {
        void GimbalMainEngines(
            MainEnginesYawCommand mainEnginesYawCommand,
            MainEnginesRollCommand mainEnginesRollCommand,
            MainEnginesPitchCommand mainEnginesPitchCommand);
    }
}