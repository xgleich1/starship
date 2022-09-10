using System.Collections.Generic;
using Starship.Telemetry;

namespace Starship.Flight.Command.Actuation.Engine
{
    public readonly struct MainEnginesRollCommand : ITelemetryProvider
    {
        public float RollPercent { get; }


        public MainEnginesRollCommand(float rollPercent) => RollPercent = rollPercent;

        public IEnumerable<TelemetryMessage> ProvideTelemetry() => new List<TelemetryMessage>
        {
            new TelemetryMessage($"MainEnginesRollPercent:{RollPercent}")
        };
    }
}