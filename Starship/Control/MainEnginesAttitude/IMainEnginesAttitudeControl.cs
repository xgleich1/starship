using Starship.Flight.Command;

namespace Starship.Control.MainEnginesAttitude
{
    public interface IMainEnginesAttitudeControl
    {
        void ControlMainEnginesAttitude(IFlightCommand flightCommand);
    }
}