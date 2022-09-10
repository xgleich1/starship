using System.Collections.Generic;
using Starship.Telemetry;

namespace Starship.Flight.Command.Actuation.Flap
{
    public readonly struct BottomRightFlapActuationCommand : ITelemetryProvider
    {
        public float DeployPercent { get; }


        public BottomRightFlapActuationCommand(float deployPercent) => DeployPercent = deployPercent;

        public IEnumerable<TelemetryMessage> ProvideTelemetry() => new List<TelemetryMessage>
        {
            new TelemetryMessage($"BottomRightFlapDeployPercent:{DeployPercent}")
        };
    }
}