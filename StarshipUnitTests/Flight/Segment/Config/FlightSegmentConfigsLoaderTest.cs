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
                    handoverYawAngleInDegreesEqualOrOver: 0.001F,
                    handoverYawAngleInDegreesEqualOrUnder: 0.002F,
                    handoverRollAngleInDegreesEqualOrOver: 0.003F,
                    handoverRollAngleInDegreesEqualOrUnder: 0.004F,
                    handoverPitchAngleInDegreesEqualOrOver: 0.005F,
                    handoverPitchAngleInDegreesEqualOrUnder: 0.006F,
                    handoverAltitudeAboveTerrainInMetersEqualOrOver: 0.007F,
                    handoverAltitudeAboveTerrainInMetersEqualOrUnder: 0.008F,
                    handoverLateralVelocityInMetrePerSecondEqualOrOver: 0.009F,
                    handoverLateralVelocityInMetrePerSecondEqualOrUnder: 0.010F,
                    handoverVerticalVelocityInMetrePerSecondEqualOrOver: 0.011F,
                    handoverVerticalVelocityInMetrePerSecondEqualOrUnder: 0.012F,
                    handoverHorizontalVelocityInMetrePerSecondEqualOrOver: 0.013F,
                    handoverHorizontalVelocityInMetrePerSecondEqualOrUnder: 0.014F,
                    desiredLegsExtendedState: false,
                    desiredYawAngleInDegrees: 0.015F,
                    desiredRollAngleInDegrees: 0.016F,
                    desiredPitchAngleInDegrees: 0.017F,
                    desiredLateralVelocityInMetrePerSecond: 0.018F,
                    desiredVerticalVelocityInMetrePerSecond: 0.019F,
                    desiredHorizontalVelocityInMetrePerSecond: 0.020F,
                    topLeftRcsActivatedStateOverwrite: false,
                    topRightRcsActivatedStateOverwrite: false,
                    bottomLeftRcsActivatedStateOverwrite: false,
                    bottomRightRcsActivatedStateOverwrite: false,
                    topLeftFlapDeployPercentOverwrite: 0.021F,
                    topRightFlapDeployPercentOverwrite: 0.022F,
                    bottomLeftFlapDeployPercentOverwrite: 0.023F,
                    bottomRightFlapDeployPercentOverwrite: 0.024F,
                    mainEnginesYawPercentOverwrite: 0.025F,
                    mainEnginesRollPercentOverwrite: 0.026F,
                    mainEnginesPitchPercentOverwrite: 0.027F,
                    topMainEngineThrottlePercentOverwrite: 0.028F,
                    bottomLeftMainEngineThrottlePercentOverwrite: 0.029F,
                    bottomRightMainEngineThrottlePercentOverwrite: 0.030F,
                    rcsActivationPidRegulatorProportionalGain: 0.031F,
                    rcsActivationPidRegulatorIntegralGain: 0.032F,
                    rcsActivationPidRegulatorDerivativeGain: 0.033F,
                    flapsYawPidRegulatorProportionalGain: 0.034F,
                    flapsYawPidRegulatorIntegralGain: 0.035F,
                    flapsYawPidRegulatorDerivativeGain: 0.036F,
                    flapsRollPidRegulatorProportionalGain: 0.037F,
                    flapsRollPidRegulatorIntegralGain: 0.038F,
                    flapsRollPidRegulatorDerivativeGain: 0.039F,
                    flapsPitchPidRegulatorProportionalGain: 0.040F,
                    flapsPitchPidRegulatorIntegralGain: 0.041F,
                    flapsPitchPidRegulatorDerivativeGain: 0.042F,
                    mainEnginesGimbalPidRegulatorProportionalGain: 0.043F,
                    mainEnginesGimbalPidRegulatorIntegralGain: 0.044F,
                    mainEnginesGimbalPidRegulatorDerivativeGain: 0.045F,
                    lateralVelocityOffsetPidRegulatorProportionalGain: 0.046F,
                    lateralVelocityOffsetPidRegulatorIntegralGain: 0.047F,
                    lateralVelocityOffsetPidRegulatorDerivativeGain: 0.048F,
                    mainEnginesThrottlePidRegulatorProportionalGain: 0.049F,
                    mainEnginesThrottlePidRegulatorIntegralGain: 0.050F,
                    mainEnginesThrottlePidRegulatorDerivativeGain: 0.051F,
                    horizontalVelocityOffsetPidRegulatorProportionalGain: 0.052F,
                    horizontalVelocityOffsetPidRegulatorIntegralGain: 0.053F,
                    horizontalVelocityOffsetPidRegulatorDerivativeGain: 0.054F),
                new FlightSegmentConfig(
                    handoverYawAngleInDegreesEqualOrOver: 0.055F,
                    handoverYawAngleInDegreesEqualOrUnder: 0.056F,
                    handoverRollAngleInDegreesEqualOrOver: 0.057F,
                    handoverRollAngleInDegreesEqualOrUnder: 0.058F,
                    handoverPitchAngleInDegreesEqualOrOver: 0.059F,
                    handoverPitchAngleInDegreesEqualOrUnder: 0.060F,
                    handoverAltitudeAboveTerrainInMetersEqualOrOver: 0.061F,
                    handoverAltitudeAboveTerrainInMetersEqualOrUnder: 0.062F,
                    handoverLateralVelocityInMetrePerSecondEqualOrOver: 0.063F,
                    handoverLateralVelocityInMetrePerSecondEqualOrUnder: 0.064F,
                    handoverVerticalVelocityInMetrePerSecondEqualOrOver: 0.065F,
                    handoverVerticalVelocityInMetrePerSecondEqualOrUnder: 0.066F,
                    handoverHorizontalVelocityInMetrePerSecondEqualOrOver: 0.067F,
                    handoverHorizontalVelocityInMetrePerSecondEqualOrUnder: 0.068F,
                    desiredLegsExtendedState: true,
                    desiredYawAngleInDegrees: 0.069F,
                    desiredRollAngleInDegrees: 0.070F,
                    desiredPitchAngleInDegrees: 0.071F,
                    desiredLateralVelocityInMetrePerSecond: 0.072F,
                    desiredVerticalVelocityInMetrePerSecond: 0.073F,
                    desiredHorizontalVelocityInMetrePerSecond: 0.074F,
                    topLeftRcsActivatedStateOverwrite: true,
                    topRightRcsActivatedStateOverwrite: true,
                    bottomLeftRcsActivatedStateOverwrite: true,
                    bottomRightRcsActivatedStateOverwrite: true,
                    topLeftFlapDeployPercentOverwrite: 0.075F,
                    topRightFlapDeployPercentOverwrite: 0.076F,
                    bottomLeftFlapDeployPercentOverwrite: 0.077F,
                    bottomRightFlapDeployPercentOverwrite: 0.078F,
                    mainEnginesYawPercentOverwrite: 0.079F,
                    mainEnginesRollPercentOverwrite: 0.080F,
                    mainEnginesPitchPercentOverwrite: 0.081F,
                    topMainEngineThrottlePercentOverwrite: 0.082F,
                    bottomLeftMainEngineThrottlePercentOverwrite: 0.083F,
                    bottomRightMainEngineThrottlePercentOverwrite: 0.084F,
                    rcsActivationPidRegulatorProportionalGain: 0.085F,
                    rcsActivationPidRegulatorIntegralGain: 0.086F,
                    rcsActivationPidRegulatorDerivativeGain: 0.087F,
                    flapsYawPidRegulatorProportionalGain: 0.088F,
                    flapsYawPidRegulatorIntegralGain: 0.089F,
                    flapsYawPidRegulatorDerivativeGain: 0.090F,
                    flapsRollPidRegulatorProportionalGain: 0.091F,
                    flapsRollPidRegulatorIntegralGain: 0.092F,
                    flapsRollPidRegulatorDerivativeGain: 0.093F,
                    flapsPitchPidRegulatorProportionalGain: 0.094F,
                    flapsPitchPidRegulatorIntegralGain: 0.095F,
                    flapsPitchPidRegulatorDerivativeGain: 0.096F,
                    mainEnginesGimbalPidRegulatorProportionalGain: 0.097F,
                    mainEnginesGimbalPidRegulatorIntegralGain: 0.098F,
                    mainEnginesGimbalPidRegulatorDerivativeGain: 0.099F,
                    lateralVelocityOffsetPidRegulatorProportionalGain: 0.100F,
                    lateralVelocityOffsetPidRegulatorIntegralGain: 0.101F,
                    lateralVelocityOffsetPidRegulatorDerivativeGain: 0.102F,
                    mainEnginesThrottlePidRegulatorProportionalGain: 0.103F,
                    mainEnginesThrottlePidRegulatorIntegralGain: 0.104F,
                    mainEnginesThrottlePidRegulatorDerivativeGain: 0.105F,
                    horizontalVelocityOffsetPidRegulatorProportionalGain: 0.106F,
                    horizontalVelocityOffsetPidRegulatorIntegralGain: 0.107F,
                    horizontalVelocityOffsetPidRegulatorDerivativeGain: 0.108F)
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
                    topLeftRcsActivatedStateOverwrite: null,
                    topRightRcsActivatedStateOverwrite: null,
                    bottomLeftRcsActivatedStateOverwrite: null,
                    bottomRightRcsActivatedStateOverwrite: null,
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
                    rcsActivationPidRegulatorProportionalGain: null,
                    rcsActivationPidRegulatorIntegralGain: null,
                    rcsActivationPidRegulatorDerivativeGain: null,
                    flapsYawPidRegulatorProportionalGain: null,
                    flapsYawPidRegulatorIntegralGain: null,
                    flapsYawPidRegulatorDerivativeGain: null,
                    flapsRollPidRegulatorProportionalGain: null,
                    flapsRollPidRegulatorIntegralGain: null,
                    flapsRollPidRegulatorDerivativeGain: null,
                    flapsPitchPidRegulatorProportionalGain: null,
                    flapsPitchPidRegulatorIntegralGain: null,
                    flapsPitchPidRegulatorDerivativeGain: null,
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
                    topLeftRcsActivatedStateOverwrite: null,
                    topRightRcsActivatedStateOverwrite: null,
                    bottomLeftRcsActivatedStateOverwrite: null,
                    bottomRightRcsActivatedStateOverwrite: null,
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
                    rcsActivationPidRegulatorProportionalGain: null,
                    rcsActivationPidRegulatorIntegralGain: null,
                    rcsActivationPidRegulatorDerivativeGain: null,
                    flapsYawPidRegulatorProportionalGain: null,
                    flapsYawPidRegulatorIntegralGain: null,
                    flapsYawPidRegulatorDerivativeGain: null,
                    flapsRollPidRegulatorProportionalGain: null,
                    flapsRollPidRegulatorIntegralGain: null,
                    flapsRollPidRegulatorDerivativeGain: null,
                    flapsPitchPidRegulatorProportionalGain: null,
                    flapsPitchPidRegulatorIntegralGain: null,
                    flapsPitchPidRegulatorDerivativeGain: null,
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