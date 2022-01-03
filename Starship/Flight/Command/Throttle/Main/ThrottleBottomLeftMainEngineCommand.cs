using System.Collections.Generic;
using Starship.Telemetry;

namespace Starship.Flight.Command.Throttle.Main
{
    public readonly struct ThrottleBottomLeftMainEngineCommand : ITelemetryProvider
    {
        public float ThrottlePercent { get; }


        public ThrottleBottomLeftMainEngineCommand(float throttlePercent) =>
            ThrottlePercent = throttlePercent;

        public IEnumerable<TelemetryMessage> ProvideTelemetry() => new List<TelemetryMessage>
        {
            new TelemetryMessage($"BottomLeftMainEngineThrottlePercent:{ThrottlePercent}")
        };
    }
}