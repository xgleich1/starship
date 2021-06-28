using Starship.Control.MainEnginesAttitude;
using Starship.Control.MainEnginesThrottle;
using Starship.Control.RcsEnginesThrottle;
using Starship.Flight.Command;

namespace Starship.Control
{
    public sealed class ControlSuite : IControlSuite
    {
        private readonly IRcsEnginesThrottleControl _rcsEnginesThrottleControl;
        private readonly IMainEnginesThrottleControl _mainEnginesThrottleControl;
        private readonly IMainEnginesAttitudeControl _mainEnginesAttitudeControl;


        public ControlSuite(
            IRcsEnginesThrottleControl rcsEnginesThrottleControl,
            IMainEnginesThrottleControl mainEnginesThrottleControl,
            IMainEnginesAttitudeControl mainEnginesAttitudeControl)
        {
            _rcsEnginesThrottleControl = rcsEnginesThrottleControl;
            _mainEnginesThrottleControl = mainEnginesThrottleControl;
            _mainEnginesAttitudeControl = mainEnginesAttitudeControl;
        }

        // Test
        public void ExertControl(IFlightCommand flightCommand)
        {
            _rcsEnginesThrottleControl.ControlRcsEnginesThrottle(flightCommand);
            _mainEnginesThrottleControl.ControlMainEnginesThrottle(flightCommand);
            _mainEnginesAttitudeControl.ControlMainEnginesAttitude(flightCommand);
        }
    }
}