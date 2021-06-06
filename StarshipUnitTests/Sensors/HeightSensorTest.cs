using System.Collections.Generic;
using NUnit.Framework;
using Starship.Sensors;
using Starship.Telemetry;

namespace StarshipUnitTests.Sensors
{
    public sealed class HeightSensorTest
    {
        [Test]
        public void Should_expose_the_current_height_in_meters()
        {
            // GIVEN
            var heightSensor = new HeightSensor(200);

            // THEN
            Assert.That(heightSensor.HeightInMeters, Is.EqualTo(200));
        }

        [Test]
        public void Should_provide_telemetry_containing_the_height()
        {
            // GIVEN
            var heightSensor = new HeightSensor(200);

            // THEN
            var expectedTelemetry = new List<TelemetryMessage>
            {
                new TelemetryMessage("Height:200")
            };

            Assert.That(heightSensor.ProvideTelemetry(),
                Is.EqualTo(expectedTelemetry));
        }
    }
}