using System.Collections.Generic;
using Starship.Telemetry;

namespace Starship.Flight.Command.Attitude
{
    public sealed class MainEngineAttitudePitchCommand : ITelemetryProvider
    {
        public float PitchInput { get; }


        public MainEngineAttitudePitchCommand(float pitchInput)
        {
            PitchInput = pitchInput;
        }

        public IEnumerable<TelemetryMessage> ProvideTelemetry() => new List<TelemetryMessage>
        {
            new TelemetryMessage($"MainEngineAttitudePitchInput:{PitchInput}")
        };
    }
}