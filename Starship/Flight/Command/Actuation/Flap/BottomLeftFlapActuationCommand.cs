using System.Collections.Generic;
using Starship.Telemetry;

namespace Starship.Flight.Command.Actuation.Flap
{
    public readonly struct BottomLeftFlapActuationCommand : ITelemetryProvider
    {
        public float DeployPercent { get; }


        public BottomLeftFlapActuationCommand(float deployPercent) => DeployPercent = deployPercent;

        public IEnumerable<TelemetryMessage> ProvideTelemetry() => new List<TelemetryMessage>
        {
            new TelemetryMessage($"BottomLeftFlapDeployPercent:{DeployPercent}")
        };
    }
}