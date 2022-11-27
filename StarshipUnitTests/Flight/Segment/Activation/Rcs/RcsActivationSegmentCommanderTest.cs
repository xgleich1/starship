using System.Collections.Generic;
using NUnit.Framework;
using Starship.Flight.Segment.Activation.Rcs;
using Starship.Flight.Segment.Config;
using Starship.Telemetry;

namespace StarshipUnitTests.Flight.Segment.Activation.Rcs
{
    public sealed class RcsActivationSegmentCommanderTest
    {
        [Test]
        public void Should_provide_telemetry_consisting_of_the_processed_config_values()
        {
            // GIVEN
            var commander = new RcsActivationSegmentCommander(CreateFlightSegmentConfig(
                desiredRollAngleInDegrees: 0.1F,
                topLeftRcsActivatedStateOverwrite: false,
                topRightRcsActivatedStateOverwrite: false,
                bottomLeftRcsActivatedStateOverwrite: false,
                bottomRightRcsActivatedStateOverwrite: false,
                rcsActivationPidRegulatorProportionalGain: 0.2F,
                rcsActivationPidRegulatorIntegralGain: 0.3F,
                rcsActivationPidRegulatorDerivativeGain: 0.4F));

            // THEN
            var expectedTelemetry = new List<TelemetryMessage>
            {
                new TelemetryMessage("--- Rcs Activation Segment Commander Config ---"),
                new TelemetryMessage("DesiredRollAngleInDegrees:0,1"),
                new TelemetryMessage("TopLeftRcsActivatedStateOverwrite:False"),
                new TelemetryMessage("TopRightRcsActivatedStateOverwrite:False"),
                new TelemetryMessage("BottomLeftRcsActivatedStateOverwrite:False"),
                new TelemetryMessage("BottomRightRcsActivatedStateOverwrite:False"),
                new TelemetryMessage("RcsActivationPidRegulatorProportionalGain:0,2"),
                new TelemetryMessage("RcsActivationPidRegulatorIntegralGain:0,3"),
                new TelemetryMessage("RcsActivationPidRegulatorDerivativeGain:0,4"),
                new TelemetryMessage("-----------------------------------------------")
            };

            Assert.That(commander.ProvideTelemetry(), Is.EqualTo(expectedTelemetry));
        }

        [Test]
        public void Should_provide_a_equality_by_value_method()
        {
            // GIVEN
            var commanderA = new RcsActivationSegmentCommander(CreateFlightSegmentConfig(
                desiredRollAngleInDegrees: 0.0F,
                topLeftRcsActivatedStateOverwrite: false,
                topRightRcsActivatedStateOverwrite: false,
                bottomLeftRcsActivatedStateOverwrite: false,
                bottomRightRcsActivatedStateOverwrite: false,
                rcsActivationPidRegulatorProportionalGain: null,
                rcsActivationPidRegulatorIntegralGain: null,
                rcsActivationPidRegulatorDerivativeGain: null));

            var commanderB = new RcsActivationSegmentCommander(CreateFlightSegmentConfig(
                desiredRollAngleInDegrees: 0.0F,
                topLeftRcsActivatedStateOverwrite: false,
                topRightRcsActivatedStateOverwrite: false,
                bottomLeftRcsActivatedStateOverwrite: false,
                bottomRightRcsActivatedStateOverwrite: false,
                rcsActivationPidRegulatorProportionalGain: null,
                rcsActivationPidRegulatorIntegralGain: null,
                rcsActivationPidRegulatorDerivativeGain: null));

            var commanderC = new RcsActivationSegmentCommander(CreateFlightSegmentConfig(
                desiredRollAngleInDegrees: 0.0F,
                topLeftRcsActivatedStateOverwrite: null,
                topRightRcsActivatedStateOverwrite: null,
                bottomLeftRcsActivatedStateOverwrite: null,
                bottomRightRcsActivatedStateOverwrite: null,
                rcsActivationPidRegulatorProportionalGain: 1.0F,
                rcsActivationPidRegulatorIntegralGain: 0.25F,
                rcsActivationPidRegulatorDerivativeGain: 0.05F));

            // THEN
            Assert.That(commanderA.Equals(commanderB), Is.True);
            Assert.That(commanderA.Equals(commanderC), Is.False);
        }

        private static FlightSegmentConfig CreateFlightSegmentConfig(
            float desiredRollAngleInDegrees,
            bool? topLeftRcsActivatedStateOverwrite,
            bool? topRightRcsActivatedStateOverwrite,
            bool? bottomLeftRcsActivatedStateOverwrite,
            bool? bottomRightRcsActivatedStateOverwrite,
            float? rcsActivationPidRegulatorProportionalGain,
            float? rcsActivationPidRegulatorIntegralGain,
            float? rcsActivationPidRegulatorDerivativeGain
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
            0.0F,
            desiredRollAngleInDegrees,
            0.0F,
            null,
            null,
            null,
            topLeftRcsActivatedStateOverwrite,
            topRightRcsActivatedStateOverwrite,
            bottomLeftRcsActivatedStateOverwrite,
            bottomRightRcsActivatedStateOverwrite,
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
            rcsActivationPidRegulatorProportionalGain,
            rcsActivationPidRegulatorIntegralGain,
            rcsActivationPidRegulatorDerivativeGain,
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
            null,
            null,
            null,
            null,
            null,
            null,
            null);
    }
}