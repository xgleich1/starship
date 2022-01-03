using Starship.Control.Actuation.Engine;
using Starship.Control.Actuation.Flap;
using Starship.Control.Throttle.Main;
using Starship.Control.Throttle.Rcs;
using Starship.Flight.Command;

namespace Starship.Control
{
    public sealed class ControlSuite : IControlSuite
    {
        private readonly IRcsEnginesThrottleControl _rcsEnginesThrottleControl;
        private readonly IMainEnginesThrottleControl _mainEnginesThrottleControl;
        private readonly IMainEnginesGimbalControl _mainEnginesGimbalControl;
        private readonly IFlapsActuationControl _flapsActuationControl;


        public ControlSuite(
            IRcsEnginesThrottleControl rcsEnginesThrottleControl,
            IMainEnginesThrottleControl mainEnginesThrottleControl,
            IMainEnginesGimbalControl mainEnginesGimbalControl,
            IFlapsActuationControl flapsActuationControl)
        {
            _rcsEnginesThrottleControl = rcsEnginesThrottleControl;
            _mainEnginesThrottleControl = mainEnginesThrottleControl;
            _mainEnginesGimbalControl = mainEnginesGimbalControl;
            _flapsActuationControl = flapsActuationControl;
        }

        public void ExertControl(ICommandSuite commandSuite)
        {
            _rcsEnginesThrottleControl.ThrottleRcsEngines(
                commandSuite.ThrottleTopLeftRcsEngineCommand,
                commandSuite.ThrottleTopRightRcsEngineCommand,
                commandSuite.ThrottleBottomLeftRcsEngineCommand,
                commandSuite.ThrottleBottomRightRcsEngineCommand);

            _mainEnginesThrottleControl.ThrottleMainEngines(
                commandSuite.ThrottleTopMainEngineCommand,
                commandSuite.ThrottleBottomLeftMainEngineCommand,
                commandSuite.ThrottleBottomRightMainEngineCommand);

            _mainEnginesGimbalControl.GimbalMainEngines(
                commandSuite.YawMainEnginesCommand,
                commandSuite.RollMainEnginesCommand,
                commandSuite.PitchMainEnginesCommand);

            _flapsActuationControl.ActuateFlaps(
                commandSuite.ActuateTopLeftFlapCommand,
                commandSuite.ActuateTopRightFlapCommand,
                commandSuite.ActuateBottomLeftFlapCommand,
                commandSuite.ActuateBottomRightFlapCommand);
        }
    }
}