using Starship.Flight;

namespace Starship.Control
{
    public sealed class ThrottleControl
    {
        private readonly ModuleEngines _topMainEngine;
        private readonly ModuleEngines _bottomLeftMainEngine;
        private readonly ModuleEngines _bottomRightMainEngine;


        public ThrottleControl(Vessel vessel)
        {
            var engines = vessel
                .FindPartModulesImplementing<ModuleEngines>();

            _topMainEngine = engines[4];
            _bottomLeftMainEngine = engines[5];
            _bottomRightMainEngine = engines[6];

            EnableIndependentEngineControl();
        }

        public void ControlThrottle(FlightCommand flightCommand)
        {
            _topMainEngine.currentThrottle =
                flightCommand.TopMainEngineThrottle;

            _bottomLeftMainEngine.currentThrottle =
                flightCommand.BottomLeftMainEngineThrottle;

            _bottomRightMainEngine.currentThrottle =
                flightCommand.BottomRightMainEngineThrottle;
        }

        private void EnableIndependentEngineControl()
        {
            _topMainEngine.useEngineResponseTime = true;
            _bottomLeftMainEngine.useEngineResponseTime = true;
            _bottomRightMainEngine.useEngineResponseTime = true;
        }
    }
}