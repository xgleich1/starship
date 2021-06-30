using System.Collections.Generic;
using Starship.Telemetry;

namespace Starship.Flight.Command.Throttle.Rcs
{
    public sealed class BottomLeftRcsEngineThrottleCommand : ITelemetryProvider
    {
        public float ThrottlePercent { get; }


        public BottomLeftRcsEngineThrottleCommand(float throttlePercent)
        {
            ThrottlePercent = throttlePercent;
        }

        public IEnumerable<TelemetryMessage> ProvideTelemetry() => new List<TelemetryMessage>
        {
            new TelemetryMessage($"BottomLeftRcsEngineThrottlePercent:{ThrottlePercent}")
        };
    }
}