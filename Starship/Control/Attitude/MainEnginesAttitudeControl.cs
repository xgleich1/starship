using Starship.Flight.Command.Attitude;

namespace Starship.Control.Attitude
{
    public sealed class MainEnginesAttitudeControl : IMainEnginesAttitudeControl
    {
        private FlightCtrlState _flightControlState;


        public void Bind(Vessel vessel)
        {
            _flightControlState = vessel.ctrlState;
        }

        public void ControlMainEnginesAttitude(
            MainEngineAttitudeYawCommand mainEngineAttitudeYawCommand,
            MainEngineAttitudeRollCommand mainEngineAttitudeRollCommand,
            MainEngineAttitudePitchCommand mainEngineAttitudePitchCommand)
        {
            _flightControlState.yaw = mainEngineAttitudeYawCommand.YawInput;
            _flightControlState.roll = mainEngineAttitudeRollCommand.RollInput;
            _flightControlState.pitch = mainEngineAttitudePitchCommand.PitchInput;
        }
    }
}