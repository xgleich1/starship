using System.Collections.Generic;
using Starship.Telemetry;

namespace Starship.Flight.Command.Actuation.Leg
{
    public readonly struct ActuateLegsCommand : ITelemetryProvider
    {
        public bool Extended { get; }


        public ActuateLegsCommand(bool extended) =>
            Extended = extended;

        public IEnumerable<TelemetryMessage> ProvideTelemetry() => new List<TelemetryMessage>
        {
            new TelemetryMessage($"LegsExtended:{Extended}")
        };
    }
}