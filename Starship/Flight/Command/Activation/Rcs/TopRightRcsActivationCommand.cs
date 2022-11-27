using System.Collections.Generic;
using Starship.Telemetry;

namespace Starship.Flight.Command.Activation.Rcs
{
    public readonly struct TopRightRcsActivationCommand : ITelemetryProvider
    {
        public bool Activated { get; }


        public TopRightRcsActivationCommand(bool activated) => Activated = activated;

        public IEnumerable<TelemetryMessage> ProvideTelemetry() => new List<TelemetryMessage>
        {
            new TelemetryMessage($"TopRightRcsActivated:{Activated}")
        };
    }
}