using System.Collections.Generic;
using Expansions.Serenity;
using Starship.Flight.Command.Actuation.Leg;

namespace Starship.Control.Actuation.Leg
{
    public sealed class LegsActuationControl : ILegsActuationControl
    {
        private IEnumerable<ModuleRoboticServoPiston> _legs;


        public void Bind(Vessel vessel) =>
            _legs = vessel.FindPartModulesImplementing<ModuleRoboticServoPiston>();

        public void ActuateLegs(LegsActuationCommand legsActuationCommand)
        {
            foreach (var leg in _legs)
            {
                if (legsActuationCommand.Extended)
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
}