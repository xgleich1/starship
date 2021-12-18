using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using Starship.Sensor;
using Starship.Sensor.Attitude.Pitch;
using Starship.Sensor.Attitude.Roll;
using Starship.Sensor.Attitude.Yaw;
using Starship.Sensor.Position.Height;
using Starship.Telemetry;

namespace StarshipUnitTests.Sensor
{
    public sealed class SensorSuiteTest
    {
        private Mock<IYawSensor> _yawSensor;
        private Mock<IRollSensor> _rollSensor;
        private Mock<IPitchSensor> _pitchSensor;
        private Mock<IHeightSensor> _heightSensor;
        private SensorSuite _sensorSuite;


        [SetUp]
        public void Setup()
        {
            _yawSensor = new Mock<IYawSensor>();
            _rollSensor = new Mock<IRollSensor>();
            _pitchSensor = new Mock<IPitchSensor>();
            _heightSensor = new Mock<IHeightSensor>();

            _sensorSuite = new SensorSuite(
                _yawSensor.Object,
                _rollSensor.Object,
                _pitchSensor.Object,
                _heightSensor.Object);
        }

        [Test]
        public void Should_provide_the_telemetry_of_each_sensor()
        {
            // GIVEN
            _yawSensor.Setup(mock => mock.ProvideTelemetry()).Returns(
                new List<TelemetryMessage> { new TelemetryMessage("Yaw:0") });

            _rollSensor.Setup(mock => mock.ProvideTelemetry()).Returns(
                new List<TelemetryMessage> { new TelemetryMessage("Roll:0") });

            _pitchSensor.Setup(mock => mock.ProvideTelemetry()).Returns(
                new List<TelemetryMessage> { new TelemetryMessage("Pitch:0") });

            _heightSensor.Setup(mock => mock.ProvideTelemetry()).Returns(
                new List<TelemetryMessage> { new TelemetryMessage("Height:0") });

            // THEN
            var expectedTelemetry = new List<TelemetryMessage>
            {
                new TelemetryMessage("Yaw:0"),
                new TelemetryMessage("Roll:0"),
                new TelemetryMessage("Pitch:0"),
                new TelemetryMessage("Height:0"),
            };

            Assert.That(_sensorSuite.ProvideTelemetry(), Is.EqualTo(expectedTelemetry));
        }
    }
}