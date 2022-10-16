using NUnit.Framework;
using Starship.Flight.Command.Actuation.Engine;
using Starship.Flight.Segment.Actuation.Engine;

namespace StarshipUnitTests.Flight.Segment.Actuation.Engine
{
    public sealed class MainEnginesGimbalSegmentCommandsTest
    {
        [Test]
        public void Should_expose_the_individual_commands()
        {
            // GIVEN
            var commands = new MainEnginesGimbalSegmentCommands(
                new MainEnginesYawCommand(0.0F),
                new MainEnginesRollCommand(0.0F),
                new MainEnginesPitchCommand(0.0F));

            // THEN
            Assert.That(commands.MainEnginesYawCommand,
                Is.EqualTo(new MainEnginesYawCommand(0.0F)));

            Assert.That(commands.MainEnginesRollCommand,
                Is.EqualTo(new MainEnginesRollCommand(0.0F)));

            Assert.That(commands.MainEnginesPitchCommand,
                Is.EqualTo(new MainEnginesPitchCommand(0.0F)));
        }

        [Test]
        public void Should_provide_a_equality_by_value_method()
        {
            // GIVEN
            var commandsA = new MainEnginesGimbalSegmentCommands(
                new MainEnginesYawCommand(0.0F),
                new MainEnginesRollCommand(0.0F),
                new MainEnginesPitchCommand(0.0F));

            var commandsB = new MainEnginesGimbalSegmentCommands(
                new MainEnginesYawCommand(0.0F),
                new MainEnginesRollCommand(0.0F),
                new MainEnginesPitchCommand(0.0F));

            var commandsC = new MainEnginesGimbalSegmentCommands(
                new MainEnginesYawCommand(0.0F),
                new MainEnginesRollCommand(0.0F),
                new MainEnginesPitchCommand(-15.0F));

            // THEN
            Assert.That(commandsA.Equals(commandsB), Is.True);
            Assert.That(commandsA.Equals(commandsC), Is.False);
        }
    }
}