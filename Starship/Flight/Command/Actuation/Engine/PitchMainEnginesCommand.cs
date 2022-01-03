using System.Collections.Generic;
using Starship.Telemetry;

namespace Starship.Flight.Command.Actuation.Engine
{
    public readonly struct PitchMainEnginesCommand : ITelemetryProvider
    {
        public float PitchPercent { get; }


        public PitchMainEnginesCommand(float pitchPercent) =>
            PitchPercent = pitchPercent;

        public IEnumerable<TelemetryMessage> ProvideTelemetry() => new List<TelemetryMessage>
        {
            new TelemetryMessage($"MainEnginesPitchPercent:{PitchPercent}")
        };
    }
}