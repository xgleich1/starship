using System.Collections.Generic;
using Starship.Telemetry;

namespace Starship.Flight.Command.Throttle.Rcs
{
    public readonly struct ThrottleTopRightRcsEngineCommand : ITelemetryProvider
    {
        public float ThrottlePercent { get; }


        public ThrottleTopRightRcsEngineCommand(float throttlePercent) =>
            ThrottlePercent = throttlePercent;

        public IEnumerable<TelemetryMessage> ProvideTelemetry() => new List<TelemetryMessage>
        {
            new TelemetryMessage($"TopRightRcsEngineThrottlePercent:{ThrottlePercent}")
        };
    }
}