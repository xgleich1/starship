using System.Collections.Generic;
using NUnit.Framework;
using Starship.Flight.Segment.Actuation.Engine;
using Starship.Flight.Segment.Config;
using Starship.Telemetry;

namespace StarshipUnitTests.Flight.Segment.Actuation.Engine
{
    public sealed class MainEnginesGimbalSegmentCommanderTest
    {
        [Test]
        public void Should_provide_telemetry_consisting_of_the_processed_config_values()
        {
            // GIVEN
            var commander = new MainEnginesGimbalSegmentCommander(CreateFlightSegmentConfig(
                desiredYawAngleInDegrees: 0.0F,
                desiredRollAngleInDegrees: 0.1F,
                desiredPitchAngleInDegrees: 0.2F,
                desiredLateralVelocityInMetrePerSecond: 0.3F,
                desiredHorizontalVelocityInMetrePerSecond: 0.4F,
                mainEnginesYawPercentOverwrite: 0.5F,
                mainEnginesRollPercentOverwrite: 0.6F,
                mainEnginesPitchPercentOverwrite: 0.7F,
                mainEnginesGimbalPidRegulatorProportionalGain: 0.8F,
                mainEnginesGimbalPidRegulatorIntegralGain: 0.9F,
                mainEnginesGimbalPidRegulatorDerivativeGain: 1.0F,
                lateralVelocityOffsetPidRegulatorProportionalGain: 1.1F,
                lateralVelocityOffsetPidRegulatorIntegralGain: 1.2F,
                lateralVelocityOffsetPidRegulatorDerivativeGain: 1.3F,
                horizontalVelocityOffsetPidRegulatorProportionalGain: 1.4F,
                horizontalVelocityOffsetPidRegulatorIntegralGain: 1.5F,
                horizontalVelocityOffsetPidRegulatorDerivativeGain: 1.6F));

            // THEN
            var expectedTelemetry = new List<TelemetryMessage>
            {
                new TelemetryMessage("--- Main Engines Gimbal Segment Commander Config ---"),
                new TelemetryMessage("DesiredYawAngleInDegrees:0"),
                new TelemetryMessage("DesiredRollAngleInDegrees:0,1"),
                new TelemetryMessage("DesiredPitchAngleInDegrees:0,2"),
                new TelemetryMessage("DesiredLateralVelocityInMetrePerSecond:0,3"),
                new TelemetryMessage("DesiredHorizontalVelocityInMetrePerSecond:0,4"),
                new TelemetryMessage("MainEnginesYawPercentOverwrite:0,5"),
                new TelemetryMessage("MainEnginesRollPercentOverwrite:0,6"),
                new TelemetryMessage("MainEnginesPitchPercentOverwrite:0,7"),
                new TelemetryMessage("MainEnginesGimbalPidRegulatorProportionalGain:0,8"),
                new TelemetryMessage("MainEnginesGimbalPidRegulatorIntegralGain:0,9"),
                new TelemetryMessage("MainEnginesGimbalPidRegulatorDerivativeGain:1"),
                new TelemetryMessage("LateralVelocityOffsetPidRegulatorProportionalGain:1,1"),
                new TelemetryMessage("LateralVelocityOffsetPidRegulatorIntegralGain:1,2"),
                new TelemetryMessage("LateralVelocityOffsetPidRegulatorDerivativeGain:1,3"),
                new TelemetryMessage("HorizontalVelocityOffsetPidRegulatorProportionalGain:1,4"),
                new TelemetryMessage("HorizontalVelocityOffsetPidRegulatorIntegralGain:1,5"),
                new TelemetryMessage("HorizontalVelocityOffsetPidRegulatorDerivativeGain:1,6"),
                new TelemetryMessage("----------------------------------------------------")
            };

            Assert.That(commander.ProvideTelemetry(), Is.EqualTo(expectedTelemetry));
        }

