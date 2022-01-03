using Starship.Flight.Regulator;

namespace Starship.Flight.Segment.Flip
{
    public sealed class FlipAttitudeRegulator : ProportionalRegulator
    {
        protected override float MinimumOutput => -1.0F;

        protected override float MaximumOutput => 1.0F;

        protected override float ProportionalGain =>
            0.022222222222222223F; // Maximum output at 45 degrees deviation
    }
}