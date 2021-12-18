namespace Starship.Flight.Stabilization
{
    // Currently under development
    public sealed class AttitudeStabilizer
    {
        private const float ProportionalGain = 0.01F;


        public float CalculateAttitudeInput(
            float currentAttitudeAngleInDegrees,
            float desiredAttitudeAngleInDegrees)
        {
            var attitudeDeviationInDegrees = desiredAttitudeAngleInDegrees - currentAttitudeAngleInDegrees;

            var attitudeInputToReduceDeviation = attitudeDeviationInDegrees * ProportionalGain;

            return attitudeInputToReduceDeviation;
        }
    }
}