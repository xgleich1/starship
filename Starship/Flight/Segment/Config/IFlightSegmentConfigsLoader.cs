using System.Collections.Generic;

namespace Starship.Flight.Segment.Config
{
    public interface IFlightSegmentConfigsLoader
    {
        IEnumerable<IFlightSegmentConfig> LoadFlightSegmentConfigs();
    }
}