        [Test]
        public void Should_provide_a_equality_by_value_method()
        {
            // GIVEN
            var commanderA = new MainEnginesGimbalSegmentCommander(CreateFlightSegmentConfig(
                desiredYawAngleInDegrees: 0.0F,
                desiredRollAngleInDegrees: 0.0F,
                desiredPitchAngleInDegrees: 0.0F,
                desiredLateralVelocityInMetrePerSecond: null,
                desiredHorizontalVelocityInMetrePerSecond: null,
                mainEnginesYawPercentOverwrite: null,
                mainEnginesRollPercentOverwrite: null,
                mainEnginesPitchPercentOverwrite: null,
                mainEnginesGimbalPidRegulatorProportionalGain: 0.15F,
                mainEnginesGimbalPidRegulatorIntegralGain: 0.0005F,
                mainEnginesGimbalPidRegulatorDerivativeGain: 0.075F,
                lateralVelocityOffsetPidRegulatorProportionalGain: null,
                lateralVelocityOffsetPidRegulatorIntegralGain: null,
                lateralVelocityOffsetPidRegulatorDerivativeGain: null,
                horizontalVelocityOffsetPidRegulatorProportionalGain: null,
                horizontalVelocityOffsetPidRegulatorIntegralGain: null,
                horizontalVelocityOffsetPidRegulatorDerivativeGain: null));

            var commanderB = new MainEnginesGimbalSegmentCommander(CreateFlightSegmentConfig(
                desiredYawAngleInDegrees: 0.0F,
                desiredRollAngleInDegrees: 0.0F,
                desiredPitchAngleInDegrees: 0.0F,
                desiredLateralVelocityInMetrePerSecond: null,
                desiredHorizontalVelocityInMetrePerSecond: null,
                mainEnginesYawPercentOverwrite: null,
                mainEnginesRollPercentOverwrite: null,
                mainEnginesPitchPercentOverwrite: null,
                mainEnginesGimbalPidRegulatorProportionalGain: 0.15F,
                mainEnginesGimbalPidRegulatorIntegralGain: 0.0005F,
                mainEnginesGimbalPidRegulatorDerivativeGain: 0.075F,
                lateralVelocityOffsetPidRegulatorProportionalGain: null,
                lateralVelocityOffsetPidRegulatorIntegralGain: null,
                lateralVelocityOffsetPidRegulatorDerivativeGain: null,
                horizontalVelocityOffsetPidRegulatorProportionalGain: null,
                horizontalVelocityOffsetPidRegulatorIntegralGain: null,
                horizontalVelocityOffsetPidRegulatorDerivativeGain: null));

            var commanderC = new MainEnginesGimbalSegmentCommander(CreateFlightSegmentConfig(
                desiredYawAngleInDegrees: 0.0F,
                desiredRollAngleInDegrees: 0.0F,
                desiredPitchAngleInDegrees: -15.0F,
                desiredLateralVelocityInMetrePerSecond: null,
                desiredHorizontalVelocityInMetrePerSecond: null,
                mainEnginesYawPercentOverwrite: 0.0F,
                mainEnginesRollPercentOverwrite: 0.0F,
                mainEnginesPitchPercentOverwrite: -1.0F,
                mainEnginesGimbalPidRegulatorProportionalGain: null,
                mainEnginesGimbalPidRegulatorIntegralGain: null,
                mainEnginesGimbalPidRegulatorDerivativeGain: null,
                lateralVelocityOffsetPidRegulatorProportionalGain: null,
                lateralVelocityOffsetPidRegulatorIntegralGain: null,
                lateralVelocityOffsetPidRegulatorDerivativeGain: null,
                horizontalVelocityOffsetPidRegulatorProportionalGain: null,
                horizontalVelocityOffsetPidRegulatorIntegralGain: null,
                horizontalVelocityOffsetPidRegulatorDerivativeGain: null));

            // THEN
            Assert.That(commanderA.Equals(commanderB), Is.True);
            Assert.That(commanderA.Equals(commanderC), Is.False);
        }

        private static FlightSegmentConfig CreateFlightSegmentConfig(
            float desiredYawAngleInDegrees,
            float desiredRollAngleInDegrees,
            float desiredPitchAngleInDegrees,
            float? desiredLateralVelocityInMetrePerSecond,
            float? desiredHorizontalVelocityInMetrePerSecond,
            float? mainEnginesYawPercentOverwrite,
            float? mainEnginesRollPercentOverwrite,
            float? mainEnginesPitchPercentOverwrite,
            float? mainEnginesGimbalPidRegulatorProportionalGain,
            float? mainEnginesGimbalPidRegulatorIntegralGain,
            float? mainEnginesGimbalPidRegulatorDerivativeGain,
            float? lateralVelocityOffsetPidRegulatorProportionalGain,
            float? lateralVelocityOffsetPidRegulatorIntegralGain,
            float? lateralVelocityOffsetPidRegulatorDerivativeGain,
            float? horizontalVelocityOffsetPidRegulatorProportionalGain,
            float? horizontalVelocityOffsetPidRegulatorIntegralGain,
            float? horizontalVelocityOffsetPidRegulatorDerivativeGain
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
            desiredLateralVelocityInMetrePerSecond,
            null,
            desiredHorizontalVelocityInMetrePerSecond,
            null,
            null,
            null,
            null,
            mainEnginesYawPercentOverwrite,
            mainEnginesRollPercentOverwrite,
            mainEnginesPitchPercentOverwrite,
            null,
            null,
            null,
            null,
            null,
            null,
            mainEnginesGimbalPidRegulatorProportionalGain,
            mainEnginesGimbalPidRegulatorIntegralGain,
            mainEnginesGimbalPidRegulatorDerivativeGain,
            lateralVelocityOffsetPidRegulatorProportionalGain,
            lateralVelocityOffsetPidRegulatorIntegralGain,
            lateralVelocityOffsetPidRegulatorDerivativeGain,
            null,
            null,
            null,
            horizontalVelocityOffsetPidRegulatorProportionalGain,
            horizontalVelocityOffsetPidRegulatorIntegralGain,
            horizontalVelocityOffsetPidRegulatorDerivativeGain);
    }
}