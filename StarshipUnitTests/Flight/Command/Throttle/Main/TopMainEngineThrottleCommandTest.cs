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
            var throttleCommand = new TopMainEngineThrottleCommand(0.5F);

            // THEN
            Assert.That(throttleCommand.ThrottlePercent, Is.EqualTo(0.5F));
        }

        [Test]
        public void Should_provide_telemetry_containing_the_throttle_percent()
        {
            // GIVEN
            var throttleCommand = new TopMainEngineThrottleCommand(0.5F);

            // THEN
            var expectedTelemetry = new List<TelemetryMessage>
            {
                new TelemetryMessage("TopMainEngineThrottlePercent:0,5")
            };

            Assert.That(throttleCommand.ProvideTelemetry(), Is.EqualTo(expectedTelemetry));
        }

        [Test]
        public void Should_compare_two_equal_top_main_engine_throttle_commands()
        {
            // GIVEN
            var throttleCommandA = new TopMainEngineThrottleCommand(0.5F);
            var throttleCommandB = new TopMainEngineThrottleCommand(0.5F);

            // THEN
            Assert.That(throttleCommandA, Is.EqualTo(throttleCommandB));
        }
    }
}