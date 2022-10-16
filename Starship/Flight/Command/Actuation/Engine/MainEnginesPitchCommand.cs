using System.Collections.Generic;
using Starship.Telemetry;
using Starship.Utility.Math;

namespace Starship.Flight.Command.Actuation.Engine
{
    public readonly struct MainEnginesPitchCommand : ITelemetryProvider
    {
        public float PitchPercent => _unclampedPitchPercent.Clamp(-1.0F, 1.0F);

        private readonly float _unclampedPitchPercent;


        public MainEnginesPitchCommand(float pitchPercent) => _unclampedPitchPercent = pitchPercent;

        public IEnumerable<TelemetryMessage> ProvideTelemetry() => new List<TelemetryMessage>
        {
            new TelemetryMessage($"MainEnginesPitchPercent:{_unclampedPitchPercent}")
        };
    }
}