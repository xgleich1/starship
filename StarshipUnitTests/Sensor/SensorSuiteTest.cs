using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using Starship.Sensor;
using Starship.Sensor.Attitude;
using Starship.Telemetry;

namespace StarshipUnitTests.Sensor
{
    public sealed class SensorSuiteTest
    {
        private Mock<IAttitudeSensor> _attitudeSensor;
        private SensorSuite _sensorSuite;


        [SetUp]
        public void Setup()
        {
            _attitudeSensor = new Mock<IAttitudeSensor>();

            _sensorSuite = new SensorSuite(_attitudeSensor.Object);
        }

        [Test]
        public void Should_provide_the_telemetry_of_each_sensor()
        {
            // GIVEN
            _attitudeSensor.Setup(mock => mock.ProvideTelemetry()).Returns(
                new List<TelemetryMessage>
                {
                    new TelemetryMessage("Yaw:0"),
                    new TelemetryMessage("Roll:0"),
                    new TelemetryMessage("Pitch:0")
                });

            // THEN
            var expectedTelemetry = new List<TelemetryMessage>
            {
                new TelemetryMessage("Yaw:0"),
                new TelemetryMessage("Roll:0"),
                new TelemetryMessage("Pitch:0")
            };

            Assert.That(_sensorSuite.ProvideTelemetry(), Is.EqualTo(expectedTelemetry));
        }
    }
}