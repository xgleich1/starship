namespace Starship.Flight.Regulator.Engine
{
    public sealed class MainEnginesThrottleRegulator : ProportionalRegulator
    {
        protected override float MinimumOutput => 0.05F;
        protected override float MaximumOutput => 1.0F;


        public MainEnginesThrottleRegulator(float proportionalGain) : base(proportionalGain)
        {
        }
    }
}