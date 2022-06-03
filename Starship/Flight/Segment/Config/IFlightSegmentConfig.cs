using Starship.Telemetry;
using Starship.Utility.Timing.Units;

namespace Starship.Flight.Segment.Config
{
    public interface IFlightSegmentConfig : ITelemetryProvider
    {
        Seconds TakeoverSecondsInMission { get; }

        float DesiredVerticalVelocityInMetrePerSecond { get; }

        float ThrottleTopMainEngineProportionalGain { get; }
        float ThrottleBottomLeftMainEngineProportionalGain { get; }
        float ThrottleBottomRightMainEngineProportionalGain { get; }

        float? TopMainEngineThrottlePercentOverwrite { get; }
        float? BottomLeftMainEngineThrottlePercentOverwrite { get; }
        float? BottomRightMainEngineThrottlePercentOverwrite { get; }

        float DesiredYawAngleInDegrees { get; }
        float DesiredRollAngleInDegrees { get; }
        float DesiredPitchAngleInDegrees { get; }

        float YawWithMainEnginesProportionalGain { get; }
        float RollWithMainEnginesProportionalGain { get; }
        float PitchWithMainEnginesProportionalGain { get; }

        float? MainEnginesYawPercentOverwrite { get; }
        float? MainEnginesRollPercentOverwrite { get; }
        float? MainEnginesPitchPercentOverwrite { get; }

        float YawWithFlapsProportionalGain { get; }
        float RollWithFlapsProportionalGain { get; }
        float PitchWithFlapsProportionalGain { get; }

        float? TopLeftFlapDeployPercentOverwrite { get; }
        float? TopRightFlapDeployPercentOverwrite { get; }
        float? BottomLeftFlapDeployPercentOverwrite { get; }
        float? BottomRightFlapDeployPercentOverwrite { get; }
    }
}