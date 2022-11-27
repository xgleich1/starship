using NUnit.Framework;
using Starship.Flight.Segment.Config;

namespace StarshipUnitTests.Flight.Segment.Config
{
    public sealed class FlightSegmentConfigTest
    {
        [Test]
        public void Should_provide_a_equality_by_value_method()
        {
            // GIVEN
            var configA = CreateFlightSegmentConfig(
                desiredLegsExtendedState: false);

            var configB = CreateFlightSegmentConfig(
                desiredLegsExtendedState: false);

            var configC = CreateFlightSegmentConfig(
                desiredLegsExtendedState: true);

            // THEN
            Assert.That(configA.Equals(configB), Is.True);
            Assert.That(configA.Equals(configC), Is.False);
        }

        private static FlightSegmentConfig CreateFlightSegmentConfig(bool desiredLegsExtendedState) =>
            new FlightSegmentConfig(
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                desiredLegsExtendedState,
                0.0F,
                0.0F,
                0.0F,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null);
    }
}