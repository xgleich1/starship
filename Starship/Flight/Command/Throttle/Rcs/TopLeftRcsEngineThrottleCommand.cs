using System.Collections.Generic;
using Starship.Telemetry;

namespace Starship.Flight.Command.Throttle.Rcs
{
    public sealed class TopLeftRcsEngineThrottleCommand : ITelemetryProvider
    {
        public float ThrottlePercent { get; }


        public TopLeftRcsEngineThrottleCommand(float throttlePercent)
        {
            ThrottlePercent = throttlePercent;
        }

        public IEnumerable<TelemetryMessage> ProvideTelemetry() => new List<TelemetryMessage>
        {
            new TelemetryMessage($"TopLeftRcsEngineThrottlePercent:{ThrottlePercent}")
        };
    }
}