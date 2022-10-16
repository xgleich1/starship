using System.Collections.Generic;
using NUnit.Framework;
using Starship.Flight.Segment.Config;
using static System.IO.Directory;

namespace StarshipUnitTests.Flight.Segment.Config
{
    public sealed class FlightSegmentConfigsLoaderTest
    {
        [Test]
        public void Should_load_serialized_flight_segment_configs_with_all_nullables()
        {
            // GIVEN
            var flightSegmentConfigsLoader = CreateFlightSegmentConfigsLoader(
                "test_flight_segment_configs_with_nullables.xml");

            // WHEN
            var flightSegmentConfigs = flightSegmentConfigsLoader.LoadFlightSegmentConfigs();

            // THEN
            var expectedFlightSegmentConfigs = new List<FlightSegmentConfig>
            {
                new FlightSegmentConfig(
                    handoverYawAngleInDegreesEqualOrOver: 0.01F,
                    handoverYawAngleInDegreesEqualOrUnder: 0.02F,
                    handoverRollAngleInDegreesEqualOrOver: 0.03F,
                    handoverRollAngleInDegreesEqualOrUnder: 0.04F,
                    handoverPitchAngleInDegreesEqualOrOver: 0.05F,
                    handoverPitchAngleInDegreesEqualOrUnder: 0.06F,
                    handoverAltitudeAboveTerrainInMetersEqualOrOver: 0.07F,
                    handoverAltitudeAboveTerrainInMetersEqualOrUnder: 0.08F,
                    handoverLateralVelocityInMetrePerSecondEqualOrOver: 0.09F,
                    handoverLateralVelocityInMetrePerSecondEqualOrUnder: 0.10F,
                    handoverVerticalVelocityInMetrePerSecondEqualOrOver: 0.11F,
                    handoverVerticalVelocityInMetrePerSecondEqualOrUnder: 0.12F,
                    handoverHorizontalVelocityInMetrePerSecondEqualOrOver: 0.13F,
                    handoverHorizontalVelocityInMetrePerSecondEqualOrUnder: 0.14F,
                    desiredLegsExtendedState: false,
                    desiredYawAngleInDegrees: 0.15F,
                    desiredRollAngleInDegrees: 0.16F,
                    desiredPitchAngleInDegrees: 0.17F,
                    desiredLateralVelocityInMetrePerSecond: 0.18F,
                    desiredVerticalVelocityInMetrePerSecond: 0.19F,
                    desiredHorizontalVelocityInMetrePerSecond: 0.20F,
                    topLeftFlapDeployPercentOverwrite: 0.21F,
                    topRightFlapDeployPercentOverwrite: 0.22F,
                    bottomLeftFlapDeployPercentOverwrite: 0.23F,
                    bottomRightFlapDeployPercentOverwrite: 0.24F,
                    mainEnginesYawPercentOverwrite: 0.25F,
                    mainEnginesRollPercentOverwrite: 0.26F,
                    mainEnginesPitchPercentOverwrite: 0.27F,
                    topMainEngineThrottlePercentOverwrite: 0.28F,
                    bottomLeftMainEngineThrottlePercentOverwrite: 0.29F,
                    bottomRightMainEngineThrottlePercentOverwrite: 0.30F,
                    flapsActuationPidRegulatorProportionalGain: 0.31F,
                    flapsActuationPidRegulatorIntegralGain: 0.32F,
                    flapsActuationPidRegulatorDerivativeGain: 0.33F,
                    mainEnginesGimbalPidRegulatorProportionalGain: 0.34F,
                    mainEnginesGimbalPidRegulatorIntegralGain: 0.35F,
                    mainEnginesGimbalPidRegulatorDerivativeGain: 0.36F,
                    lateralVelocityOffsetPidRegulatorProportionalGain: 0.37F,
                    lateralVelocityOffsetPidRegulatorIntegralGain: 0.38F,
                    lateralVelocityOffsetPidRegulatorDerivativeGain: 0.39F,
                    mainEnginesThrottlePidRegulatorProportionalGain: 0.40F,
                    mainEnginesThrottlePidRegulatorIntegralGain: 0.41F,
                    mainEnginesThrottlePidRegulatorDerivativeGain: 0.42F,
                    horizontalVelocityOffsetPidRegulatorProportionalGain: 0.43F,
                    horizontalVelocityOffsetPidRegulatorIntegralGain: 0.44F,
                    horizontalVelocityOffsetPidRegulatorDerivativeGain: 0.45F),
                new FlightSegmentConfig(
                    handoverYawAngleInDegreesEqualOrOver: 0.46F,
                    handoverYawAngleInDegreesEqualOrUnder: 0.47F,
                    handoverRollAngleInDegreesEqualOrOver: 0.48F,
                    handoverRollAngleInDegreesEqualOrUnder: 0.49F,
                    handoverPitchAngleInDegreesEqualOrOver: 0.50F,
                    handoverPitchAngleInDegreesEqualOrUnder: 0.51F,
                    handoverAltitudeAboveTerrainInMetersEqualOrOver: 0.52F,
                    handoverAltitudeAboveTerrainInMetersEqualOrUnder: 0.53F,
                    handoverLateralVelocityInMetrePerSecondEqualOrOver: 0.54F,
                    handoverLateralVelocityInMetrePerSecondEqualOrUnder: 0.55F,
                    handoverVerticalVelocityInMetrePerSecondEqualOrOver: 0.56F,
                    handoverVerticalVelocityInMetrePerSecondEqualOrUnder: 0.57F,
                    handoverHorizontalVelocityInMetrePerSecondEqualOrOver: 0.58F,
                    handoverHorizontalVelocityInMetrePerSecondEqualOrUnder: 0.59F,
                    desiredLegsExtendedState: true,
                    desiredYawAngleInDegrees: 0.60F,
                    desiredRollAngleInDegrees: 0.61F,
                    desiredPitchAngleInDegrees: 0.62F,
                    desiredLateralVelocityInMetrePerSecond: 0.63F,
                    desiredVerticalVelocityInMetrePerSecond: 0.64F,
                    desiredHorizontalVelocityInMetrePerSecond: 0.65F,
                    topLeftFlapDeployPercentOverwrite: 0.66F,
                    topRightFlapDeployPercentOverwrite: 0.67F,
                    bottomLeftFlapDeployPercentOverwrite: 0.68F,
                    bottomRightFlapDeployPercentOverwrite: 0.69F,
                    mainEnginesYawPercentOverwrite: 0.70F,
                    mainEnginesRollPercentOverwrite: 0.71F,
                    mainEnginesPitchPercentOverwrite: 0.72F,
                    topMainEngineThrottlePercentOverwrite: 0.73F,
                    bottomLeftMainEngineThrottlePercentOverwrite: 0.74F,
                    bottomRightMainEngineThrottlePercentOverwrite: 0.75F,
                    flapsActuationPidRegulatorProportionalGain: 0.76F,
                    flapsActuationPidRegulatorIntegralGain: 0.77F,
                    flapsActuationPidRegulatorDerivativeGain: 0.78F,
                    mainEnginesGimbalPidRegulatorProportionalGain: 0.79F,
                    mainEnginesGimbalPidRegulatorIntegralGain: 0.80F,
                    mainEnginesGimbalPidRegulatorDerivativeGain: 0.81F,
                    lateralVelocityOffsetPidRegulatorProportionalGain: 0.82F,
                    lateralVelocityOffsetPidRegulatorIntegralGain: 0.83F,
                    lateralVelocityOffsetPidRegulatorDerivativeGain: 0.84F,
                    mainEnginesThrottlePidRegulatorProportionalGain: 0.85F,
                    mainEnginesThrottlePidRegulatorIntegralGain: 0.86F,
                    mainEnginesThrottlePidRegulatorDerivativeGain: 0.87F,
                    horizontalVelocityOffsetPidRegulatorProportionalGain: 0.88F,
                    horizontalVelocityOffsetPidRegulatorIntegralGain: 0.89F,
                    horizontalVelocityOffsetPidRegulatorDerivativeGain: 0.90F)
            };

            Assert.That(flightSegmentConfigs, Is.EqualTo(expectedFlightSegmentConfigs));
        }

