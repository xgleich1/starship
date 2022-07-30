using Starship.Flight.Command;
using Starship.Sensor;
using Starship.Telemetry;

namespace Starship.Flight.Segment
{
    public interface IFlightSegmentCommander : ITelemetryProvider
    {
        bool CanHandover(ISensorSuite sensorSuite);

        ICommandSuite CommandFlight(ISensorSuite sensorSuite);
    }
}