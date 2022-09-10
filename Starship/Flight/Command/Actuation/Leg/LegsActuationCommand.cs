using System.Collections.Generic;
using Starship.Telemetry;

namespace Starship.Flight.Command.Actuation.Leg
{
    public readonly struct LegsActuationCommand : ITelemetryProvider
    {
        public bool Extended { get; }


        public LegsActuationCommand(bool extended) => Extended = extended;

        public IEnumerable<TelemetryMessage> ProvideTelemetry() => new List<TelemetryMessage>
        {
            new TelemetryMessage($"LegsExtended:{Extended}")
        };
    }
}