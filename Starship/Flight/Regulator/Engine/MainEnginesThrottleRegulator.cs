namespace Starship.Flight.Regulator.Engine
{
    public sealed class MainEnginesThrottleRegulator : PidRegulator
    {
        protected override float MinimumOutput => 0.05F;
        protected override float MaximumOutput => 1.0F;


        public MainEnginesThrottleRegulator(
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