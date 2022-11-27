using Starship.Flight.Command.Activation.Rcs;

namespace Starship.Flight.Segment.Activation.Rcs
{
    public readonly struct RcsActivationSegmentCommands
    {
        public TopLeftRcsActivationCommand TopLeftRcsActivationCommand { get; }
        public TopRightRcsActivationCommand TopRightRcsActivationCommand { get; }
        public BottomLeftRcsActivationCommand BottomLeftRcsActivationCommand { get; }
        public BottomRightRcsActivationCommand BottomRightRcsActivationCommand { get; }


        public RcsActivationSegmentCommands(
            TopLeftRcsActivationCommand topLeftRcsActivationCommand,
            TopRightRcsActivationCommand topRightRcsActivationCommand,
            BottomLeftRcsActivationCommand bottomLeftRcsActivationCommand,
            BottomRightRcsActivationCommand bottomRightRcsActivationCommand)
        {
            TopLeftRcsActivationCommand = topLeftRcsActivationCommand;
            TopRightRcsActivationCommand = topRightRcsActivationCommand;
            BottomLeftRcsActivationCommand = bottomLeftRcsActivationCommand;
            BottomRightRcsActivationCommand = bottomRightRcsActivationCommand;
        }
    }
}