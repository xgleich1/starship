using System.Collections.Generic;
using Starship.Telemetry;
using Starship.Utility.Timing.Units;

namespace Starship.Flight.Segment.Config
{
    public readonly struct FlightSegmentConfig : ITelemetryProvider
    {
        public Seconds TakeoverSecondsInMission { get; }

        public float? TopMainEngineThrottlePercentOverwrite { get; }
        public float? BottomLeftMainEngineThrottlePercentOverwrite { get; }
        public float? BottomRightMainEngineThrottlePercentOverwrite { get; }

        public float DesiredYawAngleInDegrees { get; }
        public float DesiredRollAngleInDegrees { get; }
        public float DesiredPitchAngleInDegrees { get; }

        public float YawWithMainEnginesProportionalGain { get; }
        public float RollWithMainEnginesProportionalGain { get; }
        public float PitchWithMainEnginesProportionalGain { get; }

        public float? MainEnginesYawPercentOverwrite { get; }
        public float? MainEnginesRollPercentOverwrite { get; }
        public float? MainEnginesPitchPercentOverwrite { get; }

        public float YawWithFlapsProportionalGain { get; }
        public float RollWithFlapsProportionalGain { get; }
        public float PitchWithFlapsProportionalGain { get; }

        public float? TopLeftFlapDeployPercentOverwrite { get; }
        public float? TopRightFlapDeployPercentOverwrite { get; }
        public float? BottomLeftFlapDeployPercentOverwrite { get; }
        public float? BottomRightFlapDeployPercentOverwrite { get; }


        public FlightSegmentConfig(
            Seconds takeoverSecondsInMission,
            float? topMainEngineThrottlePercentOverwrite,
            float? bottomLeftMainEngineThrottlePercentOverwrite,
            float? bottomRightMainEngineThrottlePercentOverwrite,
            float desiredYawAngleInDegrees,
            float desiredRollAngleInDegrees,
            float desiredPitchAngleInDegrees,
            float yawWithMainEnginesProportionalGain,
            float rollWithMainEnginesProportionalGain,
            float pitchWithMainEnginesProportionalGain,
            float? mainEnginesYawPercentOverwrite,
            float? mainEnginesRollPercentOverwrite,
            float? mainEnginesPitchPercentOverwrite,
            float yawWithFlapsProportionalGain,
            float rollWithFlapsProportionalGain,
            float pitchWithFlapsProportionalGain,
            float? topLeftFlapDeployPercentOverwrite,
            float? topRightFlapDeployPercentOverwrite,
            float? bottomLeftFlapDeployPercentOverwrite,
            float? bottomRightFlapDeployPercentOverwrite)
        {
            TakeoverSecondsInMission = takeoverSecondsInMission;
            TopMainEngineThrottlePercentOverwrite = topMainEngineThrottlePercentOverwrite;
            BottomLeftMainEngineThrottlePercentOverwrite = bottomLeftMainEngineThrottlePercentOverwrite;
            BottomRightMainEngineThrottlePercentOverwrite = bottomRightMainEngineThrottlePercentOverwrite;
            DesiredYawAngleInDegrees = desiredYawAngleInDegrees;
            DesiredRollAngleInDegrees = desiredRollAngleInDegrees;
            DesiredPitchAngleInDegrees = desiredPitchAngleInDegrees;
            YawWithMainEnginesProportionalGain = yawWithMainEnginesProportionalGain;
            RollWithMainEnginesProportionalGain = rollWithMainEnginesProportionalGain;
            PitchWithMainEnginesProportionalGain = pitchWithMainEnginesProportionalGain;
            MainEnginesYawPercentOverwrite = mainEnginesYawPercentOverwrite;
            MainEnginesRollPercentOverwrite = mainEnginesRollPercentOverwrite;
            MainEnginesPitchPercentOverwrite = mainEnginesPitchPercentOverwrite;
            YawWithFlapsProportionalGain = yawWithFlapsProportionalGain;
            RollWithFlapsProportionalGain = rollWithFlapsProportionalGain;
            PitchWithFlapsProportionalGain = pitchWithFlapsProportionalGain;
            TopLeftFlapDeployPercentOverwrite = topLeftFlapDeployPercentOverwrite;
            TopRightFlapDeployPercentOverwrite = topRightFlapDeployPercentOverwrite;
            BottomLeftFlapDeployPercentOverwrite = bottomLeftFlapDeployPercentOverwrite;
            BottomRightFlapDeployPercentOverwrite = bottomRightFlapDeployPercentOverwrite;
        }

        public IEnumerable<TelemetryMessage> ProvideTelemetry() => new List<TelemetryMessage>
        {
            new TelemetryMessage($"TopMainEngineThrottlePercentOverwrite:{TopMainEngineThrottlePercentOverwrite}"),
            new TelemetryMessage($"BottomLeftMainEngineThrottlePercentOverwrite:{BottomLeftMainEngineThrottlePercentOverwrite}"),
            new TelemetryMessage($"BottomRightMainEngineThrottlePercentOverwrite:{BottomRightMainEngineThrottlePercentOverwrite}"),
            new TelemetryMessage($"DesiredYawAngleInDegrees:{DesiredYawAngleInDegrees}"),
            new TelemetryMessage($"DesiredRollAngleInDegrees:{DesiredRollAngleInDegrees}"),
            new TelemetryMessage($"DesiredPitchAngleInDegrees:{DesiredPitchAngleInDegrees}"),
            new TelemetryMessage($"YawWithMainEnginesProportionalGain:{YawWithMainEnginesProportionalGain}"),
            new TelemetryMessage($"RollWithMainEnginesProportionalGain:{RollWithMainEnginesProportionalGain}"),
            new TelemetryMessage($"PitchWithMainEnginesProportionalGain:{PitchWithMainEnginesProportionalGain}"),
            new TelemetryMessage($"MainEnginesYawPercentOverwrite:{MainEnginesYawPercentOverwrite}"),
            new TelemetryMessage($"MainEnginesRollPercentOverwrite:{MainEnginesRollPercentOverwrite}"),
            new TelemetryMessage($"MainEnginesPitchPercentOverwrite:{MainEnginesPitchPercentOverwrite}"),
            new TelemetryMessage($"YawWithFlapsProportionalGain:{YawWithFlapsProportionalGain}"),
            new TelemetryMessage($"RollWithFlapsProportionalGain:{RollWithFlapsProportionalGain}"),
            new TelemetryMessage($"PitchWithFlapsProportionalGain:{PitchWithFlapsProportionalGain}"),
            new TelemetryMessage($"TopLeftFlapDeployPercentOverwrite:{TopLeftFlapDeployPercentOverwrite}"),
            new TelemetryMessage($"TopRightFlapDeployPercentOverwrite:{TopRightFlapDeployPercentOverwrite}"),
            new TelemetryMessage($"BottomLeftFlapDeployPercentOverwrite:{BottomLeftFlapDeployPercentOverwrite}"),
            new TelemetryMessage($"BottomRightFlapDeployPercentOverwrite:{BottomRightFlapDeployPercentOverwrite}")
        };
    }
}