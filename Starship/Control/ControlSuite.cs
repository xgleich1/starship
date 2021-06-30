using Starship.Control.Attitude;
using Starship.Control.Throttle.Main;
using Starship.Control.Throttle.Rcs;
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

        public void ExertControl(ICommandSuite commandSuite)
        {
            _rcsEnginesThrottleControl.ControlRcsEnginesThrottle(commandSuite);
            _mainEnginesThrottleControl.ControlMainEnginesThrottle(commandSuite);
            _mainEnginesAttitudeControl.ControlMainEnginesAttitude(commandSuite);
        }
    }
}