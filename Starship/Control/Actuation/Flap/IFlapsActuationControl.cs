using Starship.Flight.Command.Actuation.Flap;

namespace Starship.Control.Actuation.Flap
{
    public interface IFlapsActuationControl
    {
        void ActuateFlaps(
            ActuateTopLeftFlapCommand actuateTopLeftFlapCommand,
            ActuateTopRightFlapCommand actuateTopRightFlapCommand,
            ActuateBottomLeftFlapCommand actuateBottomLeftFlapCommand,
            ActuateBottomRightFlapCommand actuateBottomRightFlapCommand);
    }
}