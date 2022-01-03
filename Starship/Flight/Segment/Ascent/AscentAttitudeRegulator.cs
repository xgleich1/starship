using Starship.Flight.Regulator;

namespace Starship.Flight.Segment.Ascent
{
    public sealed class AscentAttitudeRegulator : ProportionalRegulator
    {
        protected override float MinimumOutput => -1.0F;

        protected override float MaximumOutput => 1.0F;

        protected override float ProportionalGain =>
            0.011111111111111112F; // Maximum output at 90 degrees deviation
    }
}