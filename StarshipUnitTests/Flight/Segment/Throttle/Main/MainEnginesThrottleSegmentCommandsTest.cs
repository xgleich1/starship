using NUnit.Framework;
using Starship.Flight.Command.Throttle.Main;
using Starship.Flight.Segment.Throttle.Main;

namespace StarshipUnitTests.Flight.Segment.Throttle.Main
{
    public sealed class MainEnginesThrottleSegmentCommandsTest
    {
        [Test]
        public void Should_expose_the_individual_commands()
        {
            // GIVEN
            var commands = new MainEnginesThrottleSegmentCommands(
                new TopMainEngineThrottleCommand(1.0F),
                new BottomLeftMainEngineThrottleCommand(1.0F),
                new BottomRightMainEngineThrottleCommand(1.0F));

            // THEN
            Assert.That(commands.TopMainEngineThrottleCommand,
                Is.EqualTo(new TopMainEngineThrottleCommand(1.0F)));

            Assert.That(commands.BottomLeftMainEngineThrottleCommand,
                Is.EqualTo(new BottomLeftMainEngineThrottleCommand(1.0F)));

            Assert.That(commands.BottomRightMainEngineThrottleCommand,
                Is.EqualTo(new BottomRightMainEngineThrottleCommand(1.0F)));
        }

        [Test]
        public void Should_provide_a_equality_by_value_method()
        {
            // GIVEN
            var commandsA = new MainEnginesThrottleSegmentCommands(
                new TopMainEngineThrottleCommand(1.0F),
                new BottomLeftMainEngineThrottleCommand(1.0F),
                new BottomRightMainEngineThrottleCommand(1.0F));

            var commandsB = new MainEnginesThrottleSegmentCommands(
                new TopMainEngineThrottleCommand(1.0F),
                new BottomLeftMainEngineThrottleCommand(1.0F),
                new BottomRightMainEngineThrottleCommand(1.0F));

            var commandsC = new MainEnginesThrottleSegmentCommands(
                new TopMainEngineThrottleCommand(0.0F),
                new BottomLeftMainEngineThrottleCommand(0.0F),
                new BottomRightMainEngineThrottleCommand(0.0F));

            // THEN
            Assert.That(commandsA.Equals(commandsB), Is.True);
            Assert.That(commandsA.Equals(commandsC), Is.False);
        }
    }
}