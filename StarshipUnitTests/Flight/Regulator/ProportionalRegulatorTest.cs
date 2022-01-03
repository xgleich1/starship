using System.Collections.Generic;
using NUnit.Framework;
using Starship.Flight.Regulator;

namespace StarshipUnitTests.Flight.Regulator
{
    public sealed class ProportionalRegulatorTest
    {
        private ProportionalRegulator _proportionalRegulator;


        [SetUp]
        public void Setup()
        {
            _proportionalRegulator = new TestProportionalRegulator();
        }

        [Test, TestCaseSource(nameof(ProvideTestData))]
        public void Should_proportionally_regulate_a_value(
            float currentValue,
            float desiredValue,
            float expectedOutput)
        {
            // WHEN
            var output = _proportionalRegulator
                .RegulateValue(currentValue, desiredValue);

            // THEN
            Assert.That(output, Is.EqualTo(expectedOutput));
        }

        private static IEnumerable<TestCaseData> ProvideTestData() =>
            new List<TestCaseData>
            {
                // Parameters:
                // currentValue
                // desiredValue
                // expectedOutput
                new TestCaseData(45F, 90F, 1.0F),
                new TestCaseData(50F, 90F, 0.888888896F),
                new TestCaseData(55F, 90F, 0.777777791F),
                new TestCaseData(75F, 90F, 0.333333343F),
                new TestCaseData(80F, 90F, 0.222222224F),
                new TestCaseData(85F, 90F, 0.111111112F),
                new TestCaseData(90F, 90F, 0.0F),
                new TestCaseData(95F, 90F, -0.111111112F),
                new TestCaseData(100F, 90F, -0.222222224F),
                new TestCaseData(105F, 90F, -0.333333343F),
                new TestCaseData(125F, 90F, -0.777777791F),
                new TestCaseData(130F, 90F, -0.888888896F),
                new TestCaseData(135F, 90F, -1.0F)
            };

        private sealed class TestProportionalRegulator : ProportionalRegulator
        {
            protected override float MinimumOutput => -1.0F;

            protected override float MaximumOutput => 1.0F;

            protected override float ProportionalGain => 0.022222222222222223F;
        }
    }
}