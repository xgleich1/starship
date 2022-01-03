using System.Collections.Generic;
using Starship.Telemetry;

namespace Starship.Flight.Command.Actuation.Flap
{
    public readonly struct ActuateBottomRightFlapCommand : ITelemetryProvider
    {
        public float DeployPercent { get; }


        public ActuateBottomRightFlapCommand(float deployPercent) =>
            DeployPercent = deployPercent;

        public IEnumerable<TelemetryMessage> ProvideTelemetry() => new List<TelemetryMessage>
        {
            new TelemetryMessage($"BottomRightFlapDeployPercent:{DeployPercent}")
        };
    }
}