using static System.IO.Directory;

namespace Starship.Flight.Segment.Config
{
    public sealed class FlightSegmentConfigsPath : IFlightSegmentConfigsPath
    {
        public string RawPath =>
            $@"{GetCurrentDirectory()}\GameData\FlightComputer\Configs\flight_segment_configs.xml";
    }
}