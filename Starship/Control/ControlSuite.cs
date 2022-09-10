using Starship.Control.Actuation.Engine;
using Starship.Control.Actuation.Flap;
using Starship.Control.Actuation.Leg;
using Starship.Control.Throttle.Main;
using Starship.Flight.Command;

namespace Starship.Control
{
    public sealed class ControlSuite : IControlSuite
    {
        private readonly ILegsActuationControl _legsActuationControl;
        private readonly IFlapsActuationControl _flapsActuationControl;
        private readonly IMainEnginesGimbalControl _mainEnginesGimbalControl;
        private readonly IMainEnginesThrottleControl _mainEnginesThrottleControl;


        public ControlSuite(
            ILegsActuationControl legsActuationControl,
            IFlapsActuationControl flapsActuationControl,
            IMainEnginesGimbalControl mainEnginesGimbalControl,
            IMainEnginesThrottleControl mainEnginesThrottleControl)
        {
            _legsActuationControl = legsActuationControl;
            _flapsActuationControl = flapsActuationControl;
            _mainEnginesGimbalControl = mainEnginesGimbalControl;
            _mainEnginesThrottleControl = mainEnginesThrottleControl;
        }

        public void ExertControl(ICommandSuite commandSuite)
        {
            _legsActuationControl.ActuateLegs(
                commandSuite.LegsActuationCommand);

            _flapsActuationControl.ActuateFlaps(
                commandSuite.TopLeftFlapActuationCommand,
                commandSuite.TopRightFlapActuationCommand,
                commandSuite.BottomLeftFlapActuationCommand,
                commandSuite.BottomRightFlapActuationCommand);

            _mainEnginesGimbalControl.GimbalMainEngines(
                commandSuite.MainEnginesYawCommand,
                commandSuite.MainEnginesRollCommand,
                commandSuite.MainEnginesPitchCommand);

            _mainEnginesThrottleControl.ThrottleMainEngines(
                commandSuite.TopMainEngineThrottleCommand,
                commandSuite.BottomLeftMainEngineThrottleCommand,
                commandSuite.BottomRightMainEngineThrottleCommand);
        }
    }
}