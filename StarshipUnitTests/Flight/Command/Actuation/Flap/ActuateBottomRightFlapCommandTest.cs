using System.Collections.Generic;
using NUnit.Framework;
using Starship.Flight.Command.Actuation.Flap;
using Starship.Telemetry;

namespace StarshipUnitTests.Flight.Command.Actuation.Flap
{
    public sealed class ActuateBottomRightFlapCommandTest
    {
        [Test]
        public void Should_expose_the_commanded_deploy_percent()
        {
            // GIVEN
            var command = new ActuateBottomRightFlapCommand(0.5F);

            // THEN
            Assert.That(command.DeployPercent, Is.EqualTo(0.5F));
        }

        [Test]
        public void Should_provide_a_equality_by_value_method()
        {
            // GIVEN
            var commandA = new ActuateBottomRightFlapCommand(0.5F);
            var commandB = new ActuateBottomRightFlapCommand(0.5F);
            var commandC = new ActuateBottomRightFlapCommand(1.0F);

            // THEN
            Assert.That(commandA.Equals(commandB), Is.True);
            Assert.That(commandA.Equals(commandC), Is.False);
        }

        [Test]
        public void Should_provide_telemetry_containing_the_deploy_percent()
        {
            // GIVEN
            var command = new ActuateBottomRightFlapCommand(0.5F);

            // THEN
            var expectedTelemetry = new List<TelemetryMessage>
            {
                new TelemetryMessage("BottomRightFlapDeployPercent:0,5")
            };

            Assert.That(command.ProvideTelemetry(), Is.EqualTo(expectedTelemetry));
        }
    }
}