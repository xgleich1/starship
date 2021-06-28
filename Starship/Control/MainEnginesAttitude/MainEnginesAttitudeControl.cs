using Starship.Flight.Command;

namespace Starship.Control.MainEnginesAttitude
{
    public sealed class MainEnginesAttitudeControl : IMainEnginesAttitudeControl
    {
        private readonly FlightCtrlState _flightControlState;


        public MainEnginesAttitudeControl(Vessel vessel)
        {
            _flightControlState = vessel.ctrlState;
        }

        public void ControlMainEnginesAttitude(IFlightCommand flightCommand)
        {
            _flightControlState.yaw =
                flightCommand.MainEngineAttitudeYaw.AttitudeInput;

            _flightControlState.roll =
                flightCommand.MainEngineAttitudeRoll.AttitudeInput;

            _flightControlState.pitch =
                flightCommand.MainEngineAttitudePitch.AttitudeInput;
        }
    }
}