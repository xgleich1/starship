using NUnit.Framework;
using Starship.Utility.Math;

namespace StarshipUnitTests.Utility.Math
{
    public sealed class ClampingTest
    {
        [Test]
        public void Should_clamp_a_float_when_its_smaller_than_the_minimum()
        {
            // GIVEN
            var clampedFloat = -1.1F.Clamp(-1.0F, 1.0F);

            // THEN
            Assert.That(clampedFloat, Is.EqualTo(-1.0F));
        }

        [Test]
        public void Should_not_clamp_a_float_when_its_equal_to_the_minimum()
        {
            // GIVEN
            var clampedFloat = -1.0F.Clamp(-1.0F, 1.0F);

            // THEN
            Assert.That(clampedFloat, Is.EqualTo(-1.0F));
        }

        [Test]
        public void Should_not_clamp_a_float_when_its_bigger_than_the_minimum()
        {
            // GIVEN
            var clampedFloat = -0.9F.Clamp(-1.0F, 1.0F);

            // THEN
            Assert.That(clampedFloat, Is.EqualTo(-0.9F));
        }

        [Test]
        public void Should_clamp_a_float_when_its_bigger_than_the_maximum()
        {
            // GIVEN
            var clampedFloat = 1.1F.Clamp(-1.0F, 1.0F);

            // THEN
            Assert.That(clampedFloat, Is.EqualTo(1.0F));
        }

        [Test]
        public void Should_not_clamp_a_float_when_its_equal_to_the_maximum()
        {
            // GIVEN
            var clampedFloat = 1.0F.Clamp(-1.0F, 1.0F);

            // THEN
            Assert.That(clampedFloat, Is.EqualTo(1.0F));
        }

        [Test]
        public void Should_not_clamp_a_float_when_its_smaller_than_the_maximum()
        {
            // GIVEN
            var clampedFloat = 0.9F.Clamp(-1.0F, 1.0F);

            // THEN
            Assert.That(clampedFloat, Is.EqualTo(0.9F));
        }
    }
}