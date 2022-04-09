namespace Starship.Flight.Segment
{
    public interface IFlightSegmentCommanders
    {
        IFlightSegmentCommander GetCurrentFlightSegmentCommander();
    }
}