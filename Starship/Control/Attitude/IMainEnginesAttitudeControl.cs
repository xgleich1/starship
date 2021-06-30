using Starship.Flight.Command;

namespace Starship.Control.Attitude
{
    public interface IMainEnginesAttitudeControl
    {
        void ControlMainEnginesAttitude(ICommandSuite commandSuite);
    }
}