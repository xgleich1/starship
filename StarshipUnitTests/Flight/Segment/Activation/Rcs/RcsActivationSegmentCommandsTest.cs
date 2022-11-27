using NUnit.Framework;
using Starship.Flight.Command.Activation.Rcs;
using Starship.Flight.Segment.Activation.Rcs;

namespace StarshipUnitTests.Flight.Segment.Activation.Rcs
{
    public sealed class RcsActivationSegmentCommandsTest
    {
        [Test]
        public void Should_expose_the_individual_commands()
        {
            // GIVEN
            var commands = new RcsActivationSegmentCommands(
                new TopLeftRcsActivationCommand(true),
                new TopRightRcsActivationCommand(true),
                new BottomLeftRcsActivationCommand(true),
                new BottomRightRcsActivationCommand(true));

            // THEN
            Assert.That(commands.TopLeftRcsActivationCommand,
                Is.EqualTo(new TopLeftRcsActivationCommand(true)));

            Assert.That(commands.TopRightRcsActivationCommand,
                Is.EqualTo(new TopRightRcsActivationCommand(true)));

            Assert.That(commands.BottomLeftRcsActivationCommand,
                Is.EqualTo(new BottomLeftRcsActivationCommand(true)));

            Assert.That(commands.BottomRightRcsActivationCommand,
                Is.EqualTo(new BottomRightRcsActivationCommand(true)));
        }

        [Test]
        public void Should_provide_a_equality_by_value_method()
        {
            // GIVEN
            var commandsA = new RcsActivationSegmentCommands(
                new TopLeftRcsActivationCommand(true),
                new TopRightRcsActivationCommand(true),
                new BottomLeftRcsActivationCommand(true),
                new BottomRightRcsActivationCommand(true));

            var commandsB = new RcsActivationSegmentCommands(
                new TopLeftRcsActivationCommand(true),
                new TopRightRcsActivationCommand(true),
                new BottomLeftRcsActivationCommand(true),
                new BottomRightRcsActivationCommand(true));

            var commandsC = new RcsActivationSegmentCommands(
                new TopLeftRcsActivationCommand(true),
                new TopRightRcsActivationCommand(true),
                new BottomLeftRcsActivationCommand(false),
                new BottomRightRcsActivationCommand(false));

            // THEN
            Assert.That(commandsA.Equals(commandsB), Is.True);
            Assert.That(commandsA.Equals(commandsC), Is.False);
        }
    }
}