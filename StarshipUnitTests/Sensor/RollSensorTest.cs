using System.Collections.Generic;
using NUnit.Framework;
using Starship.Sensor;
using Starship.Telemetry;

namespace StarshipUnitTests.Sensor
{
    public sealed class RollSensorTest
    {
        [Test]
        public void Should_expose_the_current_roll_angle()
        {
            // GIVEN
            var rollSensor = new RollSensor(25);

            // THEN
            Assert.That(rollSensor.RollAngle, Is.EqualTo(25));
        }

        [Test]
        public void Should_provide_telemetry_containing_the_roll()
        {
            // GIVEN
            var rollSensor = new RollSensor(25);

            // THEN
            var expectedTelemetry = new List<TelemetryMessage>
            {
                new TelemetryMessage("Roll:25")
            };

            Assert.That(rollSensor.ProvideTelemetry(),
                Is.EqualTo(expectedTelemetry));
        }
    }
}