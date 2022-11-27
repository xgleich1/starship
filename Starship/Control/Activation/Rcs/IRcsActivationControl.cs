using Starship.Flight.Command.Activation.Rcs;

namespace Starship.Control.Activation.Rcs
{
    public interface IRcsActivationControl
    {
        void ActivateRcs(
            TopLeftRcsActivationCommand topLeftRcsActivationCommand,
            TopRightRcsActivationCommand topRightRcsActivationCommand,
            BottomLeftRcsActivationCommand bottomLeftRcsActivationCommand,
            BottomRightRcsActivationCommand bottomRightRcsActivationCommand);
    }
}