using System.Collections.Generic;
using NUnit.Framework;
using Starship.Flight.Command.Activation.Rcs;
using Starship.Telemetry;

namespace StarshipUnitTests.Flight.Command.Activation.Rcs
{
    public sealed class BottomLeftRcsActivationCommandTest
    {
        [Test]
        public void Should_expose_the_commanded_activated_state()
        {
            // GIVEN
            var commandA = new BottomLeftRcsActivationCommand(true);
            var commandB = new BottomLeftRcsActivationCommand(false);

            // THEN
            Assert.That(commandA.Activated, Is.EqualTo(true));
            Assert.That(commandB.Activated, Is.EqualTo(false));
        }

        [Test]
        public void Should_provide_telemetry_containing_the_activated_state()
        {
            // GIVEN
            var command = new BottomLeftRcsActivationCommand(true);

            // THEN
            var expectedTelemetry = new List<TelemetryMessage>
            {
                new TelemetryMessage("BottomLeftRcsActivated:True")
            };

            Assert.That(command.ProvideTelemetry(), Is.EqualTo(expectedTelemetry));
        }

        [Test]
        public void Should_provide_a_equality_by_value_method()
        {
            // GIVEN
            var commandA = new BottomLeftRcsActivationCommand(true);
            var commandB = new BottomLeftRcsActivationCommand(true);
            var commandC = new BottomLeftRcsActivationCommand(false);

            // THEN
            Assert.That(commandA.Equals(commandB), Is.True);
            Assert.That(commandA.Equals(commandC), Is.False);
        }
    }
}