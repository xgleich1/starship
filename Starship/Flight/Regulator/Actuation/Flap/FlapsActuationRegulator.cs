namespace Starship.Flight.Regulator.Actuation.Flap
{
    public sealed class FlapsActuationRegulator : ProportionalRegulator
    {
        protected override float MinimumOutput => -0.5F;
        protected override float MaximumOutput => +0.5F;


        public FlapsActuationRegulator(float proportionalGain) : base(proportionalGain)
        {
        }
    }
}