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
            var telemetryMessage = new TelemetryMessage("Yaw:0");

            // THEN
            Assert.That(telemetryMessage.Message, Is.EqualTo("Yaw:0"));
        }

        [Test]
        public void Should_compare_two_equal_telemetry_messages()
        {
            // GIVEN
            var telemetryMessageA = new TelemetryMessage("Yaw:0");
            var telemetryMessageB = new TelemetryMessage("Yaw:0");
            var telemetryMessageC = new TelemetryMessage("Yaw:1");

            // THEN
            Assert.That(telemetryMessageA.Equals(telemetryMessageB), Is.True);
            Assert.That(telemetryMessageA.Equals(telemetryMessageC), Is.False);
        }

        [Test]
        public void Should_provide_a_readable_to_string_method()
        {
            // GIVEN
            var telemetryMessage = new TelemetryMessage("Yaw:0");

            // THEN
            Assert.That(telemetryMessage.ToString(), Is.EqualTo("TelemetryMessage(Yaw:0)"));
        }
    }
}