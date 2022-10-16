using System.Collections.Generic;
using Starship.Telemetry;
using Starship.Utility.Math;

namespace Starship.Flight.Command.Throttle.Main
{
    public readonly struct BottomLeftMainEngineThrottleCommand : ITelemetryProvider
    {
        public float ThrottlePercent => _unclampedThrottlePercent.Clamp(0.0F, 1.0F);

        private readonly float _unclampedThrottlePercent;


        public BottomLeftMainEngineThrottleCommand(float throttlePercent) => _unclampedThrottlePercent = throttlePercent;

        public IEnumerable<TelemetryMessage> ProvideTelemetry() => new List<TelemetryMessage>
        {
            new TelemetryMessage($"BottomLeftMainEngineThrottlePercent:{_unclampedThrottlePercent}")
        };
    }
}