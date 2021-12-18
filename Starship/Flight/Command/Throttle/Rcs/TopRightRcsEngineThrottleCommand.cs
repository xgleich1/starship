using System.Collections.Generic;
using Starship.Telemetry;

namespace Starship.Flight.Command.Throttle.Rcs
{
    public readonly struct TopRightRcsEngineThrottleCommand : ITelemetryProvider
    {
        public float ThrottlePercent { get; }


        public TopRightRcsEngineThrottleCommand(float throttlePercent) =>
            ThrottlePercent = throttlePercent;

        public IEnumerable<TelemetryMessage> ProvideTelemetry() => new List<TelemetryMessage>
        {
            new TelemetryMessage($"TopRightRcsEngineThrottlePercent:{ThrottlePercent}")
        };
    }
}