using System.Collections.Generic;
using NUnit.Framework;
using Starship.Flight.Command.Actuation.Leg;
using Starship.Telemetry;

namespace StarshipUnitTests.Flight.Command.Actuation.Leg
{
    public sealed class ActuateLegsCommandTest
    {
        [Test]
        public void Should_expose_the_commanded_extended_state()
        {
            // GIVEN
            var command = new ActuateLegsCommand(true);

            // THEN
            Assert.That(command.Extended, Is.EqualTo(true));
        }

        [Test]
        public void Should_provide_a_equality_by_value_method()
        {
            // GIVEN
            var commandA = new ActuateLegsCommand(true);
            var commandB = new ActuateLegsCommand(true);
            var commandC = new ActuateLegsCommand(false);

            // THEN
            Assert.That(commandA.Equals(commandB), Is.True);
            Assert.That(commandA.Equals(commandC), Is.False);
        }

        [Test]
        public void Should_provide_telemetry_containing_the_extended_state()
        {
            // GIVEN
            var command = new ActuateLegsCommand(true);

            // THEN
            var expectedTelemetry = new List<TelemetryMessage>
            {
                new TelemetryMessage("LegsExtended:True")
            };

            Assert.That(command.ProvideTelemetry(), Is.EqualTo(expectedTelemetry));
        }
    }
}