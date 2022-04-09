using Starship.Flight.Command;
using Starship.Sensor;
using Starship.Telemetry;

namespace Starship.Flight.Segment
{
    public interface IFlightSegmentCommander : ITelemetryProvider
    {
        ICommandSuite CommandFlight(ISensorSuite sensorSuite);
    }
}