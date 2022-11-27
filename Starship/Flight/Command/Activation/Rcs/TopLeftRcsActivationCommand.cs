using System.Collections.Generic;
using Starship.Telemetry;

namespace Starship.Flight.Command.Activation.Rcs
{
    public readonly struct TopLeftRcsActivationCommand : ITelemetryProvider
    {
        public bool Activated { get; }


        public TopLeftRcsActivationCommand(bool activated) => Activated = activated;

        public IEnumerable<TelemetryMessage> ProvideTelemetry() => new List<TelemetryMessage>
        {
            new TelemetryMessage($"TopLeftRcsActivated:{Activated}")
        };
    }
}