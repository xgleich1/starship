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
            var engines = vessel.FindPartModulesImplementing<ModuleEngines>();

            _topMainEngine = engines[2];
            _bottomLeftMainEngine = engines[3];
            _bottomRightMainEngine = engines[4];

            EnableIndependentEngineControl();
        }

        public void ThrottleMainEngines(
            TopMainEngineThrottleCommand topMainEngineThrottleCommand,
            BottomLeftMainEngineThrottleCommand bottomLeftMainEngineThrottleCommand,
            BottomRightMainEngineThrottleCommand bottomRightMainEngineThrottleCommand)
        {
            _topMainEngine.currentThrottle = topMainEngineThrottleCommand.ThrottlePercent;
            _bottomLeftMainEngine.currentThrottle = bottomLeftMainEngineThrottleCommand.ThrottlePercent;
            _bottomRightMainEngine.currentThrottle = bottomRightMainEngineThrottleCommand.ThrottlePercent;
        }

        private void EnableIndependentEngineControl()
        {
            _topMainEngine.useEngineResponseTime = true;
            _bottomLeftMainEngine.useEngineResponseTime = true;
            _bottomRightMainEngine.useEngineResponseTime = true;
        }
    }
}