using System.Collections.Generic;
using NUnit.Framework;
using Starship.Sensors;
using Starship.Telemetry;

namespace StarshipUnitTests.Sensors
{
    public sealed class PitchSensorTest
    {
        [Test]
        public void Should_expose_the_current_pitch_angle()
        {
            // GIVEN
            var pitchSensor = new PitchSensor(25);

            // THEN
            Assert.That(pitchSensor.PitchAngle, Is.EqualTo(25));
        }

        [Test]
        public void Should_provide_telemetry_containing_the_pitch()
        {
            // GIVEN
            var pitchSensor = new PitchSensor(25);

            // THEN
            var expectedTelemetry = new List<TelemetryMessage>
            {
                new TelemetryMessage("Pitch:25")
            };

            Assert.That(pitchSensor.ProvideTelemetry(),
                Is.EqualTo(expectedTelemetry));
        }
    }
}