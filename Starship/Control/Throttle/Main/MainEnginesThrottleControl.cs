using Starship.Flight.Command.Throttle.Main;

namespace Starship.Control.Throttle.Main
{
    public sealed class MainEnginesThrottleControl : IMainEnginesThrottleControl
    {
        private ModuleEngines _topMainEngine;
        private ModuleEngines _bottomLeftMainEngine;
        private ModuleEngines _bottomRightMainEngine;


        public void Bind(Vessel vessel)
        {
            var engines = vessel
                .FindPartModulesImplementing<ModuleEngines>();

            _topMainEngine = engines[0];
            _bottomLeftMainEngine = engines[1];
            _bottomRightMainEngine = engines[2];

            EnableIndependentEngineControl();
        }

        public void ThrottleMainEngines(
            ThrottleTopMainEngineCommand throttleTopMainEngineCommand,
            ThrottleBottomLeftMainEngineCommand throttleBottomLeftMainEngineCommand,
            ThrottleBottomRightMainEngineCommand throttleBottomRightMainEngineCommand)
        {
            _topMainEngine.currentThrottle = throttleTopMainEngineCommand.ThrottlePercent;
            _bottomLeftMainEngine.currentThrottle = throttleBottomLeftMainEngineCommand.ThrottlePercent;
            _bottomRightMainEngine.currentThrottle = throttleBottomRightMainEngineCommand.ThrottlePercent;
        }

        private void EnableIndependentEngineControl()
        {
            _topMainEngine.useEngineResponseTime = true;
            _bottomLeftMainEngine.useEngineResponseTime = true;
            _bottomRightMainEngine.useEngineResponseTime = true;
        }
    }
}