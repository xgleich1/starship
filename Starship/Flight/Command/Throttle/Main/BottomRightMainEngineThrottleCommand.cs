using System.Collections.Generic;
using Starship.Telemetry;
using Starship.Utility.Math;

namespace Starship.Flight.Command.Throttle.Main
{
    public readonly struct BottomRightMainEngineThrottleCommand : ITelemetryProvider
    {
        public float ThrottlePercent => _unclampedThrottlePercent.Clamp(0.0F, 1.0F);

        private readonly float _unclampedThrottlePercent;


        public BottomRightMainEngineThrottleCommand(float throttlePercent) => _unclampedThrottlePercent = throttlePercent;

        public IEnumerable<TelemetryMessage> ProvideTelemetry() => new List<TelemetryMessage>
        {
            new TelemetryMessage($"BottomRightMainEngineThrottlePercent:{_unclampedThrottlePercent}")
        };
    }
}