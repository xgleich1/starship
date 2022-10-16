using System.Collections.Generic;
using NUnit.Framework;
using Starship.Flight.Command.Actuation.Engine;
using Starship.Telemetry;

namespace StarshipUnitTests.Flight.Command.Actuation.Engine
{
    public sealed class MainEnginesRollCommandTest
    {
        [Test]
        public void Should_clamp_and_expose_the_commanded_roll_percent()
        {
            // GIVEN
            var commandA = new MainEnginesRollCommand(-1.1F);
            var commandB = new MainEnginesRollCommand(-1.0F);
            var commandC = new MainEnginesRollCommand(0.0F);
            var commandD = new MainEnginesRollCommand(1.0F);
            var commandE = new MainEnginesRollCommand(1.1F);

            // THEN
            Assert.That(commandA.RollPercent, Is.EqualTo(-1.0F));
            Assert.That(commandB.RollPercent, Is.EqualTo(-1.0F));
            Assert.That(commandC.RollPercent, Is.EqualTo(0.0F));
            Assert.That(commandD.RollPercent, Is.EqualTo(1.0F));
            Assert.That(commandE.RollPercent, Is.EqualTo(1.0F));
        }

        [Test]
        public void Should_provide_telemetry_with_the_unclamped_roll_percent()
        {
            // GIVEN
            var command = new MainEnginesRollCommand(1.1F);

            // THEN
            var expectedTelemetry = new List<TelemetryMessage>
            {
                new TelemetryMessage("MainEnginesRollPercent:1,1")
            };

            Assert.That(command.ProvideTelemetry(), Is.EqualTo(expectedTelemetry));
        }

        [Test]
        public void Should_provide_a_equality_by_value_method()
        {
            // GIVEN
            var commandA = new MainEnginesRollCommand(0.5F);
            var commandB = new MainEnginesRollCommand(0.5F);
            var commandC = new MainEnginesRollCommand(1.0F);

            // THEN
            Assert.That(commandA.Equals(commandB), Is.True);
            Assert.That(commandA.Equals(commandC), Is.False);
        }
    }
}