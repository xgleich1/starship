using System.Collections.Generic;
using Starship.Telemetry;

namespace Starship.Flight.Command.Actuation.Flap
{
    public readonly struct ActuateBottomLeftFlapCommand : ITelemetryProvider
    {
        public float DeployPercent { get; }


        public ActuateBottomLeftFlapCommand(float deployPercent) =>
            DeployPercent = deployPercent;

        public IEnumerable<TelemetryMessage> ProvideTelemetry() => new List<TelemetryMessage>
        {
            new TelemetryMessage($"BottomLeftFlapDeployPercent:{DeployPercent}")
        };
    }
}