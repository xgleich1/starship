using Starship.Flight.Regulator;

namespace Starship.Flight.Segment.Flop
{
    public sealed class FlopAttitudeRegulator : ProportionalRegulator
    {
        protected override float MinimumOutput => -0.5F;
        protected override float MaximumOutput => 0.5F;
        protected override float ProportionalGain => 0.007692307692307693F; // Maximum output at 65 degrees deviation
    }
}