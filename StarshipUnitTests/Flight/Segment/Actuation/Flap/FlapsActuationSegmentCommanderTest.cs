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
                desiredYawAngleInDegrees: 0.0F,
                desiredRollAngleInDegrees: 0.1F,
                desiredPitchAngleInDegrees: 0.2F,
                topLeftFlapDeployPercentOverwrite: 0.3F,
                topRightFlapDeployPercentOverwrite: 0.4F,
                bottomLeftFlapDeployPercentOverwrite: 0.5F,
                bottomRightFlapDeployPercentOverwrite: 0.6F,
                flapsActuationPidRegulatorProportionalGain: 0.7F,
                flapsActuationPidRegulatorIntegralGain: 0.8F,
                flapsActuationPidRegulatorDerivativeGain: 0.9F));

            // THEN
            var expectedTelemetry = new List<TelemetryMessage>
            {
                new TelemetryMessage("--- Flaps Actuation Segment Commander Config ---"),
                new TelemetryMessage("DesiredYawAngleInDegrees:0"),
                new TelemetryMessage("DesiredRollAngleInDegrees:0,1"),
                new TelemetryMessage("DesiredPitchAngleInDegrees:0,2"),
                new TelemetryMessage("TopLeftFlapDeployPercentOverwrite:0,3"),
                new TelemetryMessage("TopRightFlapDeployPercentOverwrite:0,4"),
                new TelemetryMessage("BottomLeftFlapDeployPercentOverwrite:0,5"),
                new TelemetryMessage("BottomRightFlapDeployPercentOverwrite:0,6"),
                new TelemetryMessage("FlapsActuationPidRegulatorProportionalGain:0,7"),
                new TelemetryMessage("FlapsActuationPidRegulatorIntegralGain:0,8"),
                new TelemetryMessage("FlapsActuationPidRegulatorDerivativeGain:0,9"),
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
                flapsActuationPidRegulatorProportionalGain: null,
                flapsActuationPidRegulatorIntegralGain: null,
                flapsActuationPidRegulatorDerivativeGain: null));

            var commanderB = new FlapsActuationSegmentCommander(CreateFlightSegmentConfig(
                desiredYawAngleInDegrees: 0.0F,
                desiredRollAngleInDegrees: 0.0F,
                desiredPitchAngleInDegrees: 0.0F,
                topLeftFlapDeployPercentOverwrite: 1.0F,
                topRightFlapDeployPercentOverwrite: 1.0F,
                bottomLeftFlapDeployPercentOverwrite: 1.0F,
                bottomRightFlapDeployPercentOverwrite: 1.0F,
                flapsActuationPidRegulatorProportionalGain: null,
                flapsActuationPidRegulatorIntegralGain: null,
                flapsActuationPidRegulatorDerivativeGain: null));

            var commanderC = new FlapsActuationSegmentCommander(CreateFlightSegmentConfig(
                desiredYawAngleInDegrees: 0.0F,
                desiredRollAngleInDegrees: 0.0F,
                desiredPitchAngleInDegrees: 0.0F,
                topLeftFlapDeployPercentOverwrite: null,
                topRightFlapDeployPercentOverwrite: null,
                bottomLeftFlapDeployPercentOverwrite: null,
                bottomRightFlapDeployPercentOverwrite: null,
                flapsActuationPidRegulatorProportionalGain: 0.035F,
                flapsActuationPidRegulatorIntegralGain: 0.00001F,
                flapsActuationPidRegulatorDerivativeGain: 0.0035F));

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
            float? flapsActuationPidRegulatorProportionalGain,
            float? flapsActuationPidRegulatorIntegralGain,
            float? flapsActuationPidRegulatorDerivativeGain
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
            flapsActuationPidRegulatorProportionalGain,
            flapsActuationPidRegulatorIntegralGain,
            flapsActuationPidRegulatorDerivativeGain,
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