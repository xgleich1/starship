using Starship.Flight.Command.Actuation.Engine;

namespace Starship.Flight.Segment.Actuation.Engine
{
    public sealed class MainEnginesGimbalSegmentCommands
    {
        public MainEnginesYawCommand MainEnginesYawCommand { get; }
        public MainEnginesRollCommand MainEnginesRollCommand { get; }
        public MainEnginesPitchCommand MainEnginesPitchCommand { get; }


        public MainEnginesGimbalSegmentCommands(
            MainEnginesYawCommand mainEnginesYawCommand,
            MainEnginesRollCommand mainEnginesRollCommand,
            MainEnginesPitchCommand mainEnginesPitchCommand)
        {
            MainEnginesYawCommand = mainEnginesYawCommand;
            MainEnginesRollCommand = mainEnginesRollCommand;
            MainEnginesPitchCommand = mainEnginesPitchCommand;
        }
    }
}