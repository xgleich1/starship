using NUnit.Framework;
using Starship.Telemetry;

namespace StarshipUnitTests.Telemetry
{
    public sealed class TelemetryMessageTest
    {
        [Test]
        public void Should_expose_the_textual_telemetry_message()
        {
            // GIVEN
            var telemetryMessage = new TelemetryMessage("Yaw:25");

            // THEN
            Assert.That(telemetryMessage.Message, Is.EqualTo("Yaw:25"));
        }

        [Test]
        public void Should_compare_two_equal_telemetry_messages()
        {
            // GIVEN
            var telemetryMessageA = new TelemetryMessage("Yaw:25");
            var telemetryMessageB = new TelemetryMessage("Yaw:25");

            // THEN
            Assert.That(telemetryMessageA, Is.EqualTo(telemetryMessageB));
        }
    }
}