using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using Starship.Sensor;
using Starship.Sensor.Altitude;
using Starship.Sensor.Attitude;
using Starship.Sensor.Velocity;
using Starship.Telemetry;

namespace StarshipUnitTests.Sensor
{
    public sealed class SensorSuiteTest
    {
        private Mock<IAttitudeSensor> _attitudeSensor;
        private Mock<IAltitudeSensor> _altitudeSensor;
        private Mock<IVelocitySensor> _velocitySensor;
        private SensorSuite _sensorSuite;


        [SetUp]
        public void Setup()
        {
            _attitudeSensor = new Mock<IAttitudeSensor>();
            _altitudeSensor = new Mock<IAltitudeSensor>();
            _velocitySensor = new Mock<IVelocitySensor>();

            _sensorSuite = new SensorSuite(
                _attitudeSensor.Object,
                _altitudeSensor.Object,
                _velocitySensor.Object);
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
            _altitudeSensor.Setup(mock => mock.ProvideTelemetry()).Returns(
                new List<TelemetryMessage>
                {
                    new TelemetryMessage("Altitude:0")
                });
            _velocitySensor.Setup(mock => mock.ProvideTelemetry()).Returns(
                new List<TelemetryMessage>
                {
                    new TelemetryMessage("LateralVelocity:0"),
                    new TelemetryMessage("VerticalVelocity:0"),
                    new TelemetryMessage("HorizontalVelocity:0")
                });

            // THEN
            var expectedTelemetry = new List<TelemetryMessage>
            {
                new TelemetryMessage("Yaw:0"),
                new TelemetryMessage("Roll:0"),
                new TelemetryMessage("Pitch:0"),
                new TelemetryMessage("Altitude:0"),
                new TelemetryMessage("LateralVelocity:0"),
                new TelemetryMessage("VerticalVelocity:0"),
                new TelemetryMessage("HorizontalVelocity:0")
            };

            Assert.That(_sensorSuite.ProvideTelemetry(), Is.EqualTo(expectedTelemetry));
        }
    }
}