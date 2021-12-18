using NUnit.Framework;
using Starship.Utility.Timing.Units;

namespace StarshipUnitTests.Utility.Timing.Units
{
    public sealed class SecondsTest
    {
        [Test]
        public void Should_expose_the_quantity_of_seconds()
        {
            // GIVEN
            var seconds = new Seconds(25L);

            // THEN
            Assert.That(seconds.Quantity, Is.EqualTo(25L));
        }

        [Test]
        public void Should_compare_two_equal_seconds_wrapper()
        {
            // GIVEN
            var secondsA = new Seconds(25L);
            var secondsB = new Seconds(25L);

            // THEN
            Assert.That(secondsA, Is.EqualTo(secondsB));
        }
    }
}