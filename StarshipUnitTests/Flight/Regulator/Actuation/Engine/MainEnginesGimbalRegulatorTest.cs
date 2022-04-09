using NUnit.Framework;
using Starship.Flight.Regulator.Actuation.Engine;

namespace StarshipUnitTests.Flight.Regulator.Actuation.Engine
{
    public sealed class MainEnginesGimbalRegulatorTest
    {
        private MainEnginesGimbalRegulator _regulator;


        [SetUp]
        public void Setup()
        {
            _regulator = new MainEnginesGimbalRegulator(0.011111111111111112F);
        }

        [Test]
        public void Should_not_regulate_below_the_minimum_gimbal_percent()
        {
            // WHEN
            var percent = _regulator.RegulateValue(100.0F, 0.0F);

            // THEN
            Assert.That(percent, Is.EqualTo(-1.0F));
        }

        [Test]
        public void Should_not_regulate_above_the_maximum_gimbal_percent()
        {
            // WHEN
            var percent = _regulator.RegulateValue(-100.0F, 0.0F);

            // THEN
            Assert.That(percent, Is.EqualTo(+1.0F));
        }
    }
}