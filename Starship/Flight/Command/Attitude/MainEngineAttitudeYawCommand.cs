using System.Collections.Generic;
using Starship.Telemetry;

namespace Starship.Flight.Command.Attitude
{
    public readonly struct MainEngineAttitudeYawCommand : ITelemetryProvider
    {
        public float YawInput { get; }


        public MainEngineAttitudeYawCommand(float yawInput) =>
            YawInput = yawInput;

        public IEnumerable<TelemetryMessage> ProvideTelemetry() => new List<TelemetryMessage>
        {
            new TelemetryMessage($"MainEngineAttitudeYawInput:{YawInput}")
        };
    }
}