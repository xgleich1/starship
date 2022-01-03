using Starship.Flight.Command;
using Starship.Sensor;
using Starship.Utility.Timing.Units;

namespace Starship.Flight.Segment
{
    // Currently under development
    public abstract class FlightSegmentCommander
    {
        public Seconds TakeoverSecondsInMission { get; }


        protected FlightSegmentCommander(Seconds takeoverSecondsInMission)
        {
            TakeoverSecondsInMission = takeoverSecondsInMission;
        }

        public abstract ICommandSuite CommandFlight(ISensorSuite sensorSuite);
    }
}