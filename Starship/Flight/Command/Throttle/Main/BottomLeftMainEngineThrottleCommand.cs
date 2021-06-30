using System.Collections.Generic;
using Starship.Telemetry;

namespace Starship.Flight.Command.Throttle.Main
{
    public sealed class BottomLeftMainEngineThrottleCommand : ITelemetryProvider
    {
        public float ThrottlePercent { get; }


        public BottomLeftMainEngineThrottleCommand(float throttlePercent)
        {
            ThrottlePercent = throttlePercent;
        }

        public IEnumerable<TelemetryMessage> ProvideTelemetry() => new List<TelemetryMessage>
        {
            new TelemetryMessage($"BottomLeftMainEngineThrottlePercent:{ThrottlePercent}")
        };
    }
}