using System.Collections.Generic;
using Starship.Telemetry;

namespace Starship.Flight.Command.Throttle.Rcs
{
    public readonly struct BottomRightRcsEngineThrottleCommand : ITelemetryProvider
    {
        public float ThrottlePercent { get; }


        public BottomRightRcsEngineThrottleCommand(float throttlePercent) =>
            ThrottlePercent = throttlePercent;

        public IEnumerable<TelemetryMessage> ProvideTelemetry() => new List<TelemetryMessage>
        {
            new TelemetryMessage($"BottomRightRcsEngineThrottlePercent:{ThrottlePercent}")
        };
    }
}