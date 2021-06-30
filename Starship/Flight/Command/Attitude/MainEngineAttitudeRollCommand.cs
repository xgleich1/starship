using System.Collections.Generic;
using Starship.Telemetry;

namespace Starship.Flight.Command.Attitude
{
    public sealed class MainEngineAttitudeRollCommand : ITelemetryProvider
    {
        public float RollInput { get; }


        public MainEngineAttitudeRollCommand(float rollInput)
        {
            RollInput = rollInput;
        }

        public IEnumerable<TelemetryMessage> ProvideTelemetry() => new List<TelemetryMessage>
        {
            new TelemetryMessage($"MainEngineAttitudeRollInput:{RollInput}")
        };
    }
}