using System.Collections.Generic;
using Starship.Telemetry;

namespace Starship.Flight.Command.Actuation.Flap
{
    public readonly struct TopLeftFlapActuationCommand : ITelemetryProvider
    {
        public float DeployPercent { get; }


        public TopLeftFlapActuationCommand(float deployPercent) => DeployPercent = deployPercent;

        public IEnumerable<TelemetryMessage> ProvideTelemetry() => new List<TelemetryMessage>
        {
            new TelemetryMessage($"TopLeftFlapDeployPercent:{DeployPercent}")
        };
    }
}