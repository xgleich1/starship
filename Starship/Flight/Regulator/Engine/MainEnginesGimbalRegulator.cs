namespace Starship.Flight.Regulator.Engine
{
    public sealed class MainEnginesGimbalRegulator : ProportionalRegulator
    {
        protected override float MinimumOutput => -1.0F;
        protected override float MaximumOutput => +1.0F;


        public MainEnginesGimbalRegulator(float proportionalGain) : base(proportionalGain)
        {
        }
    }
}