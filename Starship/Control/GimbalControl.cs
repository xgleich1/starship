using Starship.Flight;

namespace Starship.Control
{
    public sealed class GimbalControl
    {
        private readonly FlightCtrlState _flightControlState;


        public GimbalControl(Vessel vessel)
        {
            _flightControlState = vessel.ctrlState;
        }

        public void ControlGimbal(FlightCommand flightCommand)
        {
            _flightControlState.yaw =
                flightCommand.MainEngineGimbalYaw;

            _flightControlState.roll =
                flightCommand.MainEngineGimbalRoll;

            _flightControlState.pitch =
                flightCommand.MainEngineGimbalPitch;
        }
    }
}