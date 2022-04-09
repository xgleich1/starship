using Starship.Utility.Math;

namespace Starship.Flight.Regulator
{
    public abstract class ProportionalRegulator
    {
        protected abstract float MinimumOutput { get; }
        protected abstract float MaximumOutput { get; }

        private readonly float _proportionalGain;


        protected ProportionalRegulator(float proportionalGain)
        {
            _proportionalGain = proportionalGain;
        }

        public float RegulateValue(float currentValue, float desiredValue)
        {
            var deviation = desiredValue - currentValue;

            var outputToReduceDeviation = deviation * _proportionalGain;

            return outputToReduceDeviation.Clamp(MinimumOutput, MaximumOutput);
        }
    }
}