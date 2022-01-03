using Starship.Flight.Command.Actuation.Engine;

namespace Starship.Control.Actuation.Engine
{
    public sealed class MainEnginesGimbalControl : IMainEnginesGimbalControl
    {
        private FlightCtrlState _flightControlState;


        public void Bind(Vessel vessel)
        {
            _flightControlState = vessel.ctrlState;
        }

        public void GimbalMainEngines(
            YawMainEnginesCommand yawMainEnginesCommand,
            RollMainEnginesCommand rollMainEnginesCommand,
            PitchMainEnginesCommand pitchMainEnginesCommand)
        {
            _flightControlState.yaw = yawMainEnginesCommand.YawPercent;
            _flightControlState.roll = rollMainEnginesCommand.RollPercent;
            _flightControlState.pitch = pitchMainEnginesCommand.PitchPercent;
        }
    }
}