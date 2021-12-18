using System.Collections.Generic;
using NUnit.Framework;
using Starship.Flight.Command.Attitude;
using Starship.Telemetry;

namespace StarshipUnitTests.Flight.Command.Attitude
{
    public sealed class MainEngineAttitudeRollCommandTest
    {
        [Test]
        public void Should_expose_the_commanded_roll_input()
        {
            // GIVEN
            var rollCommand = new MainEngineAttitudeRollCommand(0.5F);

            // THEN
            Assert.That(rollCommand.RollInput, Is.EqualTo(0.5F));
        }

        [Test]
        public void Should_provide_telemetry_containing_the_roll_input()
        {
            // GIVEN
            var rollCommand = new MainEngineAttitudeRollCommand(0.5F);

            // THEN
            var expectedTelemetry = new List<TelemetryMessage>
            {
                new TelemetryMessage("MainEngineAttitudeRollInput:0,5")
            };

            Assert.That(rollCommand.ProvideTelemetry(), Is.EqualTo(expectedTelemetry));
        }

        [Test]
        public void Should_compare_two_equal_main_engine_attitude_roll_commands()
        {
            // GIVEN
            var rollCommandA = new MainEngineAttitudeRollCommand(0.5F);
            var rollCommandB = new MainEngineAttitudeRollCommand(0.5F);

            // THEN
            Assert.That(rollCommandA, Is.EqualTo(rollCommandB));
        }
    }
}