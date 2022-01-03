using Moq;
using NUnit.Framework;
using Starship.Mission;
using Starship.Utility.Timing;
using Starship.Utility.Timing.Units;

namespace StarshipUnitTests.Mission
{
    public sealed class MissionTimerTest
    {
        private Mock<IStopwatch> _stopwatch;
        private MissionTimer _missionTimer;


        [SetUp]
        public void Setup()
        {
            _stopwatch = new Mock<IStopwatch>();

            _missionTimer = new MissionTimer(_stopwatch.Object);
        }

        [Test]
        public void Should_indicate_when_the_mission_timer_is_running()
        {
            // GIVEN
            _stopwatch.Setup(mock => mock.IsRunning).Returns(true);

            // THEN
            Assert.That(_missionTimer.IsRunning, Is.True);
        }

        [Test]
        public void Should_indicate_when_the_mission_timer_is_not_running()
        {
            // GIVEN
            _stopwatch.Setup(mock => mock.IsRunning).Returns(false);

            // THEN
            Assert.That(_missionTimer.IsRunning, Is.False);
        }

        [Test]
        public void Should_start_the_mission_time_with_zero_seconds()
        {
            // WHEN
            _missionTimer.StartWithZeroSeconds();

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
            Assert.That(_missionTimer.GetElapsedSeconds(),
                Is.EqualTo(new Seconds(60L)));
        }
    }
}