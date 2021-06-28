using Starship.Flight.Command;

namespace Starship.Control.RcsEnginesThrottle
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

        public void ControlRcsEnginesThrottle(IFlightCommand flightCommand)
        {
            _topLeftRcsEngine.currentThrottle =
                flightCommand.TopLeftRcsEngineThrottle.ThrottlePercent;

            _topRightRcsEngine.currentThrottle =
                flightCommand.TopRightRcsEngineThrottle.ThrottlePercent;

            _bottomLeftRcsEngine.currentThrottle =
                flightCommand.BottomLeftRcsEngineThrottle.ThrottlePercent;

            _bottomRightRcsEngine.currentThrottle =
                flightCommand.BottomRightRcsEngineThrottle.ThrottlePercent;
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