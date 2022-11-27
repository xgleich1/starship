using Starship.Flight.Command.Activation.Rcs;

namespace Starship.Control.Activation.Rcs
{
    public sealed class RcsActivationControl : IRcsActivationControl
    {
        private ModuleEngines _topLeftRcsEngine;
        private ModuleEngines _topRightRcsEngine;
        private ModuleEngines _bottomLeftRcsEngine;
        private ModuleEngines _bottomRightRcsEngine;


        public void Bind(Vessel vessel)
        {
            var engines = vessel.FindPartModulesImplementing<ModuleEngines>();

            _topLeftRcsEngine = engines[0];
            _topRightRcsEngine = engines[1];
            _bottomLeftRcsEngine = engines[5];
            _bottomRightRcsEngine = engines[6];

            EnableIndependentEngineControl();
        }

        public void ActivateRcs(
            TopLeftRcsActivationCommand topLeftRcsActivationCommand,
            TopRightRcsActivationCommand topRightRcsActivationCommand,
            BottomLeftRcsActivationCommand bottomLeftRcsActivationCommand,
            BottomRightRcsActivationCommand bottomRightRcsActivationCommand)
        {
            ActivateRcsEngine(_topLeftRcsEngine, topLeftRcsActivationCommand.Activated);
            ActivateRcsEngine(_topRightRcsEngine, topRightRcsActivationCommand.Activated);
            ActivateRcsEngine(_bottomLeftRcsEngine, bottomLeftRcsActivationCommand.Activated);
            ActivateRcsEngine(_bottomRightRcsEngine, bottomRightRcsActivationCommand.Activated);
        }

        private void EnableIndependentEngineControl()
        {
            _topLeftRcsEngine.useEngineResponseTime = true;
            _topRightRcsEngine.useEngineResponseTime = true;
            _bottomLeftRcsEngine.useEngineResponseTime = true;
            _bottomRightRcsEngine.useEngineResponseTime = true;
        }

        private static void ActivateRcsEngine(ModuleEngines rcsEngine, bool activated)
        {
            rcsEngine.currentThrottle = activated ? 1.0F : 0.0F;
        }
    }
}