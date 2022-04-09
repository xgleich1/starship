using NUnit.Framework;
using Starship.Flight.Regulator.Actuation.Flap;

namespace StarshipUnitTests.Flight.Regulator.Actuation.Flap
{
    public sealed class FlapsActuationRegulatorTest
    {
        private FlapsActuationRegulator _regulator;


        [SetUp]
        public void Setup()
        {
            _regulator = new FlapsActuationRegulator(0.007692307692307693F);
        }

        [Test]
        public void Should_not_regulate_below_the_minimum_actuation_percent()
        {
            // WHEN
            var percent = _regulator.RegulateValue(-15.0F, -90.0F);

            // THEN
            Assert.That(percent, Is.EqualTo(-0.5F));
        }

        [Test]
        public void Should_not_regulate_above_the_maximum_actuation_percent()
        {
            // WHEN
            var percent = _regulator.RegulateValue(-165.0F, -90.0F);

            // THEN
            Assert.That(percent, Is.EqualTo(+0.5F));
        }
    }
}