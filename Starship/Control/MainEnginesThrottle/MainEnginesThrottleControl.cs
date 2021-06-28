using Starship.Flight.Command;

namespace Starship.Control.MainEnginesThrottle
{
    public sealed class MainEnginesThrottleControl : IMainEnginesThrottleControl
    {
        private readonly ModuleEngines _topMainEngine;
        private readonly ModuleEngines _bottomLeftMainEngine;
        private readonly ModuleEngines _bottomRightMainEngine;


        public MainEnginesThrottleControl(Vessel vessel)
        {
            var engines = vessel
                .FindPartModulesImplementing<ModuleEngines>();

            _topMainEngine = engines[4];
            _bottomLeftMainEngine = engines[5];
            _bottomRightMainEngine = engines[6];

            EnableIndependentEngineControl();
        }

        public void ControlMainEnginesThrottle(IFlightCommand flightCommand)
        {
            _topMainEngine.currentThrottle =
                flightCommand.TopMainEngineThrottle.ThrottlePercent;

            _bottomLeftMainEngine.currentThrottle =
                flightCommand.BottomLeftMainEngineThrottle.ThrottlePercent;

            _bottomRightMainEngine.currentThrottle =
                flightCommand.BottomRightMainEngineThrottle.ThrottlePercent;
        }

        private void EnableIndependentEngineControl()
        {
            _topMainEngine.useEngineResponseTime = true;
            _bottomLeftMainEngine.useEngineResponseTime = true;
            _bottomRightMainEngine.useEngineResponseTime = true;
        }
    }
}