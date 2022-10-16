using Starship.Flight.Command.Actuation.Flap;

namespace Starship.Flight.Segment.Actuation.Flap
{
    public readonly struct FlapsActuationSegmentCommands
    {
        public TopLeftFlapActuationCommand TopLeftFlapActuationCommand { get; }
        public TopRightFlapActuationCommand TopRightFlapActuationCommand { get; }
        public BottomLeftFlapActuationCommand BottomLeftFlapActuationCommand { get; }
        public BottomRightFlapActuationCommand BottomRightFlapActuationCommand { get; }


        public FlapsActuationSegmentCommands(
            TopLeftFlapActuationCommand topLeftFlapActuationCommand,
            TopRightFlapActuationCommand topRightFlapActuationCommand,
            BottomLeftFlapActuationCommand bottomLeftFlapActuationCommand,
            BottomRightFlapActuationCommand bottomRightFlapActuationCommand)
        {
            TopLeftFlapActuationCommand = topLeftFlapActuationCommand;
            TopRightFlapActuationCommand = topRightFlapActuationCommand;
            BottomLeftFlapActuationCommand = bottomLeftFlapActuationCommand;
            BottomRightFlapActuationCommand = bottomRightFlapActuationCommand;
        }
    }
}