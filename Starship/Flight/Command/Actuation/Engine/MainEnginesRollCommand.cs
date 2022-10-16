using System.Collections.Generic;
using Starship.Telemetry;
using Starship.Utility.Math;

namespace Starship.Flight.Command.Actuation.Engine
{
    public readonly struct MainEnginesRollCommand : ITelemetryProvider
    {
        public float RollPercent => _unclampedRollPercent.Clamp(-1.0F, 1.0F);

        private readonly float _unclampedRollPercent;


        public MainEnginesRollCommand(float rollPercent) => _unclampedRollPercent = rollPercent;

        public IEnumerable<TelemetryMessage> ProvideTelemetry() => new List<TelemetryMessage>
        {
            new TelemetryMessage($"MainEnginesRollPercent:{_unclampedRollPercent}")
        };
    }
}