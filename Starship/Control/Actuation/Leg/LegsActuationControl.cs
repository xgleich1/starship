using Expansions.Serenity;
using Starship.Flight.Command.Actuation.Leg;

namespace Starship.Control.Actuation.Leg
{
    public sealed class LegsActuationControl : ILegsActuationControl
    {
        private ModuleRoboticServoPiston _topLeg;
        private ModuleRoboticServoPiston _bottomLeftLeg;
        private ModuleRoboticServoPiston _bottomRightLeg;


        public void Bind(Vessel vessel)
        {
            var legs = vessel
                .FindPartModulesImplementing<ModuleRoboticServoPiston>();

            _topLeg = legs[0];
            _bottomLeftLeg = legs[1];
            _bottomRightLeg = legs[2];
        }

        public void ActuateLegs(ActuateLegsCommand actuateLegsCommand)
        {
            ActuateLeg(_topLeg, actuateLegsCommand.Extended);
            ActuateLeg(_bottomLeftLeg, actuateLegsCommand.Extended);
            ActuateLeg(_bottomRightLeg, actuateLegsCommand.Extended);
        }

        private static void ActuateLeg(ModuleRoboticServoPiston leg, bool extended)
        {
            if (extended)
            {
                leg.ExtendPiston();
            }
            else
            {
                leg.RetractPiston();
            }
        }
    }
}