using System.Collections.Generic;
using Starship.Telemetry;

namespace Starship.Flight.Command.Throttle.Main
{
    public readonly struct ThrottleTopMainEngineCommand : ITelemetryProvider
    {
        public float ThrottlePercent { get; }


        public ThrottleTopMainEngineCommand(float throttlePercent) =>
            ThrottlePercent = throttlePercent;

        public IEnumerable<TelemetryMessage> ProvideTelemetry() => new List<TelemetryMessage>
        {
            new TelemetryMessage($"TopMainEngineThrottlePercent:{ThrottlePercent}")
        };
    }
}