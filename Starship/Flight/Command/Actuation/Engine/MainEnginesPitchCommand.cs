using System.Collections.Generic;
using Starship.Telemetry;

namespace Starship.Flight.Command.Actuation.Engine
{
    public readonly struct MainEnginesPitchCommand : ITelemetryProvider
    {
        public float PitchPercent { get; }


        public MainEnginesPitchCommand(float pitchPercent) => PitchPercent = pitchPercent;

        public IEnumerable<TelemetryMessage> ProvideTelemetry() => new List<TelemetryMessage>
        {
            new TelemetryMessage($"MainEnginesPitchPercent:{PitchPercent}")
        };
    }
}