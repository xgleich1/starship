using System.Collections.Generic;
using Starship.Telemetry;

namespace Starship.Flight.Command.Actuation.Flap
{
    public readonly struct TopRightFlapActuationCommand : ITelemetryProvider
    {
        public float DeployPercent { get; }


        public TopRightFlapActuationCommand(float deployPercent) => DeployPercent = deployPercent;

        public IEnumerable<TelemetryMessage> ProvideTelemetry() => new List<TelemetryMessage>
        {
            new TelemetryMessage($"TopRightFlapDeployPercent:{DeployPercent}")
        };
    }
}