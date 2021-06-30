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
            var rollCommand = new MainEngineAttitudeRollCommand(0.5f);

            // THEN
            Assert.That(rollCommand.RollInput, Is.EqualTo(0.5f));
        }

        [Test]
        public void Should_provide_telemetry_containing_the_roll_input()
        {
            // GIVEN
            var rollCommand = new MainEngineAttitudeRollCommand(0.5f);

            // THEN
            var expectedTelemetry = new List<TelemetryMessage>
            {
                new TelemetryMessage("MainEngineAttitudeRollInput:0,5")
            };

            Assert.That(rollCommand.ProvideTelemetry(), Is.EqualTo(expectedTelemetry));
        }
    }
}