using System.Collections.Generic;
using NUnit.Framework;
using Starship.Flight.Stabilization;

namespace StarshipUnitTests.Flight.Stabilization
{
    public sealed class AttitudeStabilizerTest
    {
        private AttitudeStabilizer _attitudeStabilizer;


        [SetUp]
        public void Setup()
        {
            _attitudeStabilizer = new AttitudeStabilizer();
        }

        [Test, TestCaseSource(nameof(ProvideTestData))]
        public void Should_proportionally_stabilize_an_attitude(
            float currentAttitudeAngleInDegrees,
            float desiredAttitudeAngleInDegrees,
            float expectedCalculatedAttitudeInput)
        {
            // WHEN
            var calculatedAttitudeInput =
                _attitudeStabilizer.CalculateAttitudeInput(
                    currentAttitudeAngleInDegrees,
                    desiredAttitudeAngleInDegrees);

            // THEN
            Assert.That(calculatedAttitudeInput,
                Is.EqualTo(expectedCalculatedAttitudeInput));
        }

        private static IEnumerable<TestCaseData> ProvideTestData() =>
            new List<TestCaseData>
            {
                // Test data parameters:
                // currentAttitudeAngleInDegrees,
                // desiredAttitudeAngleInDegrees,
                // expectedCalculatedAttitudeInput
                new TestCaseData(75F, 90F, 0.150000006F),
                new TestCaseData(80F, 90F, 0.100000001F),
                new TestCaseData(85F, 90F, 0.0500000007F),
                new TestCaseData(90F, 90F, 0.0F),
                new TestCaseData(95F, 90F, -0.0500000007F),
                new TestCaseData(100F, 90F, -0.100000001F),
                new TestCaseData(105F, 90F, -0.150000006F)
            };
    }
}