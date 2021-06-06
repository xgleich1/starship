using System.Collections.Generic;
using NUnit.Framework;
using Starship.Sensors;
using Starship.Telemetry;

namespace StarshipUnitTests.Sensors
{
    public sealed class YawSensorTest
    {
        [Test]
        public void Should_expose_the_current_yaw_angle()
        {
            // GIVEN
            var yawSensor = new YawSensor(25);

            // THEN
            Assert.That(yawSensor.YawAngle, Is.EqualTo(25));
        }

        [Test]
        public void Should_provide_telemetry_containing_the_yaw()
        {
            // GIVEN
            var yawSensor = new YawSensor(25);

            // THEN
            var expectedTelemetry = new List<TelemetryMessage>
            {
                new TelemetryMessage("Yaw:25")
            };

            Assert.That(yawSensor.ProvideTelemetry(),
                Is.EqualTo(expectedTelemetry));
        }
    }
}