using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using Starship.Flight.Segment.Config.Path;
using Starship.Utility.Timing.Units;

namespace Starship.Flight.Segment.Config
{
    // Currently under development
    public sealed class FlightSegmentConfigsLoader : IFlightSegmentConfigsLoader
    {
        private readonly IFlightSegmentConfigsPath _flightSegmentConfigsPath;


        public FlightSegmentConfigsLoader(IFlightSegmentConfigsPath flightSegmentConfigsPath)
        {
            _flightSegmentConfigsPath = flightSegmentConfigsPath;
        }

        public IEnumerable<IFlightSegmentConfig> LoadFlightSegmentConfigs()
        {
            using (var flightSegmentConfigsFile = File.OpenRead(_flightSegmentConfigsPath.RawPath))
            {
                var xmlSerializer = new XmlSerializer(typeof(List<FlightSegmentConfigModel>));

                var flightSegmentConfigModels = xmlSerializer
                    .Deserialize(flightSegmentConfigsFile) as List<FlightSegmentConfigModel>;

                return flightSegmentConfigModels.Select(MapFlightSegmentModelToConfig);
            }
        }

        private static IFlightSegmentConfig MapFlightSegmentModelToConfig(
            FlightSegmentConfigModel flightSegmentConfigModel
        ) => new FlightSegmentConfig(
            new Seconds(flightSegmentConfigModel.TakeoverSecondsInMission),
            flightSegmentConfigModel.DesiredVerticalVelocityInMetrePerSecond,
            flightSegmentConfigModel.ThrottleTopMainEngineProportionalGain,
            flightSegmentConfigModel.ThrottleBottomLeftMainEngineProportionalGain,
            flightSegmentConfigModel.ThrottleBottomRightMainEngineProportionalGain,
            flightSegmentConfigModel.TopMainEngineThrottlePercentOverwrite,
            flightSegmentConfigModel.BottomLeftMainEngineThrottlePercentOverwrite,
            flightSegmentConfigModel.BottomRightMainEngineThrottlePercentOverwrite,
            flightSegmentConfigModel.DesiredYawAngleInDegrees,
            flightSegmentConfigModel.DesiredRollAngleInDegrees,
            flightSegmentConfigModel.DesiredPitchAngleInDegrees,
            flightSegmentConfigModel.YawWithMainEnginesProportionalGain,
            flightSegmentConfigModel.RollWithMainEnginesProportionalGain,
            flightSegmentConfigModel.PitchWithMainEnginesProportionalGain,
            flightSegmentConfigModel.MainEnginesYawPercentOverwrite,
            flightSegmentConfigModel.MainEnginesRollPercentOverwrite,
            flightSegmentConfigModel.MainEnginesPitchPercentOverwrite,
            flightSegmentConfigModel.YawWithFlapsProportionalGain,
            flightSegmentConfigModel.RollWithFlapsProportionalGain,
            flightSegmentConfigModel.PitchWithFlapsProportionalGain,
            flightSegmentConfigModel.TopLeftFlapDeployPercentOverwrite,
            flightSegmentConfigModel.TopRightFlapDeployPercentOverwrite,
            flightSegmentConfigModel.BottomLeftFlapDeployPercentOverwrite,
            flightSegmentConfigModel.BottomRightFlapDeployPercentOverwrite);
    }
}