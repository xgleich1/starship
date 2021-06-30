using System.Collections.Generic;
using Starship.Telemetry;

namespace Starship.Flight.Command.Throttle.Main
{
    public sealed class TopMainEngineThrottleCommand : ITelemetryProvider
    {
        public float ThrottlePercent { get; }


        public TopMainEngineThrottleCommand(float throttlePercent)
        {
            ThrottlePercent = throttlePercent;
        }

        public IEnumerable<TelemetryMessage> ProvideTelemetry() => new List<TelemetryMessage>
        {
            new TelemetryMessage($"TopMainEngineThrottlePercent:{ThrottlePercent}")
        };
    }
}