using Starship.Flight.Command;

namespace Starship.Control
{
    public interface IControlSuite
    {
        void ExertControl(ICommandSuite commandSuite);
    }
}