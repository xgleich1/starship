using System.Collections.Generic;
using NUnit.Framework;
using Starship.Flight.Command.Actuation.Flap;
using Starship.Telemetry;

namespace StarshipUnitTests.Flight.Command.Actuation.Flap
{
    public sealed class TopLeftFlapActuationCommandTest
    {
        [Test]
        public void Should_clamp_and_expose_the_commanded_deploy_percent()
        {
            // GIVEN
            var commandA = new TopLeftFlapActuationCommand(-0.1F);
            var commandB = new TopLeftFlapActuationCommand(0.0F);
            var commandC = new TopLeftFlapActuationCommand(0.5F);
            var commandD = new TopLeftFlapActuationCommand(1.0F);
            var commandE = new TopLeftFlapActuationCommand(1.1F);

            // THEN
            Assert.That(commandA.DeployPercent, Is.EqualTo(0.0F));
            Assert.That(commandB.DeployPercent, Is.EqualTo(0.0F));
            Assert.That(commandC.DeployPercent, Is.EqualTo(0.5F));
            Assert.That(commandD.DeployPercent, Is.EqualTo(1.0F));
            Assert.That(commandE.DeployPercent, Is.EqualTo(1.0F));
        }

        [Test]
        public void Should_provide_telemetry_with_the_unclamped_deploy_percent()
        {
            // GIVEN
            var command = new TopLeftFlapActuationCommand(1.1F);

            // THEN
            var expectedTelemetry = new List<TelemetryMessage>
            {
                new TelemetryMessage("TopLeftFlapDeployPercent:1,1")
            };

            Assert.That(command.ProvideTelemetry(), Is.EqualTo(expectedTelemetry));
        }

        [Test]
        public void Should_provide_a_equality_by_value_method()
        {
            // GIVEN
            var commandA = new TopLeftFlapActuationCommand(0.5F);
            var commandB = new TopLeftFlapActuationCommand(0.5F);
            var commandC = new TopLeftFlapActuationCommand(1.0F);

            // THEN
            Assert.That(commandA.Equals(commandB), Is.True);
            Assert.That(commandA.Equals(commandC), Is.False);
        }
    }
}