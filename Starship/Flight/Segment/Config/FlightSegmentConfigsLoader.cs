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
            flightSegmentConfigModel.MainEnginesThrottleProportionalGain,
            flightSegmentConfigModel.MainEnginesThrottleIntegralGain,
            flightSegmentConfigModel.MainEnginesThrottleDerivativeGain,
            flightSegmentConfigModel.TopMainEngineThrottlePercentOverwrite,
            flightSegmentConfigModel.BottomLeftMainEngineThrottlePercentOverwrite,
            flightSegmentConfigModel.BottomRightMainEngineThrottlePercentOverwrite,
            flightSegmentConfigModel.DesiredYawAngleInDegrees,
            flightSegmentConfigModel.DesiredRollAngleInDegrees,
            flightSegmentConfigModel.DesiredPitchAngleInDegrees,
            flightSegmentConfigModel.MainEnginesGimbalProportionalGain,
            flightSegmentConfigModel.MainEnginesGimbalIntegralGain,
            flightSegmentConfigModel.MainEnginesGimbalDerivativeGain,
            flightSegmentConfigModel.MainEnginesYawPercentOverwrite,
            flightSegmentConfigModel.MainEnginesRollPercentOverwrite,
            flightSegmentConfigModel.MainEnginesPitchPercentOverwrite,
            flightSegmentConfigModel.FlapsYawProportionalGain,
            flightSegmentConfigModel.FlapsYawIntegralGain,
            flightSegmentConfigModel.FlapsYawDerivativeGain,
            flightSegmentConfigModel.FlapsRollProportionalGain,
            flightSegmentConfigModel.FlapsRollIntegralGain,
            flightSegmentConfigModel.FlapsRollDerivativeGain,
            flightSegmentConfigModel.FlapsPitchProportionalGain,
            flightSegmentConfigModel.FlapsPitchIntegralGain,
            flightSegmentConfigModel.FlapsPitchDerivativeGain,
            flightSegmentConfigModel.TopLeftFlapDeployPercentOverwrite,
            flightSegmentConfigModel.TopRightFlapDeployPercentOverwrite,
            flightSegmentConfigModel.BottomLeftFlapDeployPercentOverwrite,
            flightSegmentConfigModel.BottomRightFlapDeployPercentOverwrite);
    }
}