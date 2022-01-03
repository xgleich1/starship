using Starship.Flight.Command.Actuation.Engine;

namespace Starship.Control.Actuation.Engine
{
    public interface IMainEnginesGimbalControl
    {
        void GimbalMainEngines(
            YawMainEnginesCommand yawMainEnginesCommand,
            RollMainEnginesCommand rollMainEnginesCommand,
            PitchMainEnginesCommand pitchMainEnginesCommand);
    }
}