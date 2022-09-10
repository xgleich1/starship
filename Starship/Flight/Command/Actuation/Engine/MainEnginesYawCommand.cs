using System.Collections.Generic;
using Starship.Telemetry;

namespace Starship.Flight.Command.Actuation.Engine
{
    public readonly struct MainEnginesYawCommand : ITelemetryProvider
    {
        public float YawPercent { get; }


        public MainEnginesYawCommand(float yawPercent) => YawPercent = yawPercent;

        public IEnumerable<TelemetryMessage> ProvideTelemetry() => new List<TelemetryMessage>
        {
            new TelemetryMessage($"MainEnginesYawPercent:{YawPercent}")
        };
    }
}