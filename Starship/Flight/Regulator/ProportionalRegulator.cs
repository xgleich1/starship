using Starship.Utility.Math;

namespace Starship.Flight.Regulator
{
    public abstract class ProportionalRegulator
    {
        protected abstract float MinimumOutput { get; }

        protected abstract float MaximumOutput { get; }

        protected abstract float ProportionalGain { get; }


        public float RegulateValue(float currentValue, float desiredValue)
        {
            var deviation = desiredValue - currentValue;

            var outputToReduceDeviation = deviation * ProportionalGain;

            return outputToReduceDeviation.Clamp(MinimumOutput, MaximumOutput);
        }
    }
}