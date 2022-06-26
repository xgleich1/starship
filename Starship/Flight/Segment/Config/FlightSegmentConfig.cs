using System.Collections.Generic;
using Starship.Telemetry;
using Starship.Utility.Timing.Units;

namespace Starship.Flight.Segment.Config
{
    // Currently under development
    public readonly struct FlightSegmentConfig : IFlightSegmentConfig
    {
        public Seconds TakeoverSecondsInMission { get; }

        public float DesiredVerticalVelocityInMetrePerSecond { get; }

        public float MainEnginesThrottleProportionalGain { get; }
        public float MainEnginesThrottleIntegralGain { get; }
        public float MainEnginesThrottleDerivativeGain { get; }

        public float? TopMainEngineThrottlePercentOverwrite { get; }
        public float? BottomLeftMainEngineThrottlePercentOverwrite { get; }
        public float? BottomRightMainEngineThrottlePercentOverwrite { get; }

        public float DesiredYawAngleInDegrees { get; }
        public float DesiredRollAngleInDegrees { get; }
        public float DesiredPitchAngleInDegrees { get; }

        public float MainEnginesGimbalProportionalGain { get; }
        public float MainEnginesGimbalIntegralGain { get; }
        public float MainEnginesGimbalDerivativeGain { get; }

        public float? MainEnginesYawPercentOverwrite { get; }
        public float? MainEnginesRollPercentOverwrite { get; }
        public float? MainEnginesPitchPercentOverwrite { get; }

        public float FlapsYawProportionalGain { get; }
        public float FlapsYawIntegralGain { get; }
        public float FlapsYawDerivativeGain { get; }

        public float FlapsRollProportionalGain { get; }
        public float FlapsRollIntegralGain { get; }
        public float FlapsRollDerivativeGain { get; }

        public float FlapsPitchProportionalGain { get; }
        public float FlapsPitchIntegralGain { get; }
        public float FlapsPitchDerivativeGain { get; }

        public float? TopLeftFlapDeployPercentOverwrite { get; }
        public float? TopRightFlapDeployPercentOverwrite { get; }
        public float? BottomLeftFlapDeployPercentOverwrite { get; }
        public float? BottomRightFlapDeployPercentOverwrite { get; }


        public FlightSegmentConfig(
            Seconds takeoverSecondsInMission,
            float desiredVerticalVelocityInMetrePerSecond,
            float mainEnginesThrottleProportionalGain,
            float mainEnginesThrottleIntegralGain,
            float mainEnginesThrottleDerivativeGain,
            float? topMainEngineThrottlePercentOverwrite,
            float? bottomLeftMainEngineThrottlePercentOverwrite,
            float? bottomRightMainEngineThrottlePercentOverwrite,
            float desiredYawAngleInDegrees,
            float desiredRollAngleInDegrees,
            float desiredPitchAngleInDegrees,
            float mainEnginesGimbalProportionalGain,
            float mainEnginesGimbalIntegralGain,
            float mainEnginesGimbalDerivativeGain,
            float? mainEnginesYawPercentOverwrite,
            float? mainEnginesRollPercentOverwrite,
            float? mainEnginesPitchPercentOverwrite,
            float flapsYawProportionalGain,
            float flapsYawIntegralGain,
            float flapsYawDerivativeGain,
            float flapsRollProportionalGain,
            float flapsRollIntegralGain,
            float flapsRollDerivativeGain,
            float flapsPitchProportionalGain,
            float flapsPitchIntegralGain,
            float flapsPitchDerivativeGain,
            float? topLeftFlapDeployPercentOverwrite,
            float? topRightFlapDeployPercentOverwrite,
            float? bottomLeftFlapDeployPercentOverwrite,
            float? bottomRightFlapDeployPercentOverwrite)
        {
            TakeoverSecondsInMission = takeoverSecondsInMission;
            DesiredVerticalVelocityInMetrePerSecond = desiredVerticalVelocityInMetrePerSecond;
            MainEnginesThrottleProportionalGain = mainEnginesThrottleProportionalGain;
            MainEnginesThrottleIntegralGain = mainEnginesThrottleIntegralGain;
            MainEnginesThrottleDerivativeGain = mainEnginesThrottleDerivativeGain;
            TopMainEngineThrottlePercentOverwrite = topMainEngineThrottlePercentOverwrite;
            BottomLeftMainEngineThrottlePercentOverwrite = bottomLeftMainEngineThrottlePercentOverwrite;
            BottomRightMainEngineThrottlePercentOverwrite = bottomRightMainEngineThrottlePercentOverwrite;
            DesiredYawAngleInDegrees = desiredYawAngleInDegrees;
            DesiredRollAngleInDegrees = desiredRollAngleInDegrees;
            DesiredPitchAngleInDegrees = desiredPitchAngleInDegrees;
            MainEnginesGimbalProportionalGain = mainEnginesGimbalProportionalGain;
            MainEnginesGimbalIntegralGain = mainEnginesGimbalIntegralGain;
            MainEnginesGimbalDerivativeGain = mainEnginesGimbalDerivativeGain;
            MainEnginesYawPercentOverwrite = mainEnginesYawPercentOverwrite;
            MainEnginesRollPercentOverwrite = mainEnginesRollPercentOverwrite;
            MainEnginesPitchPercentOverwrite = mainEnginesPitchPercentOverwrite;
            FlapsYawProportionalGain = flapsYawProportionalGain;
            FlapsYawIntegralGain = flapsYawIntegralGain;
            FlapsYawDerivativeGain = flapsYawDerivativeGain;
            FlapsRollProportionalGain = flapsRollProportionalGain;
            FlapsRollIntegralGain = flapsRollIntegralGain;
            FlapsRollDerivativeGain = flapsRollDerivativeGain;
            FlapsPitchProportionalGain = flapsPitchProportionalGain;
            FlapsPitchIntegralGain = flapsPitchIntegralGain;
            FlapsPitchDerivativeGain = flapsPitchDerivativeGain;
            TopLeftFlapDeployPercentOverwrite = topLeftFlapDeployPercentOverwrite;
            TopRightFlapDeployPercentOverwrite = topRightFlapDeployPercentOverwrite;
            BottomLeftFlapDeployPercentOverwrite = bottomLeftFlapDeployPercentOverwrite;
            BottomRightFlapDeployPercentOverwrite = bottomRightFlapDeployPercentOverwrite;
        }

        public IEnumerable<TelemetryMessage> ProvideTelemetry() => new List<TelemetryMessage>
        {
            new TelemetryMessage($"TakeoverSecondsInMission:{TakeoverSecondsInMission}"),
            new TelemetryMessage($"DesiredVerticalVelocityInMetrePerSecond:{DesiredVerticalVelocityInMetrePerSecond}"),
            new TelemetryMessage($"MainEnginesThrottleProportionalGain:{MainEnginesThrottleProportionalGain}"),
            new TelemetryMessage($"MainEnginesThrottleIntegralGain:{MainEnginesThrottleIntegralGain}"),
            new TelemetryMessage($"MainEnginesThrottleDerivativeGain:{MainEnginesThrottleDerivativeGain}"),
            new TelemetryMessage($"TopMainEngineThrottlePercentOverwrite:{TopMainEngineThrottlePercentOverwrite}"),
            new TelemetryMessage($"BottomLeftMainEngineThrottlePercentOverwrite:{BottomLeftMainEngineThrottlePercentOverwrite}"),
            new TelemetryMessage($"BottomRightMainEngineThrottlePercentOverwrite:{BottomRightMainEngineThrottlePercentOverwrite}"),
            new TelemetryMessage($"DesiredYawAngleInDegrees:{DesiredYawAngleInDegrees}"),
            new TelemetryMessage($"DesiredRollAngleInDegrees:{DesiredRollAngleInDegrees}"),
            new TelemetryMessage($"DesiredPitchAngleInDegrees:{DesiredPitchAngleInDegrees}"),
            new TelemetryMessage($"MainEnginesGimbalProportionalGain:{MainEnginesGimbalProportionalGain}"),
            new TelemetryMessage($"MainEnginesGimbalIntegralGain:{MainEnginesGimbalIntegralGain}"),
            new TelemetryMessage($"MainEnginesGimbalDerivativeGain:{MainEnginesGimbalDerivativeGain}"),
            new TelemetryMessage($"MainEnginesYawPercentOverwrite:{MainEnginesYawPercentOverwrite}"),
            new TelemetryMessage($"MainEnginesRollPercentOverwrite:{MainEnginesRollPercentOverwrite}"),
            new TelemetryMessage($"MainEnginesPitchPercentOverwrite:{MainEnginesPitchPercentOverwrite}"),
            new TelemetryMessage($"FlapsYawProportionalGain:{FlapsYawProportionalGain}"),
            new TelemetryMessage($"FlapsYawIntegralGain:{FlapsYawIntegralGain}"),
            new TelemetryMessage($"FlapsYawDerivativeGain:{FlapsYawDerivativeGain}"),
            new TelemetryMessage($"FlapsRollProportionalGain:{FlapsRollProportionalGain}"),
            new TelemetryMessage($"FlapsRollIntegralGain:{FlapsRollIntegralGain}"),
            new TelemetryMessage($"FlapsRollDerivativeGain:{FlapsRollDerivativeGain}"),
            new TelemetryMessage($"FlapsPitchProportionalGain:{FlapsPitchProportionalGain}"),
            new TelemetryMessage($"FlapsPitchIntegralGain:{FlapsPitchIntegralGain}"),
            new TelemetryMessage($"FlapsPitchDerivativeGain:{FlapsPitchDerivativeGain}"),
            new TelemetryMessage($"TopLeftFlapDeployPercentOverwrite:{TopLeftFlapDeployPercentOverwrite}"),
            new TelemetryMessage($"TopRightFlapDeployPercentOverwrite:{TopRightFlapDeployPercentOverwrite}"),
            new TelemetryMessage($"BottomLeftFlapDeployPercentOverwrite:{BottomLeftFlapDeployPercentOverwrite}"),
            new TelemetryMessage($"BottomRightFlapDeployPercentOverwrite:{BottomRightFlapDeployPercentOverwrite}")
        };
    }
}