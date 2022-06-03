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

        public float ThrottleTopMainEngineProportionalGain { get; }
        public float ThrottleBottomLeftMainEngineProportionalGain { get; }
        public float ThrottleBottomRightMainEngineProportionalGain { get; }

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
            float desiredVerticalVelocityInMetrePerSecond,
            float throttleTopMainEngineProportionalGain,
            float throttleBottomLeftMainEngineProportionalGain,
            float throttleBottomRightMainEngineProportionalGain,
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
            DesiredVerticalVelocityInMetrePerSecond = desiredVerticalVelocityInMetrePerSecond;
            ThrottleTopMainEngineProportionalGain = throttleTopMainEngineProportionalGain;
            ThrottleBottomLeftMainEngineProportionalGain = throttleBottomLeftMainEngineProportionalGain;
            ThrottleBottomRightMainEngineProportionalGain = throttleBottomRightMainEngineProportionalGain;
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
            new TelemetryMessage($"TakeoverSecondsInMission:{TakeoverSecondsInMission}"),
            new TelemetryMessage($"DesiredVerticalVelocityInMetrePerSecond:{DesiredVerticalVelocityInMetrePerSecond}"),
            new TelemetryMessage($"ThrottleTopMainEngineProportionalGain:{ThrottleTopMainEngineProportionalGain}"),
            new TelemetryMessage($"ThrottleBottomLeftMainEngineProportionalGain:{ThrottleBottomLeftMainEngineProportionalGain}"),
            new TelemetryMessage($"ThrottleBottomRightMainEngineProportionalGain:{ThrottleBottomRightMainEngineProportionalGain}"),
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