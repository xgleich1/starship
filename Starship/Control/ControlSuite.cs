using Starship.Control.Actuation.Engine;
using Starship.Control.Actuation.Flap;
using Starship.Control.Throttle.Main;
using Starship.Flight.Command;

namespace Starship.Control
{
    public sealed class ControlSuite : IControlSuite
    {
        private readonly IMainEnginesThrottleControl _mainEnginesThrottleControl;
        private readonly IMainEnginesGimbalControl _mainEnginesGimbalControl;
        private readonly IFlapsActuationControl _flapsActuationControl;


        public ControlSuite(
            IMainEnginesThrottleControl mainEnginesThrottleControl,
            IMainEnginesGimbalControl mainEnginesGimbalControl,
            IFlapsActuationControl flapsActuationControl)
        {
            _mainEnginesThrottleControl = mainEnginesThrottleControl;
            _mainEnginesGimbalControl = mainEnginesGimbalControl;
            _flapsActuationControl = flapsActuationControl;
        }

        public void ExertControl(ICommandSuite commandSuite)
        {
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