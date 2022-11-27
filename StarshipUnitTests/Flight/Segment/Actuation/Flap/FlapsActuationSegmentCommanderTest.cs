using System.Collections.Generic;
using NUnit.Framework;
using Starship.Flight.Segment.Actuation.Flap;
using Starship.Flight.Segment.Config;
using Starship.Telemetry;

namespace StarshipUnitTests.Flight.Segment.Actuation.Flap
{
    public sealed class FlapsActuationSegmentCommanderTest
    {
        [Test]
        public void Should_provide_telemetry_consisting_of_the_processed_config_values()
        {
            // GIVEN
            var commander = new FlapsActuationSegmentCommander(CreateFlightSegmentConfig(
                desiredYawAngleInDegrees: 0.01F,
                desiredRollAngleInDegrees: 0.02F,
                desiredPitchAngleInDegrees: 0.03F,
                topLeftFlapDeployPercentOverwrite: 0.04F,
                topRightFlapDeployPercentOverwrite: 0.05F,
                bottomLeftFlapDeployPercentOverwrite: 0.06F,
                bottomRightFlapDeployPercentOverwrite: 0.07F,
                flapsYawPidRegulatorProportionalGain: 0.08F,
                flapsYawPidRegulatorIntegralGain: 0.09F,
                flapsYawPidRegulatorDerivativeGain: 0.10F,
                flapsRollPidRegulatorProportionalGain: 0.11F,
                flapsRollPidRegulatorIntegralGain: 0.12F,
                flapsRollPidRegulatorDerivativeGain: 0.13F,
                flapsPitchPidRegulatorProportionalGain: 0.14F,
                flapsPitchPidRegulatorIntegralGain: 0.15F,
                flapsPitchPidRegulatorDerivativeGain: 0.16F));

            // THEN
            var expectedTelemetry = new List<TelemetryMessage>
            {
                new TelemetryMessage("--- Flaps Actuation Segment Commander Config ---"),
                new TelemetryMessage("DesiredYawAngleInDegrees:0,01"),
                new TelemetryMessage("DesiredRollAngleInDegrees:0,02"),
                new TelemetryMessage("DesiredPitchAngleInDegrees:0,03"),
                new TelemetryMessage("TopLeftFlapDeployPercentOverwrite:0,04"),
                new TelemetryMessage("TopRightFlapDeployPercentOverwrite:0,05"),
                new TelemetryMessage("BottomLeftFlapDeployPercentOverwrite:0,06"),
                new TelemetryMessage("BottomRightFlapDeployPercentOverwrite:0,07"),
                new TelemetryMessage("FlapsYawPidRegulatorProportionalGain:0,08"),
                new TelemetryMessage("FlapsYawPidRegulatorIntegralGain:0,09"),
                new TelemetryMessage("FlapsYawPidRegulatorDerivativeGain:0,1"),
                new TelemetryMessage("FlapsRollPidRegulatorProportionalGain:0,11"),
                new TelemetryMessage("FlapsRollPidRegulatorIntegralGain:0,12"),
                new TelemetryMessage("FlapsRollPidRegulatorDerivativeGain:0,13"),
                new TelemetryMessage("FlapsPitchPidRegulatorProportionalGain:0,14"),
                new TelemetryMessage("FlapsPitchPidRegulatorIntegralGain:0,15"),
                new TelemetryMessage("FlapsPitchPidRegulatorDerivativeGain:0,16"),
                new TelemetryMessage("------------------------------------------------")
            };

            Assert.That(commander.ProvideTelemetry(), Is.EqualTo(expectedTelemetry));
        }

