using System.Collections.Generic;
using NUnit.Framework;
using Starship.Flight.Command.Actuation.Leg;
using Starship.Telemetry;

namespace StarshipUnitTests.Flight.Command.Actuation.Leg
{
    public sealed class LegsActuationCommandTest
    {
        [Test]
        public void Should_expose_the_commanded_extended_state()
        {
            // GIVEN
            var commandA = new LegsActuationCommand(true);
            var commandB = new LegsActuationCommand(false);

            // THEN
            Assert.That(commandA.Extended, Is.EqualTo(true));
            Assert.That(commandB.Extended, Is.EqualTo(false));
        }

        [Test]
        public void Should_provide_telemetry_containing_the_extended_state()
        {
            // GIVEN
            var command = new LegsActuationCommand(true);

            // THEN
            var expectedTelemetry = new List<TelemetryMessage>
            {
                new TelemetryMessage("LegsExtended:True")
            };

            Assert.That(command.ProvideTelemetry(), Is.EqualTo(expectedTelemetry));
        }

        [Test]
        public void Should_provide_a_equality_by_value_method()
        {
            // GIVEN
            var commandA = new LegsActuationCommand(true);
            var commandB = new LegsActuationCommand(true);
            var commandC = new LegsActuationCommand(false);

            // THEN
            Assert.That(commandA.Equals(commandB), Is.True);
            Assert.That(commandA.Equals(commandC), Is.False);
        }
    }
}