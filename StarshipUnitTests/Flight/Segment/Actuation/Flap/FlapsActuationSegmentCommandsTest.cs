using NUnit.Framework;
using Starship.Flight.Command.Actuation.Flap;
using Starship.Flight.Segment.Actuation.Flap;

namespace StarshipUnitTests.Flight.Segment.Actuation.Flap
{
    public sealed class FlapsActuationSegmentCommandsTest
    {
        [Test]
        public void Should_expose_the_individual_commands()
        {
            // GIVEN
            var commands = new FlapsActuationSegmentCommands(
                new TopLeftFlapActuationCommand(1.0F),
                new TopRightFlapActuationCommand(1.0F),
                new BottomLeftFlapActuationCommand(1.0F),
                new BottomRightFlapActuationCommand(1.0F));

            // THEN
            Assert.That(commands.TopLeftFlapActuationCommand,
                Is.EqualTo(new TopLeftFlapActuationCommand(1.0F)));

            Assert.That(commands.TopRightFlapActuationCommand,
                Is.EqualTo(new TopRightFlapActuationCommand(1.0F)));

            Assert.That(commands.BottomLeftFlapActuationCommand,
                Is.EqualTo(new BottomLeftFlapActuationCommand(1.0F)));

            Assert.That(commands.BottomRightFlapActuationCommand,
                Is.EqualTo(new BottomRightFlapActuationCommand(1.0F)));
        }

        [Test]
        public void Should_provide_a_equality_by_value_method()
        {
            // GIVEN
            var commandsA = new FlapsActuationSegmentCommands(
                new TopLeftFlapActuationCommand(1.0F),
                new TopRightFlapActuationCommand(1.0F),
                new BottomLeftFlapActuationCommand(1.0F),
                new BottomRightFlapActuationCommand(1.0F));

            var commandsB = new FlapsActuationSegmentCommands(
                new TopLeftFlapActuationCommand(1.0F),
                new TopRightFlapActuationCommand(1.0F),
                new BottomLeftFlapActuationCommand(1.0F),
                new BottomRightFlapActuationCommand(1.0F));

            var commandsC = new FlapsActuationSegmentCommands(
                new TopLeftFlapActuationCommand(1.0F),
                new TopRightFlapActuationCommand(1.0F),
                new BottomLeftFlapActuationCommand(0.0F),
                new BottomRightFlapActuationCommand(0.0F));

            // THEN
            Assert.That(commandsA.Equals(commandsB), Is.True);
            Assert.That(commandsA.Equals(commandsC), Is.False);
        }
    }
}