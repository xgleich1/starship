using System.Collections.Generic;
using Starship.Telemetry;

namespace Starship.Flight.Command.Throttle.Rcs
{
    public readonly struct ThrottleBottomLeftRcsEngineCommand : ITelemetryProvider
    {
        public float ThrottlePercent { get; }


        public ThrottleBottomLeftRcsEngineCommand(float throttlePercent) =>
            ThrottlePercent = throttlePercent;

        public IEnumerable<TelemetryMessage> ProvideTelemetry() => new List<TelemetryMessage>
        {
            new TelemetryMessage($"BottomLeftRcsEngineThrottlePercent:{ThrottlePercent}")
        };
    }
}