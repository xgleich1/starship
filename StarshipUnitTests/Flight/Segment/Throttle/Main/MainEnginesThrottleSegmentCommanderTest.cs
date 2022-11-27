using System.Collections.Generic;
using NUnit.Framework;
using Starship.Flight.Segment.Config;
using Starship.Flight.Segment.Throttle.Main;
using Starship.Telemetry;

namespace StarshipUnitTests.Flight.Segment.Throttle.Main
{
    public sealed class MainEnginesThrottleSegmentCommanderTest
    {
        [Test]
        public void Should_provide_telemetry_consisting_of_the_processed_config_values()
        {
            // GIVEN
            var commander = new MainEnginesThrottleSegmentCommander(CreateFlightSegmentConfig(
                desiredVerticalVelocityInMetrePerSecond: 0.0F,
                topMainEngineThrottlePercentOverwrite: 0.1F,
                bottomLeftMainEngineThrottlePercentOverwrite: 0.2F,
                bottomRightMainEngineThrottlePercentOverwrite: 0.3F,
                mainEnginesThrottlePidRegulatorProportionalGain: 0.4F,
                mainEnginesThrottlePidRegulatorIntegralGain: 0.5F,
                mainEnginesThrottlePidRegulatorDerivativeGain: 0.6F));

            // THEN
            var expectedTelemetry = new List<TelemetryMessage>
            {
                new TelemetryMessage("--- Main Engines Throttle Segment Commander Config ---"),
                new TelemetryMessage("DesiredVerticalVelocityInMetrePerSecond:0"),
                new TelemetryMessage("TopMainEngineThrottlePercentOverwrite:0,1"),
                new TelemetryMessage("BottomLeftMainEngineThrottlePercentOverwrite:0,2"),
                new TelemetryMessage("BottomRightMainEngineThrottlePercentOverwrite:0,3"),
                new TelemetryMessage("MainEnginesThrottlePidRegulatorProportionalGain:0,4"),
                new TelemetryMessage("MainEnginesThrottlePidRegulatorIntegralGain:0,5"),
                new TelemetryMessage("MainEnginesThrottlePidRegulatorDerivativeGain:0,6"),
                new TelemetryMessage("------------------------------------------------------")
            };

            Assert.That(commander.ProvideTelemetry(), Is.EqualTo(expectedTelemetry));
        }

        [Test]
        public void Should_provide_a_equality_by_value_method()
        {
            // GIVEN
            var commanderA = new MainEnginesThrottleSegmentCommander(CreateFlightSegmentConfig(
                desiredVerticalVelocityInMetrePerSecond: 100.0F,
                topMainEngineThrottlePercentOverwrite: null,
                bottomLeftMainEngineThrottlePercentOverwrite: null,
                bottomRightMainEngineThrottlePercentOverwrite: null,
                mainEnginesThrottlePidRegulatorProportionalGain: 0.15F,
                mainEnginesThrottlePidRegulatorIntegralGain: 0.0005F,
                mainEnginesThrottlePidRegulatorDerivativeGain: 0.075F));

            var commanderB = new MainEnginesThrottleSegmentCommander(CreateFlightSegmentConfig(
                desiredVerticalVelocityInMetrePerSecond: 100.0F,
                topMainEngineThrottlePercentOverwrite: null,
                bottomLeftMainEngineThrottlePercentOverwrite: null,
                bottomRightMainEngineThrottlePercentOverwrite: null,
                mainEnginesThrottlePidRegulatorProportionalGain: 0.15F,
                mainEnginesThrottlePidRegulatorIntegralGain: 0.0005F,
                mainEnginesThrottlePidRegulatorDerivativeGain: 0.075F));

            var commanderC = new MainEnginesThrottleSegmentCommander(CreateFlightSegmentConfig(
                desiredVerticalVelocityInMetrePerSecond: null,
                topMainEngineThrottlePercentOverwrite: 0.0F,
                bottomLeftMainEngineThrottlePercentOverwrite: 0.0F,
                bottomRightMainEngineThrottlePercentOverwrite: 0.0F,
                mainEnginesThrottlePidRegulatorProportionalGain: null,
                mainEnginesThrottlePidRegulatorIntegralGain: null,
                mainEnginesThrottlePidRegulatorDerivativeGain: null));

            // THEN
            Assert.That(commanderA.Equals(commanderB), Is.True);
            Assert.That(commanderA.Equals(commanderC), Is.False);
        }

        private static FlightSegmentConfig CreateFlightSegmentConfig(
            float? desiredVerticalVelocityInMetrePerSecond,
            float? topMainEngineThrottlePercentOverwrite,
            float? bottomLeftMainEngineThrottlePercentOverwrite,
            float? bottomRightMainEngineThrottlePercentOverwrite,
            float? mainEnginesThrottlePidRegulatorProportionalGain,
            float? mainEnginesThrottlePidRegulatorIntegralGain,
            float? mainEnginesThrottlePidRegulatorDerivativeGain
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
            0.0F,
            0.0F,
            null,
            desiredVerticalVelocityInMetrePerSecond,
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
            topMainEngineThrottlePercentOverwrite,
            bottomLeftMainEngineThrottlePercentOverwrite,
            bottomRightMainEngineThrottlePercentOverwrite,
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
            mainEnginesThrottlePidRegulatorProportionalGain,
            mainEnginesThrottlePidRegulatorIntegralGain,
            mainEnginesThrottlePidRegulatorDerivativeGain,
            null,
            null,
            null);
    }
}