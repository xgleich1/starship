using System.Collections.Generic;
using NUnit.Framework;
using Starship.Flight.Command.Attitude;
using Starship.Telemetry;

namespace StarshipUnitTests.Flight.Command.Attitude
{
    public sealed class MainEngineAttitudeYawCommandTest
    {
        [Test]
        public void Should_expose_the_commanded_yaw_input()
        {
            // GIVEN
            var yawCommand = new MainEngineAttitudeYawCommand(0.5F);

            // THEN
            Assert.That(yawCommand.YawInput, Is.EqualTo(0.5F));
        }

        [Test]
        public void Should_provide_telemetry_containing_the_yaw_input()
        {
            // GIVEN
            var yawCommand = new MainEngineAttitudeYawCommand(0.5F);

            // THEN
            var expectedTelemetry = new List<TelemetryMessage>
            {
                new TelemetryMessage("MainEngineAttitudeYawInput:0,5")
            };

            Assert.That(yawCommand.ProvideTelemetry(), Is.EqualTo(expectedTelemetry));
        }

        [Test]
        public void Should_compare_two_equal_main_engine_attitude_yaw_commands()
        {
            // GIVEN
            var yawCommandA = new MainEngineAttitudeYawCommand(0.5F);
            var yawCommandB = new MainEngineAttitudeYawCommand(0.5F);

            // THEN
            Assert.That(yawCommandA, Is.EqualTo(yawCommandB));
        }
    }
}