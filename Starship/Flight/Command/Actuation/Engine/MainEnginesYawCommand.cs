using System.Collections.Generic;
using Starship.Telemetry;
using Starship.Utility.Math;

namespace Starship.Flight.Command.Actuation.Engine
{
    public readonly struct MainEnginesYawCommand : ITelemetryProvider
    {
        public float YawPercent => _unclampedYawPercent.Clamp(-1.0F, 1.0F);

        private readonly float _unclampedYawPercent;


        public MainEnginesYawCommand(float yawPercent) => _unclampedYawPercent = yawPercent;

        public IEnumerable<TelemetryMessage> ProvideTelemetry() => new List<TelemetryMessage>
        {
            new TelemetryMessage($"MainEnginesYawPercent:{_unclampedYawPercent}")
        };
    }
}