using Starship.Telemetry;
using Starship.Utility.Timing.Units;

namespace Starship.Flight.Segment.Config
{
    public interface IFlightSegmentConfig : ITelemetryProvider
    {
        Seconds TakeoverSecondsInMission { get; }

        float DesiredVerticalVelocityInMetrePerSecond { get; }

        float MainEnginesThrottleProportionalGain { get; }
        float MainEnginesThrottleIntegralGain { get; }
        float MainEnginesThrottleDerivativeGain { get; }

        float? TopMainEngineThrottlePercentOverwrite { get; }
        float? BottomLeftMainEngineThrottlePercentOverwrite { get; }
        float? BottomRightMainEngineThrottlePercentOverwrite { get; }

        float DesiredYawAngleInDegrees { get; }
        float DesiredRollAngleInDegrees { get; }
        float DesiredPitchAngleInDegrees { get; }

        float MainEnginesGimbalProportionalGain { get; }
        float MainEnginesGimbalIntegralGain { get; }
        float MainEnginesGimbalDerivativeGain { get; }

        float? MainEnginesYawPercentOverwrite { get; }
        float? MainEnginesRollPercentOverwrite { get; }
        float? MainEnginesPitchPercentOverwrite { get; }

        float FlapsYawProportionalGain { get; }
        float FlapsYawIntegralGain { get; }
        float FlapsYawDerivativeGain { get; }

        float FlapsRollProportionalGain { get; }
        float FlapsRollIntegralGain { get; }
        float FlapsRollDerivativeGain { get; }

        float FlapsPitchProportionalGain { get; }
        float FlapsPitchIntegralGain { get; }
        float FlapsPitchDerivativeGain { get; }

        float? TopLeftFlapDeployPercentOverwrite { get; }
        float? TopRightFlapDeployPercentOverwrite { get; }
        float? BottomLeftFlapDeployPercentOverwrite { get; }
        float? BottomRightFlapDeployPercentOverwrite { get; }
    }
}