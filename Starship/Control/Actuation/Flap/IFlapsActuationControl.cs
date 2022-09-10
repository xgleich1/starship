using Starship.Flight.Command.Actuation.Flap;

namespace Starship.Control.Actuation.Flap
{
    public interface IFlapsActuationControl
    {
        void ActuateFlaps(
            TopLeftFlapActuationCommand topLeftFlapActuationCommand,
            TopRightFlapActuationCommand topRightFlapActuationCommand,
            BottomLeftFlapActuationCommand bottomLeftFlapActuationCommand,
            BottomRightFlapActuationCommand bottomRightFlapActuationCommand);
    }
}