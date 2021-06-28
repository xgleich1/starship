using Starship.Flight.Command;

namespace Starship.Control
{
    public interface IControlSuite
    {
        void ExertControl(IFlightCommand flightCommand);
    }
}