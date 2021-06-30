using System.Collections.Generic;
using NUnit.Framework;
using Starship.Flight.Command.Attitude;
using Starship.Telemetry;

namespace StarshipUnitTests.Flight.Command.Attitude
{
    public sealed class MainEngineAttitudePitchCommandTest
    {
        [Test]
        public void Should_expose_the_commanded_pitch_input()
        {
            // GIVEN
            var pitchCommand = new MainEngineAttitudePitchCommand(0.5f);

            // THEN
            Assert.That(pitchCommand.PitchInput, Is.EqualTo(0.5f));
        }

        [Test]
        public void Should_provide_telemetry_containing_the_pitch_input()
        {
            // GIVEN
            var pitchCommand = new MainEngineAttitudePitchCommand(0.5f);

            // THEN
            var expectedTelemetry = new List<TelemetryMessage>
            {
                new TelemetryMessage("MainEngineAttitudePitchInput:0,5")
            };

            Assert.That(pitchCommand.ProvideTelemetry(), Is.EqualTo(expectedTelemetry));
        }
    }
}