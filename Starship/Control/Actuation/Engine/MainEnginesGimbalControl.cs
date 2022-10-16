using Starship.Flight.Command.Actuation.Engine;

namespace Starship.Control.Actuation.Engine
{
    public sealed class MainEnginesGimbalControl : IMainEnginesGimbalControl
    {
        private FlightCtrlState _flightControlState;


        public void Bind(Vessel vessel) => _flightControlState = vessel.ctrlState;

        public void GimbalMainEngines(
            MainEnginesYawCommand mainEnginesYawCommand,
            MainEnginesRollCommand mainEnginesRollCommand,
            MainEnginesPitchCommand mainEnginesPitchCommand)
        {
            _flightControlState.yaw = mainEnginesYawCommand.YawPercent;
            _flightControlState.roll = mainEnginesRollCommand.RollPercent;
            _flightControlState.pitch = mainEnginesPitchCommand.PitchPercent;
        }
    }
}