using NUnit.Framework;
using Starship.Utility.Math;

namespace StarshipUnitTests.Utility.Math
{
    public sealed class PidRegulatorTest
    {
        [Test]
        public void Should_not_output_less_than_the_set_minimum()
        {
            // GIVEN
            var pidRegulator = new PidRegulator(
                minimumOutput: -1.0F,
                maximumOutput: 1.0F,
                proportionalGain: 1.0F,
                integralGain: 0.0F,
                derivativeGain: 0.0F);

            // WHEN
            var output = pidRegulator.RegulateValue(
                desiredValue: 0.0F,
                processValue: 5.0F);

            // THEN
            Assert.That(output, Is.EqualTo(-1.0F));
        }

        [Test]
        public void Should_not_output_more_than_the_set_maximum()
        {
            // GIVEN
            var pidRegulator = new PidRegulator(
                minimumOutput: -1.0F,
                maximumOutput: 1.0F,
                proportionalGain: 1.0F,
                integralGain: 0.0F,
                derivativeGain: 0.0F);

            // WHEN
            var output = pidRegulator.RegulateValue(
                desiredValue: 0.0F,
                processValue: -5.0F);

            // THEN
            Assert.That(output, Is.EqualTo(1.0F));
        }
    }
}