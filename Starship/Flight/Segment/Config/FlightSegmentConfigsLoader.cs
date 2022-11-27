using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace Starship.Flight.Segment.Config
{
    public sealed class FlightSegmentConfigsLoader : IFlightSegmentConfigsLoader
    {
        private readonly IFlightSegmentConfigsPath _flightSegmentConfigsPath;


        public FlightSegmentConfigsLoader(IFlightSegmentConfigsPath flightSegmentConfigsPath) =>
            _flightSegmentConfigsPath = flightSegmentConfigsPath;

        public IEnumerable<FlightSegmentConfig> LoadFlightSegmentConfigs()
        {
            using (var flightSegmentConfigsFile = File.OpenRead(_flightSegmentConfigsPath.RawPath))
            {
                var xmlSerializer = new XmlSerializer(typeof(List<FlightSegmentConfigModel>));

                var flightSegmentConfigModels = xmlSerializer
                    .Deserialize(flightSegmentConfigsFile) as List<FlightSegmentConfigModel>;

                return flightSegmentConfigModels.Select(MapFlightSegmentModelToConfig).ToList();
            }
        }

        private static FlightSegmentConfig MapFlightSegmentModelToConfig(
            FlightSegmentConfigModel flightSegmentConfigModel
        ) => new FlightSegmentConfig(
            flightSegmentConfigModel.HandoverYawAngleInDegreesEqualOrOver,
            flightSegmentConfigModel.HandoverYawAngleInDegreesEqualOrUnder,
            flightSegmentConfigModel.HandoverRollAngleInDegreesEqualOrOver,
            flightSegmentConfigModel.HandoverRollAngleInDegreesEqualOrUnder,
            flightSegmentConfigModel.HandoverPitchAngleInDegreesEqualOrOver,
            flightSegmentConfigModel.HandoverPitchAngleInDegreesEqualOrUnder,
            flightSegmentConfigModel.HandoverAltitudeAboveTerrainInMetersEqualOrOver,
            flightSegmentConfigModel.HandoverAltitudeAboveTerrainInMetersEqualOrUnder,
            flightSegmentConfigModel.HandoverLateralVelocityInMetrePerSecondEqualOrOver,
            flightSegmentConfigModel.HandoverLateralVelocityInMetrePerSecondEqualOrUnder,
            flightSegmentConfigModel.HandoverVerticalVelocityInMetrePerSecondEqualOrOver,
            flightSegmentConfigModel.HandoverVerticalVelocityInMetrePerSecondEqualOrUnder,
            flightSegmentConfigModel.HandoverHorizontalVelocityInMetrePerSecondEqualOrOver,
            flightSegmentConfigModel.HandoverHorizontalVelocityInMetrePerSecondEqualOrUnder,
            flightSegmentConfigModel.DesiredLegsExtendedState,
            flightSegmentConfigModel.DesiredYawAngleInDegrees,
            flightSegmentConfigModel.DesiredRollAngleInDegrees,
            flightSegmentConfigModel.DesiredPitchAngleInDegrees,
            flightSegmentConfigModel.DesiredLateralVelocityInMetrePerSecond,
            flightSegmentConfigModel.DesiredVerticalVelocityInMetrePerSecond,
            flightSegmentConfigModel.DesiredHorizontalVelocityInMetrePerSecond,
            flightSegmentConfigModel.TopLeftRcsActivatedStateOverwrite,
            flightSegmentConfigModel.TopRightRcsActivatedStateOverwrite,
            flightSegmentConfigModel.BottomLeftRcsActivatedStateOverwrite,
            flightSegmentConfigModel.BottomRightRcsActivatedStateOverwrite,
            flightSegmentConfigModel.TopLeftFlapDeployPercentOverwrite,
            flightSegmentConfigModel.TopRightFlapDeployPercentOverwrite,
            flightSegmentConfigModel.BottomLeftFlapDeployPercentOverwrite,
            flightSegmentConfigModel.BottomRightFlapDeployPercentOverwrite,
            flightSegmentConfigModel.MainEnginesYawPercentOverwrite,
            flightSegmentConfigModel.MainEnginesRollPercentOverwrite,
            flightSegmentConfigModel.MainEnginesPitchPercentOverwrite,
            flightSegmentConfigModel.TopMainEngineThrottlePercentOverwrite,
            flightSegmentConfigModel.BottomLeftMainEngineThrottlePercentOverwrite,
            flightSegmentConfigModel.BottomRightMainEngineThrottlePercentOverwrite,
            flightSegmentConfigModel.RcsActivationPidRegulatorProportionalGain,
            flightSegmentConfigModel.RcsActivationPidRegulatorIntegralGain,
            flightSegmentConfigModel.RcsActivationPidRegulatorDerivativeGain,
            flightSegmentConfigModel.FlapsYawPidRegulatorProportionalGain,
            flightSegmentConfigModel.FlapsYawPidRegulatorIntegralGain,
            flightSegmentConfigModel.FlapsYawPidRegulatorDerivativeGain,
            flightSegmentConfigModel.FlapsRollPidRegulatorProportionalGain,
            flightSegmentConfigModel.FlapsRollPidRegulatorIntegralGain,
            flightSegmentConfigModel.FlapsRollPidRegulatorDerivativeGain,
            flightSegmentConfigModel.FlapsPitchPidRegulatorProportionalGain,
            flightSegmentConfigModel.FlapsPitchPidRegulatorIntegralGain,
            flightSegmentConfigModel.FlapsPitchPidRegulatorDerivativeGain,
            flightSegmentConfigModel.MainEnginesGimbalPidRegulatorProportionalGain,
            flightSegmentConfigModel.MainEnginesGimbalPidRegulatorIntegralGain,
            flightSegmentConfigModel.MainEnginesGimbalPidRegulatorDerivativeGain,
            flightSegmentConfigModel.LateralVelocityOffsetPidRegulatorProportionalGain,
            flightSegmentConfigModel.LateralVelocityOffsetPidRegulatorIntegralGain,
            flightSegmentConfigModel.LateralVelocityOffsetPidRegulatorDerivativeGain,
            flightSegmentConfigModel.MainEnginesThrottlePidRegulatorProportionalGain,
            flightSegmentConfigModel.MainEnginesThrottlePidRegulatorIntegralGain,
            flightSegmentConfigModel.MainEnginesThrottlePidRegulatorDerivativeGain,
            flightSegmentConfigModel.HorizontalVelocityOffsetPidRegulatorProportionalGain,
            flightSegmentConfigModel.HorizontalVelocityOffsetPidRegulatorIntegralGain,
            flightSegmentConfigModel.HorizontalVelocityOffsetPidRegulatorDerivativeGain
        );
    }
}