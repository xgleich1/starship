namespace Starship.Flight.Regulator.Flap
{
    public sealed class FlapsActuationRegulator : PidRegulator
    {
        protected override float MinimumOutput => -0.5F / 3.0F;
        protected override float MaximumOutput => +0.5F / 3.0F;


        public FlapsActuationRegulator(
            float desiredValue,
            float proportionalGain,
            float integralGain,
            float derivativeGain
        ) : base(
            desiredValue,
            proportionalGain,
            integralGain,
            derivativeGain)
        {
        }
    }
}