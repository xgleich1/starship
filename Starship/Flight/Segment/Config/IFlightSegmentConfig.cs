using Starship.Telemetry;

namespace Starship.Flight.Segment.Config
{
    public interface IFlightSegmentConfig : ITelemetryProvider
    {
        float? TakeoverVerticalVelocityEqualOrOver { get; }
        float? TakeoverVerticalVelocityEqualOrUnder { get; }

        float? TakeoverYawAngleEqualOrOver { get; }
        float? TakeoverYawAngleEqualOrUnder { get; }

        float? TakeoverRollAngleEqualOrOver { get; }
        float? TakeoverRollAngleEqualOrUnder { get; }

        float? TakeoverPitchAngleEqualOrOver { get; }
        float? TakeoverPitchAngleEqualOrUnder { get; }

        float? TakeoverAltitudeEqualOrOver { get; }
        float? TakeoverAltitudeEqualOrUnder { get; }

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

        float FlapsActuationProportionalGain { get; }
        float FlapsActuationIntegralGain { get; }
        float FlapsActuationDerivativeGain { get; }

        float? TopLeftFlapDeployPercentOverwrite { get; }
        float? TopRightFlapDeployPercentOverwrite { get; }
        float? BottomLeftFlapDeployPercentOverwrite { get; }
        float? BottomRightFlapDeployPercentOverwrite { get; }

        bool LegsActuationExtendedState { get; }
    }
}