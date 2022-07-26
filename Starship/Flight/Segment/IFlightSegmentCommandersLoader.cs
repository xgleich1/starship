using System.Collections.Generic;

namespace Starship.Flight.Segment
{
    public interface IFlightSegmentCommandersLoader
    {
        List<IFlightSegmentCommander> LoadFlightSegmentCommanders();
    }
}