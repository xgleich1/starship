using System.Collections.Generic;
using Starship.Telemetry;

namespace Starship.Flight.Command.Throttle.Main
{
    public readonly struct ThrottleBottomRightMainEngineCommand : ITelemetryProvider
    {
        public float ThrottlePercent { get; }


        public ThrottleBottomRightMainEngineCommand(float throttlePercent) =>
            ThrottlePercent = throttlePercent;

        public IEnumerable<TelemetryMessage> ProvideTelemetry() => new List<TelemetryMessage>
        {
            new TelemetryMessage($"BottomRightMainEngineThrottlePercent:{ThrottlePercent}")
        };
    }
}