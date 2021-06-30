using System.Collections.Generic;
using NUnit.Framework;
using Starship.Sensor;
using Starship.Sensor.Attitude;
using Starship.Sensor.Position;
using Starship.Telemetry;

namespace StarshipUnitTests.Sensor
{
    public sealed class SensorSuiteTest
    {
        [Test]
        public void Should_provide_the_telemetry_of_each_sensor()
        {
            // GIVEN
            var sensorSuite = new SensorSuite(
                new YawSensor(0),
                new RollSensor(0),
                new PitchSensor(0),
                new HeightSensor(0));

            // THEN
            var expectedTelemetry = new List<TelemetryMessage>
            {
                new TelemetryMessage("Yaw:0"),
                new TelemetryMessage("Roll:0"),
                new TelemetryMessage("Pitch:0"),
                new TelemetryMessage("Height:0")
            };

            Assert.That(sensorSuite.ProvideTelemetry(),
                Is.EqualTo(expectedTelemetry));
        }
    }
}