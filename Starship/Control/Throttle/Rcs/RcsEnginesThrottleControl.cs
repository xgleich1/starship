using Starship.Flight.Command;

namespace Starship.Control.Throttle.Rcs
{
    public sealed class RcsEnginesThrottleControl : IRcsEnginesThrottleControl
    {
        private readonly ModuleEngines _topLeftRcsEngine;
        private readonly ModuleEngines _topRightRcsEngine;
        private readonly ModuleEngines _bottomLeftRcsEngine;
        private readonly ModuleEngines _bottomRightRcsEngine;


        public RcsEnginesThrottleControl(Vessel vessel)
        {
            var engines = vessel
                .FindPartModulesImplementing<ModuleEngines>();

            _topLeftRcsEngine = engines[1];
            _topRightRcsEngine = engines[0];
            _bottomLeftRcsEngine = engines[2];
            _bottomRightRcsEngine = engines[3];

            EnableIndependentEngineControl();
        }

        public void ControlRcsEnginesThrottle(ICommandSuite commandSuite)
        {
            _topLeftRcsEngine.currentThrottle =
                commandSuite.TopLeftRcsEngineThrottleCommand.ThrottlePercent;

            _topRightRcsEngine.currentThrottle =
                commandSuite.TopRightRcsEngineThrottleCommand.ThrottlePercent;

            _bottomLeftRcsEngine.currentThrottle =
                commandSuite.BottomLeftRcsEngineThrottleCommand.ThrottlePercent;

            _bottomRightRcsEngine.currentThrottle =
                commandSuite.BottomRightRcsEngineThrottleCommand.ThrottlePercent;
        }

        private void EnableIndependentEngineControl()
        {
            _topLeftRcsEngine.useEngineResponseTime = true;
            _topRightRcsEngine.useEngineResponseTime = true;
            _bottomLeftRcsEngine.useEngineResponseTime = true;
            _bottomRightRcsEngine.useEngineResponseTime = true;
        }
    }
}