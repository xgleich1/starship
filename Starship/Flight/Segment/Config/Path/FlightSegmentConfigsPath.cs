using static System.IO.Directory;

namespace Starship.Flight.Segment.Config.Path
{
    public sealed class FlightSegmentConfigsPath : IFlightSegmentConfigsPath
    {
        public string RawPath =>
            $@"{GetCurrentDirectory()}\GameData\FlightComputer\Scripts\flight_segment_configs.xml";
    }
}