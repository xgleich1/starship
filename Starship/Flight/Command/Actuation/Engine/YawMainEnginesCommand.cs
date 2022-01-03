using System.Collections.Generic;
using Starship.Telemetry;

namespace Starship.Flight.Command.Actuation.Engine
{
    public readonly struct YawMainEnginesCommand : ITelemetryProvider
    {
        public float YawPercent { get; }


        public YawMainEnginesCommand(float yawPercent) =>
            YawPercent = yawPercent;

        public IEnumerable<TelemetryMessage> ProvideTelemetry() => new List<TelemetryMessage>
        {
            new TelemetryMessage($"MainEnginesYawPercent:{YawPercent}")
        };
    }
}