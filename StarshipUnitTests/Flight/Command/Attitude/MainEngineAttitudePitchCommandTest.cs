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
            var pitchCommand = new MainEngineAttitudePitchCommand(0.5F);

            // THEN
            Assert.That(pitchCommand.PitchInput, Is.EqualTo(0.5F));
        }

        [Test]
        public void Should_provide_telemetry_containing_the_pitch_input()
        {
            // GIVEN
            var pitchCommand = new MainEngineAttitudePitchCommand(0.5F);

            // THEN
            var expectedTelemetry = new List<TelemetryMessage>
            {
                new TelemetryMessage("MainEngineAttitudePitchInput:0,5")
            };

            Assert.That(pitchCommand.ProvideTelemetry(), Is.EqualTo(expectedTelemetry));
        }

        [Test]
        public void Should_compare_two_equal_main_engine_attitude_pitch_commands()
        {
            // GIVEN
            var pitchCommandA = new MainEngineAttitudePitchCommand(0.5F);
            var pitchCommandB = new MainEngineAttitudePitchCommand(0.5F);

            // THEN
            Assert.That(pitchCommandA, Is.EqualTo(pitchCommandB));
        }
    }
}