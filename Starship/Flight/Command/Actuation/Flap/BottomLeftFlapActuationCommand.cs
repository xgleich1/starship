using System.Collections.Generic;
using Starship.Telemetry;
using Starship.Utility.Math;

namespace Starship.Flight.Command.Actuation.Flap
{
    public readonly struct BottomLeftFlapActuationCommand : ITelemetryProvider
    {
        public float DeployPercent => _unclampedDeployPercent.Clamp(0.0F, 1.0F);

        private readonly float _unclampedDeployPercent;


        public BottomLeftFlapActuationCommand(float deployPercent) => _unclampedDeployPercent = deployPercent;

        public IEnumerable<TelemetryMessage> ProvideTelemetry() => new List<TelemetryMessage>
        {
            new TelemetryMessage($"BottomLeftFlapDeployPercent:{_unclampedDeployPercent}")
        };
    }
}