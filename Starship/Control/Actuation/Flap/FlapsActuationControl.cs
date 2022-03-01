using Expansions.Serenity;
using Starship.Flight.Command.Actuation.Flap;

namespace Starship.Control.Actuation.Flap
{
    public sealed class FlapsActuationControl : IFlapsActuationControl
    {
        private ModuleRoboticServoHinge _topLeftFlap;
        private ModuleRoboticServoHinge _topRightFlap;
        private ModuleRoboticServoHinge _bottomLeftFlap;
        private ModuleRoboticServoHinge _bottomRightFlap;


        public void Bind(Vessel vessel)
        {
            var flaps = vessel
                .FindPartModulesImplementing<ModuleRoboticServoHinge>();

            _topLeftFlap = flaps[0];
            _topRightFlap = flaps[1];
            _bottomLeftFlap = flaps[2];
            _bottomRightFlap = flaps[3];
        }

        public void ActuateFlaps(
            ActuateTopLeftFlapCommand actuateTopLeftFlapCommand,
            ActuateTopRightFlapCommand actuateTopRightFlapCommand,
            ActuateBottomLeftFlapCommand actuateBottomLeftFlapCommand,
            ActuateBottomRightFlapCommand actuateBottomRightFlapCommand)
        {
            ActuateFlap(_topLeftFlap, actuateTopLeftFlapCommand.DeployPercent);
            ActuateFlap(_topRightFlap, actuateTopRightFlapCommand.DeployPercent);
            ActuateFlap(_bottomLeftFlap, actuateBottomLeftFlapCommand.DeployPercent);
            ActuateFlap(_bottomRightFlap, actuateBottomRightFlapCommand.DeployPercent);
        }

        private static void ActuateFlap(ModuleRoboticServoHinge flap, float deployPercent)
        {
            var minimumAngle = flap.softMinMaxAngles.x;
            var maximumAngle = flap.softMinMaxAngles.y;

            var deployedAngle =
                (maximumAngle - minimumAngle) * deployPercent;

            flap.targetAngle = minimumAngle + deployedAngle;
        }
    }
}