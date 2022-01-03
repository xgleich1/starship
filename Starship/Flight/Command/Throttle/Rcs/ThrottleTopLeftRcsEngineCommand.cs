using System.Collections.Generic;
using Starship.Telemetry;

namespace Starship.Flight.Command.Throttle.Rcs
{
    public readonly struct ThrottleTopLeftRcsEngineCommand : ITelemetryProvider
    {
        public float ThrottlePercent { get; }


        public ThrottleTopLeftRcsEngineCommand(float throttlePercent) =>
            ThrottlePercent = throttlePercent;

        public IEnumerable<TelemetryMessage> ProvideTelemetry() => new List<TelemetryMessage>
        {
            new TelemetryMessage($"TopLeftRcsEngineThrottlePercent:{ThrottlePercent}")
        };
    }
}