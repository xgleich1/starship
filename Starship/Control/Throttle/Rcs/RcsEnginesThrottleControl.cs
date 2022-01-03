using Starship.Flight.Command.Throttle.Rcs;

namespace Starship.Control.Throttle.Rcs
{
    public sealed class RcsEnginesThrottleControl : IRcsEnginesThrottleControl
    {
        private ModuleEngines _topLeftRcsEngine;
        private ModuleEngines _topRightRcsEngine;
        private ModuleEngines _bottomLeftRcsEngine;
        private ModuleEngines _bottomRightRcsEngine;


        public void Bind(Vessel vessel)
        {
            var engines = vessel
                .FindPartModulesImplementing<ModuleEngines>();

            _topLeftRcsEngine = engines[1];
            _topRightRcsEngine = engines[0];
            _bottomLeftRcsEngine = engines[2];
            _bottomRightRcsEngine = engines[3];

            EnableIndependentEngineControl();
        }

        public void ThrottleRcsEngines(
            ThrottleTopLeftRcsEngineCommand throttleTopLeftRcsEngineCommand,
            ThrottleTopRightRcsEngineCommand throttleTopRightRcsEngineCommand,
            ThrottleBottomLeftRcsEngineCommand throttleBottomLeftRcsEngineCommand,
            ThrottleBottomRightRcsEngineCommand throttleBottomRightRcsEngineCommand)
        {
            _topLeftRcsEngine.currentThrottle = throttleTopLeftRcsEngineCommand.ThrottlePercent;
            _topRightRcsEngine.currentThrottle = throttleTopRightRcsEngineCommand.ThrottlePercent;
            _bottomLeftRcsEngine.currentThrottle = throttleBottomLeftRcsEngineCommand.ThrottlePercent;
            _bottomRightRcsEngine.currentThrottle = throttleBottomRightRcsEngineCommand.ThrottlePercent;
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