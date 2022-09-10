using System.Collections.Generic;
using NUnit.Framework;
using Starship.Flight.Command.Actuation.Engine;
using Starship.Telemetry;

namespace StarshipUnitTests.Flight.Command.Actuation.Engine
{
    public sealed class MainEnginesPitchCommandTest
    {
        [Test]
        public void Should_expose_the_commanded_pitch_percent()
        {
            // GIVEN
            var command = new MainEnginesPitchCommand(0.5F);

            // THEN
            Assert.That(command.PitchPercent, Is.EqualTo(0.5F));
        }

        [Test]
        public void Should_provide_a_equality_by_value_method()
        {
            // GIVEN
            var commandA = new MainEnginesPitchCommand(0.5F);
            var commandB = new MainEnginesPitchCommand(0.5F);
            var commandC = new MainEnginesPitchCommand(1.0F);

            // THEN
            Assert.That(commandA.Equals(commandB), Is.True);
            Assert.That(commandA.Equals(commandC), Is.False);
        }

        [Test]
        public void Should_provide_telemetry_containing_the_pitch_percent()
        {
            // GIVEN
            var command = new MainEnginesPitchCommand(0.5F);

            // THEN
            var expectedTelemetry = new List<TelemetryMessage>
            {
                new TelemetryMessage("MainEnginesPitchPercent:0,5")
            };

            Assert.That(command.ProvideTelemetry(), Is.EqualTo(expectedTelemetry));
        }
    }
}