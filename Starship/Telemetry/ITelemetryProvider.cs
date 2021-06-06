using System.Collections.Generic;

namespace Starship.Telemetry
{
    public interface ITelemetryProvider
    {
        IEnumerable<TelemetryMessage> ProvideTelemetry();
    }
}