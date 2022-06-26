namespace Starship.Flight.Regulator.Engine
{
    public sealed class MainEnginesGimbalRegulator : PidRegulator
    {
        protected override float MinimumOutput => -1.0F;
        protected override float MaximumOutput => +1.0F;


        public MainEnginesGimbalRegulator(
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