using System.Collections.Generic;
using NUnit.Framework;
using Starship.Flight.Command.Throttle.Main;
using Starship.Telemetry;

namespace StarshipUnitTests.Flight.Command.Throttle.Main
{
    public sealed class TopMainEngineThrottleCommandTest
    {
        [Test]
        public void Should_expose_the_commanded_throttle_percent()
        {
            // GIVEN
            var command = new TopMainEngineThrottleCommand(0.5F);

            // THEN
            Assert.That(command.ThrottlePercent, Is.EqualTo(0.5F));
        }

        [Test]
        public void Should_provide_a_equality_by_value_method()
        {
            // GIVEN
            var commandA = new TopMainEngineThrottleCommand(0.5F);
            var commandB = new TopMainEngineThrottleCommand(0.5F);
            var commandC = new TopMainEngineThrottleCommand(1.0F);

            // THEN
            Assert.That(commandA.Equals(commandB), Is.True);
            Assert.That(commandA.Equals(commandC), Is.False);
        }

        [Test]
        public void Should_provide_telemetry_containing_the_throttle_percent()
        {
            // GIVEN
            var command = new TopMainEngineThrottleCommand(0.5F);

            // THEN
            var expectedTelemetry = new List<TelemetryMessage>
            {
                new TelemetryMessage("TopMainEngineThrottlePercent:0,5")
            };

            Assert.That(command.ProvideTelemetry(), Is.EqualTo(expectedTelemetry));
        }
    }
}