        [Test]
        public void Should_provide_a_equality_by_value_method()
        {
            // GIVEN
            var commanderA = new FlapsActuationSegmentCommander(CreateFlightSegmentConfig(
                desiredYawAngleInDegrees: 0.0F,
                desiredRollAngleInDegrees: 0.0F,
                desiredPitchAngleInDegrees: 0.0F,
                topLeftFlapDeployPercentOverwrite: 1.0F,
                topRightFlapDeployPercentOverwrite: 1.0F,
                bottomLeftFlapDeployPercentOverwrite: 1.0F,
                bottomRightFlapDeployPercentOverwrite: 1.0F,
                flapsYawPidRegulatorProportionalGain: null,
                flapsYawPidRegulatorIntegralGain: null,
                flapsYawPidRegulatorDerivativeGain: null,
                flapsRollPidRegulatorProportionalGain: null,
                flapsRollPidRegulatorIntegralGain: null,
                flapsRollPidRegulatorDerivativeGain: null,
                flapsPitchPidRegulatorProportionalGain: null,
                flapsPitchPidRegulatorIntegralGain: null,
                flapsPitchPidRegulatorDerivativeGain: null));

            var commanderB = new FlapsActuationSegmentCommander(CreateFlightSegmentConfig(
                desiredYawAngleInDegrees: 0.0F,
                desiredRollAngleInDegrees: 0.0F,
                desiredPitchAngleInDegrees: 0.0F,
                topLeftFlapDeployPercentOverwrite: 1.0F,
                topRightFlapDeployPercentOverwrite: 1.0F,
                bottomLeftFlapDeployPercentOverwrite: 1.0F,
                bottomRightFlapDeployPercentOverwrite: 1.0F,
                flapsYawPidRegulatorProportionalGain: null,
                flapsYawPidRegulatorIntegralGain: null,
                flapsYawPidRegulatorDerivativeGain: null,
                flapsRollPidRegulatorProportionalGain: null,
                flapsRollPidRegulatorIntegralGain: null,
                flapsRollPidRegulatorDerivativeGain: null,
                flapsPitchPidRegulatorProportionalGain: null,
                flapsPitchPidRegulatorIntegralGain: null,
                flapsPitchPidRegulatorDerivativeGain: null));

            var commanderC = new FlapsActuationSegmentCommander(CreateFlightSegmentConfig(
                desiredYawAngleInDegrees: 0.0F,
                desiredRollAngleInDegrees: 0.0F,
                desiredPitchAngleInDegrees: 0.0F,
                topLeftFlapDeployPercentOverwrite: null,
                topRightFlapDeployPercentOverwrite: null,
                bottomLeftFlapDeployPercentOverwrite: null,
                bottomRightFlapDeployPercentOverwrite: null,
                flapsYawPidRegulatorProportionalGain: 0.035F,
                flapsYawPidRegulatorIntegralGain: 0.01F,
                flapsYawPidRegulatorDerivativeGain: 0.005F,
                flapsRollPidRegulatorProportionalGain: 0.035F,
                flapsRollPidRegulatorIntegralGain: 0.01F,
                flapsRollPidRegulatorDerivativeGain: 0.0035F,
                flapsPitchPidRegulatorProportionalGain: 0.25F,
                flapsPitchPidRegulatorIntegralGain: 0F,
                flapsPitchPidRegulatorDerivativeGain: 0.025F));

            // THEN
            Assert.That(commanderA.Equals(commanderB), Is.True);
            Assert.That(commanderA.Equals(commanderC), Is.False);
        }

        private static FlightSegmentConfig CreateFlightSegmentConfig(
            float desiredYawAngleInDegrees,
            float desiredRollAngleInDegrees,
            float desiredPitchAngleInDegrees,
            float? topLeftFlapDeployPercentOverwrite,
            float? topRightFlapDeployPercentOverwrite,
            float? bottomLeftFlapDeployPercentOverwrite,
            float? bottomRightFlapDeployPercentOverwrite,
            float? flapsYawPidRegulatorProportionalGain,
            float? flapsYawPidRegulatorIntegralGain,
            float? flapsYawPidRegulatorDerivativeGain,
            float? flapsRollPidRegulatorProportionalGain,
            float? flapsRollPidRegulatorIntegralGain,
            float? flapsRollPidRegulatorDerivativeGain,
            float? flapsPitchPidRegulatorProportionalGain,
            float? flapsPitchPidRegulatorIntegralGain,
            float? flapsPitchPidRegulatorDerivativeGain
        ) => new FlightSegmentConfig(
            null,
            null,
            null,
            null,
            null,
            null,
            null,
            null,
            null,
            null,
            null,
            null,
            null,
            null,
            false,
            desiredYawAngleInDegrees,
            desiredRollAngleInDegrees,
            desiredPitchAngleInDegrees,
            null,
            null,
            null,
            null,
            null,
            null,
            null,
            topLeftFlapDeployPercentOverwrite,
            topRightFlapDeployPercentOverwrite,
            bottomLeftFlapDeployPercentOverwrite,
            bottomRightFlapDeployPercentOverwrite,
            null,
            null,
            null,
            null,
            null,
            null,
            null,
            null,
            null,
            flapsYawPidRegulatorProportionalGain,
            flapsYawPidRegulatorIntegralGain,
            flapsYawPidRegulatorDerivativeGain,
            flapsRollPidRegulatorProportionalGain,
            flapsRollPidRegulatorIntegralGain,
            flapsRollPidRegulatorDerivativeGain,
            flapsPitchPidRegulatorProportionalGain,
            flapsPitchPidRegulatorIntegralGain,
            flapsPitchPidRegulatorDerivativeGain,
            null,
            null,
            null,
            null,
            null,
            null,
            null,
            null,
            null,
            null,
            null,
            null);
    }
}