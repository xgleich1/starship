using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using Starship.Flight.Segment;
using Starship.Flight.Segment.Config;
using Starship.Mission;
using Starship.Utility.Timing.Units;

namespace StarshipUnitTests.Flight.Segment
{
    public sealed class FlightSegmentCommandersTest
    {
        private Mock<IMissionTimer> _missionTimer;
        private Mock<IFlightSegmentConfigsLoader> _flightSegmentConfigsLoader;


        [SetUp]
        public void Setup()
        {
            _missionTimer = new Mock<IMissionTimer>();
            _flightSegmentConfigsLoader = new Mock<IFlightSegmentConfigsLoader>();
        }

        [Test]
        public void Should_get_the_current_flight_segment_commander_when_there_is_only_one()
        {
            // GIVEN
            _missionTimer.SetupSequence(mock => mock.GetElapsedSeconds())
                .Returns(new Seconds(0L))
                .Returns(new Seconds(1L));

            _flightSegmentConfigsLoader.Setup(mock => mock.LoadFlightSegmentConfigs())
                .Returns(new List<FlightSegmentConfig>
                {
                    CreateFlightSegmentConfig(new Seconds(0L))
                });

            var flightSegmentCommanders = CreateFlightSegmentCommanders();

            // THEN
            Assert.That(flightSegmentCommanders.GetCurrentFlightSegmentCommander(),
                Is.EqualTo(new FlightSegmentCommander(CreateFlightSegmentConfig(new Seconds(0L)))));

            Assert.That(flightSegmentCommanders.GetCurrentFlightSegmentCommander(),
                Is.EqualTo(new FlightSegmentCommander(CreateFlightSegmentConfig(new Seconds(0L)))));
        }

        [Test]
        public void Should_get_the_current_flight_segment_commander_when_there_are_many()
        {
            // GIVEN
            _missionTimer.SetupSequence(mock => mock.GetElapsedSeconds())
                .Returns(new Seconds(0L))
                .Returns(new Seconds(1L))
                .Returns(new Seconds(15L))
                .Returns(new Seconds(16L))
                .Returns(new Seconds(30L))
                .Returns(new Seconds(31L));

            _flightSegmentConfigsLoader.Setup(mock => mock.LoadFlightSegmentConfigs())
                .Returns(new List<FlightSegmentConfig>
                {
                    CreateFlightSegmentConfig(new Seconds(0L)),
                    CreateFlightSegmentConfig(new Seconds(15L)),
                    CreateFlightSegmentConfig(new Seconds(30L))
                });

            var flightSegmentCommanders = CreateFlightSegmentCommanders();

            // THEN
            Assert.That(flightSegmentCommanders.GetCurrentFlightSegmentCommander(),
                Is.EqualTo(new FlightSegmentCommander(CreateFlightSegmentConfig(new Seconds(0L)))));

            Assert.That(flightSegmentCommanders.GetCurrentFlightSegmentCommander(),
                Is.EqualTo(new FlightSegmentCommander(CreateFlightSegmentConfig(new Seconds(0L)))));

            Assert.That(flightSegmentCommanders.GetCurrentFlightSegmentCommander(),
                Is.EqualTo(new FlightSegmentCommander(CreateFlightSegmentConfig(new Seconds(15L)))));

            Assert.That(flightSegmentCommanders.GetCurrentFlightSegmentCommander(),
                Is.EqualTo(new FlightSegmentCommander(CreateFlightSegmentConfig(new Seconds(15L)))));

            Assert.That(flightSegmentCommanders.GetCurrentFlightSegmentCommander(),
                Is.EqualTo(new FlightSegmentCommander(CreateFlightSegmentConfig(new Seconds(30L)))));

            Assert.That(flightSegmentCommanders.GetCurrentFlightSegmentCommander(),
                Is.EqualTo(new FlightSegmentCommander(CreateFlightSegmentConfig(new Seconds(30L)))));
        }

        private FlightSegmentCommanders CreateFlightSegmentCommanders() =>
            new FlightSegmentCommanders(_missionTimer.Object, _flightSegmentConfigsLoader.Object);

        private static FlightSegmentConfig CreateFlightSegmentConfig(Seconds takeoverSecondsInMission) =>
            new FlightSegmentConfig(
                takeoverSecondsInMission,
                null, null, null,
                0.0F, 0.0F, 0.0F,
                0.0F, 0.0F, 0.0F,
                null, null, null,
                0.0F, 0.0F, 0.0F,
                null, null, null, null);
    }
}