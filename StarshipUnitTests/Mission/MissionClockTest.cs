using Moq;
using NUnit.Framework;
using Starship.Mission;
using Starship.Utility.Timing;
using Starship.Utility.Timing.Units;

namespace StarshipUnitTests.Mission
{
    public sealed class MissionClockTest
    {
        private Mock<IStopwatch> _stopwatch;
        private MissionClock _missionClock;


        [Test]
        public void Should_start_the_mission_clock_with_zero_seconds()
        {
            // WHEN
            _missionClock.StartWithZeroSeconds();

            // THEN
            _stopwatch.Verify(mock => mock.Restart());
        }

        [Test]
        public void Should_expose_the_elapsed_seconds_in_the_mission()
        {
            // GIVEN
            _stopwatch.Setup(mock => mock.GetElapsedMilliseconds())
                .Returns(60000L);

            // THEN
            Assert.That(_missionClock.GetElapsedSecondsInMission(),
                Is.EqualTo(new Seconds(60)));
        }

        [SetUp]
        public void Setup()
        {
            _stopwatch = new Mock<IStopwatch>();

            _missionClock = new MissionClock(_stopwatch.Object);
        }
    }
}