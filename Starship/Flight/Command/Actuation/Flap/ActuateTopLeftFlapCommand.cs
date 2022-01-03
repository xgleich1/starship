using System.Collections.Generic;
using Starship.Telemetry;

namespace Starship.Flight.Command.Actuation.Flap
{
    public readonly struct ActuateTopLeftFlapCommand : ITelemetryProvider
    {
        public float DeployPercent { get; }


        public ActuateTopLeftFlapCommand(float deployPercent) =>
            DeployPercent = deployPercent;

        public IEnumerable<TelemetryMessage> ProvideTelemetry() => new List<TelemetryMessage>
        {
            new TelemetryMessage($"TopLeftFlapDeployPercent:{DeployPercent}")
        };
    }
}