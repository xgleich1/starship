using NUnit.Framework;
using Starship.Utility.Time.Units;

namespace StarshipUnitTests.Utility.Time.Units
{
    public sealed class SecondsTest
    {
        [Test]
        public void Should_expose_the_quantity_of_seconds()
        {
            // GIVEN
            var seconds = new Seconds(1L);

            // THEN
            Assert.That(seconds.Quantity, Is.EqualTo(1L));
        }

        [Test]
        public void Should_provide_a_equality_by_value_method()
        {
            // GIVEN
            var secondsA = new Seconds(1L);
            var secondsB = new Seconds(1L);
            var secondsC = new Seconds(2L);

            // THEN
            Assert.That(secondsA.Equals(secondsB), Is.True);
            Assert.That(secondsA.Equals(secondsC), Is.False);
        }

        [Test]
        public void Should_provide_a_smaller_relation_operator()
        {
            // GIVEN
            var secondsA = new Seconds(1L);
            var secondsB = new Seconds(1L);
            var secondsC = new Seconds(2L);

            // THEN
            Assert.That(secondsA < secondsC, Is.True);
            Assert.That(secondsA < secondsB, Is.False);
            Assert.That(secondsC < secondsA, Is.False);
        }

        [Test]
        public void Should_provide_a_smaller_or_equal_relation_operator()
        {
            // GIVEN
            var secondsA = new Seconds(1L);
            var secondsB = new Seconds(1L);
            var secondsC = new Seconds(2L);

            // THEN
            Assert.That(secondsA <= secondsC, Is.True);
            Assert.That(secondsA <= secondsB, Is.True);
            Assert.That(secondsC <= secondsA, Is.False);
        }

        [Test]
        public void Should_provide_a_greater_relation_operator()
        {
            // GIVEN
            var secondsA = new Seconds(1L);
            var secondsB = new Seconds(1L);
            var secondsC = new Seconds(2L);

            // THEN
            Assert.That(secondsC > secondsA, Is.True);
            Assert.That(secondsA > secondsB, Is.False);
            Assert.That(secondsA > secondsC, Is.False);
        }

        [Test]
        public void Should_provide_a_greater_or_equal_relation_operator()
        {
            // GIVEN
            var secondsA = new Seconds(1L);
            var secondsB = new Seconds(1L);
            var secondsC = new Seconds(2L);

            // THEN
            Assert.That(secondsC >= secondsA, Is.True);
            Assert.That(secondsA >= secondsB, Is.True);
            Assert.That(secondsA >= secondsC, Is.False);
        }
    }
}