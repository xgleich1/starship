using System.Collections.Generic;
using NUnit.Framework;
using Starship.Sensors;
using Starship.Telemetry;

namespace StarshipUnitTests.Sensors
{
    public sealed class SensorSuiteTest
    {
        [Test]
        public void Should_provide_the_telemetry_of_each_sensor()
        {
            // GIVEN
            var sensorSuite = new SensorSuite(
                new YawSensor(25),
                new RollSensor(50),
                new PitchSensor(75),
                new HeightSensor(100));

            // THEN
            var expectedTelemetry = new List<TelemetryMessage>
            {
                new TelemetryMessage("Yaw:25"),
                new TelemetryMessage("Roll:50"),
                new TelemetryMessage("Pitch:75"),
                new TelemetryMessage("Height:100")
            };

            Assert.That(sensorSuite.ProvideTelemetry(),
                Is.EqualTo(expectedTelemetry));
        }
    }
}