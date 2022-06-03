using Starship.Flight.Command;
using Starship.Sensor;
using Starship.Telemetry;
using Starship.Utility.Timing.Units;

namespace Starship.Flight.Segment
{
    public interface IFlightSegmentCommander : ITelemetryProvider
    {
        Seconds TakeoverSecondsInMission { get; }


        ICommandSuite CommandFlight(ISensorSuite sensorSuite);
    }
}