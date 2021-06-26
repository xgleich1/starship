using Starship.Flight;

namespace Starship.Control
{
    public sealed class RcsControl
    {
        private readonly ModuleEngines _topLeftRcs;
        private readonly ModuleEngines _topRightRcs;
        private readonly ModuleEngines _bottomLeftRcs;
        private readonly ModuleEngines _bottomRightRcs;


        public RcsControl(Vessel vessel)
        {
            var engines = vessel
                .FindPartModulesImplementing<ModuleEngines>();

            _topLeftRcs = engines[1];
            _topRightRcs = engines[0];
            _bottomLeftRcs = engines[2];
            _bottomRightRcs = engines[3];

            EnableIndependentEngineControl();
        }

        public void ControlRcs(FlightCommand flightCommand)
        {
            _topLeftRcs.currentThrottle =
                flightCommand.TopLeftRcsThrottle;

            _topRightRcs.currentThrottle =
                flightCommand.TopRightRcsThrottle;

            _bottomLeftRcs.currentThrottle =
                flightCommand.BottomLeftRcsThrottle;

            _bottomRightRcs.currentThrottle =
                flightCommand.BottomRightRcsThrottle;
        }

        private void EnableIndependentEngineControl()
        {
            _topLeftRcs.useEngineResponseTime = true;
            _topRightRcs.useEngineResponseTime = true;
            _bottomLeftRcs.useEngineResponseTime = true;
            _bottomRightRcs.useEngineResponseTime = true;
        }
    }
}