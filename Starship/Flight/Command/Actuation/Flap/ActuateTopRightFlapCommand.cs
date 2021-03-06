using System.Collections.Generic;
using Starship.Telemetry;

namespace Starship.Flight.Command.Actuation.Flap
{
    public readonly struct ActuateTopRightFlapCommand : ITelemetryProvider
    {
        public float DeployPercent { get; }


        public ActuateTopRightFlapCommand(float deployPercent) =>
            DeployPercent = deployPercent;

        public IEnumerable<TelemetryMessage> ProvideTelemetry() => new List<TelemetryMessage>
        {
            new TelemetryMessage($"TopRightFlapDeployPercent:{DeployPercent}")
        };
    }
}