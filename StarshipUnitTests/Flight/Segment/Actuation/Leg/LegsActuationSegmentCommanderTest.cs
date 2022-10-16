using System.Collections.Generic;
using NUnit.Framework;
using Starship.Flight.Segment.Actuation.Leg;
using Starship.Flight.Segment.Config;
using Starship.Telemetry;

namespace StarshipUnitTests.Flight.Segment.Actuation.Leg
{
    public sealed class LegsActuationSegmentCommanderTest
    {
        [Test]
        public void Should_provide_telemetry_consisting_of_the_processed_config_values()
        {
            // GIVEN
            var commander = new LegsActuationSegmentCommander(
                CreateFlightSegmentConfig(desiredLegsExtendedState: true));

            // THEN
            var expectedTelemetry = new List<TelemetryMessage>
            {
                new TelemetryMessage("--- Legs Actuation Segment Commander Config ---"),
                new TelemetryMessage("DesiredLegsExtendedState:True"),
                new TelemetryMessage("-----------------------------------------------")
            };

            Assert.That(commander.ProvideTelemetry(), Is.EqualTo(expectedTelemetry));
        }

        [Test]
        public void Should_provide_a_equality_by_value_method()
        {
            // GIVEN
            var commanderA = new LegsActuationSegmentCommander(
                CreateFlightSegmentConfig(desiredLegsExtendedState: true));

            var commanderB = new LegsActuationSegmentCommander(
                CreateFlightSegmentConfig(desiredLegsExtendedState: true));

            var commanderC = new LegsActuationSegmentCommander(
                CreateFlightSegmentConfig(desiredLegsExtendedState: false));

            // THEN
            Assert.That(commanderA.Equals(commanderB), Is.True);
            Assert.That(commanderA.Equals(commanderC), Is.False);
        }

        private static FlightSegmentConfig CreateFlightSegmentConfig(bool desiredLegsExtendedState) =>
            new FlightSegmentConfig(
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
                desiredLegsExtendedState,
                0,
                0,
                0,
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