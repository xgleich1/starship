using Starship.Flight.Command.Actuation.Leg;

namespace Starship.Control.Actuation.Leg
{
    public interface ILegsActuationControl
    {
        void ActuateLegs(LegsActuationCommand legsActuationCommand);
    }
}