        [Test]
        public void Should_load_serialized_flight_segment_configs_without_all_nullables()
        {
            // GIVEN
            var flightSegmentConfigsLoader = CreateFlightSegmentConfigsLoader(
                "test_flight_segment_configs_without_nullables.xml");

            // WHEN
            var flightSegmentConfigs = flightSegmentConfigsLoader.LoadFlightSegmentConfigs();

            // THEN
            var expectedFlightSegmentConfigs = new List<FlightSegmentConfig>
            {
                new FlightSegmentConfig(
                    handoverYawAngleInDegreesEqualOrOver: null,
                    handoverYawAngleInDegreesEqualOrUnder: null,
                    handoverRollAngleInDegreesEqualOrOver: null,
                    handoverRollAngleInDegreesEqualOrUnder: null,
                    handoverPitchAngleInDegreesEqualOrOver: null,
                    handoverPitchAngleInDegreesEqualOrUnder: null,
                    handoverAltitudeAboveTerrainInMetersEqualOrOver: null,
                    handoverAltitudeAboveTerrainInMetersEqualOrUnder: null,
                    handoverLateralVelocityInMetrePerSecondEqualOrOver: null,
                    handoverLateralVelocityInMetrePerSecondEqualOrUnder: null,
                    handoverVerticalVelocityInMetrePerSecondEqualOrOver: null,
                    handoverVerticalVelocityInMetrePerSecondEqualOrUnder: null,
                    handoverHorizontalVelocityInMetrePerSecondEqualOrOver: null,
                    handoverHorizontalVelocityInMetrePerSecondEqualOrUnder: null,
                    desiredLegsExtendedState: false,
                    desiredYawAngleInDegrees: 0.1F,
                    desiredRollAngleInDegrees: 0.2F,
                    desiredPitchAngleInDegrees: 0.3F,
                    desiredLateralVelocityInMetrePerSecond: null,
                    desiredVerticalVelocityInMetrePerSecond: null,
                    desiredHorizontalVelocityInMetrePerSecond: null,
                    topLeftFlapDeployPercentOverwrite: null,
                    topRightFlapDeployPercentOverwrite: null,
                    bottomLeftFlapDeployPercentOverwrite: null,
                    bottomRightFlapDeployPercentOverwrite: null,
                    mainEnginesYawPercentOverwrite: null,
                    mainEnginesRollPercentOverwrite: null,
                    mainEnginesPitchPercentOverwrite: null,
                    topMainEngineThrottlePercentOverwrite: null,
                    bottomLeftMainEngineThrottlePercentOverwrite: null,
                    bottomRightMainEngineThrottlePercentOverwrite: null,
                    flapsActuationPidRegulatorProportionalGain: null,
                    flapsActuationPidRegulatorIntegralGain: null,
                    flapsActuationPidRegulatorDerivativeGain: null,
                    mainEnginesGimbalPidRegulatorProportionalGain: null,
                    mainEnginesGimbalPidRegulatorIntegralGain: null,
                    mainEnginesGimbalPidRegulatorDerivativeGain: null,
                    lateralVelocityOffsetPidRegulatorProportionalGain: null,
                    lateralVelocityOffsetPidRegulatorIntegralGain: null,
                    lateralVelocityOffsetPidRegulatorDerivativeGain: null,
                    mainEnginesThrottlePidRegulatorProportionalGain: null,
                    mainEnginesThrottlePidRegulatorIntegralGain: null,
                    mainEnginesThrottlePidRegulatorDerivativeGain: null,
                    horizontalVelocityOffsetPidRegulatorProportionalGain: null,
                    horizontalVelocityOffsetPidRegulatorIntegralGain: null,
                    horizontalVelocityOffsetPidRegulatorDerivativeGain: null),
                new FlightSegmentConfig(
                    handoverYawAngleInDegreesEqualOrOver: null,
                    handoverYawAngleInDegreesEqualOrUnder: null,
                    handoverRollAngleInDegreesEqualOrOver: null,
                    handoverRollAngleInDegreesEqualOrUnder: null,
                    handoverPitchAngleInDegreesEqualOrOver: null,
                    handoverPitchAngleInDegreesEqualOrUnder: null,
                    handoverAltitudeAboveTerrainInMetersEqualOrOver: null,
                    handoverAltitudeAboveTerrainInMetersEqualOrUnder: null,
                    handoverLateralVelocityInMetrePerSecondEqualOrOver: null,
                    handoverLateralVelocityInMetrePerSecondEqualOrUnder: null,
                    handoverVerticalVelocityInMetrePerSecondEqualOrOver: null,
                    handoverVerticalVelocityInMetrePerSecondEqualOrUnder: null,
                    handoverHorizontalVelocityInMetrePerSecondEqualOrOver: null,
                    handoverHorizontalVelocityInMetrePerSecondEqualOrUnder: null,
                    desiredLegsExtendedState: true,
                    desiredYawAngleInDegrees: 0.4F,
                    desiredRollAngleInDegrees: 0.5F,
                    desiredPitchAngleInDegrees: 0.6F,
                    desiredLateralVelocityInMetrePerSecond: null,
                    desiredVerticalVelocityInMetrePerSecond: null,
                    desiredHorizontalVelocityInMetrePerSecond: null,
                    topLeftFlapDeployPercentOverwrite: null,
                    topRightFlapDeployPercentOverwrite: null,
                    bottomLeftFlapDeployPercentOverwrite: null,
                    bottomRightFlapDeployPercentOverwrite: null,
                    mainEnginesYawPercentOverwrite: null,
                    mainEnginesRollPercentOverwrite: null,
                    mainEnginesPitchPercentOverwrite: null,
                    topMainEngineThrottlePercentOverwrite: null,
                    bottomLeftMainEngineThrottlePercentOverwrite: null,
                    bottomRightMainEngineThrottlePercentOverwrite: null,
                    flapsActuationPidRegulatorProportionalGain: null,
                    flapsActuationPidRegulatorIntegralGain: null,
                    flapsActuationPidRegulatorDerivativeGain: null,
                    mainEnginesGimbalPidRegulatorProportionalGain: null,
                    mainEnginesGimbalPidRegulatorIntegralGain: null,
                    mainEnginesGimbalPidRegulatorDerivativeGain: null,
                    lateralVelocityOffsetPidRegulatorProportionalGain: null,
                    lateralVelocityOffsetPidRegulatorIntegralGain: null,
                    lateralVelocityOffsetPidRegulatorDerivativeGain: null,
                    mainEnginesThrottlePidRegulatorProportionalGain: null,
                    mainEnginesThrottlePidRegulatorIntegralGain: null,
                    mainEnginesThrottlePidRegulatorDerivativeGain: null,
                    horizontalVelocityOffsetPidRegulatorProportionalGain: null,
                    horizontalVelocityOffsetPidRegulatorIntegralGain: null,
                    horizontalVelocityOffsetPidRegulatorDerivativeGain: null)
            };

            Assert.That(flightSegmentConfigs, Is.EqualTo(expectedFlightSegmentConfigs));
        }

        private static FlightSegmentConfigsLoader CreateFlightSegmentConfigsLoader(
            string flightSegmentConfigsFileName
        ) => new FlightSegmentConfigsLoader(
            new TestFlightSegmentConfigsPath(flightSegmentConfigsFileName));

        private sealed class TestFlightSegmentConfigsPath : IFlightSegmentConfigsPath
        {
            private readonly string _flightSegmentConfigsFileName;


            public TestFlightSegmentConfigsPath(string flightSegmentConfigsFileName)
            {
                _flightSegmentConfigsFileName = flightSegmentConfigsFileName;
            }

            public string RawPath =>
                GetParent(path: GetCurrentDirectory()).Parent.Parent.FullName +
                $@"\Flight\Segment\Config\{_flightSegmentConfigsFileName}";
        }
    }
}