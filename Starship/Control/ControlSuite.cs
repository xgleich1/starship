using Starship.Flight;

namespace Starship.Control
{
    public sealed class ControlSuite
    {
        private readonly RcsControl _rcsControl;
        private readonly GimbalControl _gimbalControl;
        private readonly ThrottleControl _throttleControl;


        public ControlSuite(
            RcsControl rcsControl,
            GimbalControl gimbalControl,
            ThrottleControl throttleControl)
        {
            _rcsControl = rcsControl;
            _gimbalControl = gimbalControl;
            _throttleControl = throttleControl;
        }

        public void ExertControl(FlightCommand flightCommand)
        {
            _rcsControl.ControlRcs(flightCommand);
            _gimbalControl.ControlGimbal(flightCommand);
            _throttleControl.ControlThrottle(flightCommand);
        }
    }
}