using Starship.Flight.Command;

namespace Starship.Control.Attitude
{
    public sealed class MainEnginesAttitudeControl : IMainEnginesAttitudeControl
    {
        private readonly FlightCtrlState _flightControlState;


        public MainEnginesAttitudeControl(Vessel vessel)
        {
            _flightControlState = vessel.ctrlState;
        }

        public void ControlMainEnginesAttitude(ICommandSuite commandSuite)
        {
            _flightControlState.yaw =
                commandSuite.MainEngineAttitudeYawCommand.YawInput;

            _flightControlState.roll =
                commandSuite.MainEngineAttitudeRollCommand.RollInput;

            _flightControlState.pitch =
                commandSuite.MainEngineAttitudePitchCommand.PitchInput;
        }
    }
}