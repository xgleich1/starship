using System.Collections.Generic;
using Starship.Telemetry;

namespace Starship.Flight.Command.Actuation.Engine
{
    public readonly struct RollMainEnginesCommand : ITelemetryProvider
    {
        public float RollPercent { get; }


        public RollMainEnginesCommand(float rollPercent) =>
            RollPercent = rollPercent;

        public IEnumerable<TelemetryMessage> ProvideTelemetry() => new List<TelemetryMessage>
        {
            new TelemetryMessage($"MainEnginesRollPercent:{RollPercent}")
        };
    }
}