using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using Starship.Flight.Segment;
using Starship.Flight.Segment.Config;
using Starship.Mission;
using Starship.Sensor;
using Starship.Utility.Timing.Units;

namespace StarshipUnitTests.Flight.Segment
{
    public sealed class FlightSegmentCommandersTest
    {
        private Mock<IFlightSegmentCommandersLoader> _flightSegmentCommandersLoader;

        private Mock<IFlightSegmentCommander> _flightSegmentCommanderA;
        private Mock<IFlightSegmentCommander> _flightSegmentCommanderB;
        private Mock<IFlightSegmentCommander> _flightSegmentCommanderC;
        private Mock<IFlightSegmentCommander> _flightSegmentCommanderD;

        private Mock<ISensorSuite> _sensorSuiteWithAltitude0;
        private Mock<ISensorSuite> _sensorSuiteWithAltitude1;
        private Mock<ISensorSuite> _sensorSuiteWithAltitude50;
        private Mock<ISensorSuite> _sensorSuiteWithAltitude100;


        [SetUp]
        public void Setup()
        {
            _flightSegmentCommandersLoader = new Mock<IFlightSegmentCommandersLoader>();

            _flightSegmentCommanderA = new Mock<IFlightSegmentCommander>();
            _flightSegmentCommanderB = new Mock<IFlightSegmentCommander>();
            _flightSegmentCommanderC = new Mock<IFlightSegmentCommander>();
            _flightSegmentCommanderD = new Mock<IFlightSegmentCommander>();

            _sensorSuiteWithAltitude0 = new Mock<ISensorSuite>();
            _sensorSuiteWithAltitude1 = new Mock<ISensorSuite>();
            _sensorSuiteWithAltitude50 = new Mock<ISensorSuite>();
            _sensorSuiteWithAltitude100 = new Mock<ISensorSuite>();
        }

        [Test]
        public void Should_get_the_current_flight_segment_commander_when_there_is_only_one()
        {
            // GIVEN
            _flightSegmentCommandersLoader.Setup(mock => mock.LoadFlightSegmentCommanders())
                .Returns(new List<IFlightSegmentCommander>
                {
                    _flightSegmentCommanderA.Object
                });

            var flightSegmentCommanders = CreateFlightSegmentCommanders();

            // THEN
            Assert.That(flightSegmentCommanders.GetCurrentFlightSegmentCommander(_sensorSuiteWithAltitude1.Object),
                Is.EqualTo(_flightSegmentCommanderA.Object));

            Assert.That(flightSegmentCommanders.GetCurrentFlightSegmentCommander(_sensorSuiteWithAltitude1.Object),
                Is.EqualTo(_flightSegmentCommanderA.Object));
        }

        [Test]
        public void Should_get_the_current_flight_segment_commander_when_there_are_many()
        {
            // GIVEN
            // TakeOverAltitude >= 0
            // TakeOverAltitude >= 100
            // TakeOverAltitude <= 50
            // TakeOverAltitude <= 1

            // alt 0
            // A true
            // B false
            // C true
            // D true
            _flightSegmentCommanderA.Setup(
                mock => mock.CanTakeover(_sensorSuiteWithAltitude0.Object)
            ).Returns(true);
            _flightSegmentCommanderB.Setup(
                mock => mock.CanTakeover(_sensorSuiteWithAltitude0.Object)
            ).Returns(false);
            _flightSegmentCommanderC.Setup(
                mock => mock.CanTakeover(_sensorSuiteWithAltitude0.Object)
            ).Returns(true);
            _flightSegmentCommanderD.Setup(
                mock => mock.CanTakeover(_sensorSuiteWithAltitude0.Object)
            ).Returns(true);

            // alt 100
            // A true
            // B true
            // C false
            // D false
            _flightSegmentCommanderA.Setup(
                mock => mock.CanTakeover(_sensorSuiteWithAltitude100.Object)
            ).Returns(true);
            _flightSegmentCommanderB.Setup(
                mock => mock.CanTakeover(_sensorSuiteWithAltitude100.Object)
            ).Returns(true);
            _flightSegmentCommanderC.Setup(
                mock => mock.CanTakeover(_sensorSuiteWithAltitude100.Object)
            ).Returns(false);
            _flightSegmentCommanderD.Setup(
                mock => mock.CanTakeover(_sensorSuiteWithAltitude100.Object)
            ).Returns(false);
            
            // alt 50
            // A true
            // B false
            // C true
            // D false
            _flightSegmentCommanderA.Setup(
                mock => mock.CanTakeover(_sensorSuiteWithAltitude50.Object)
            ).Returns(true);
            _flightSegmentCommanderB.Setup(
                mock => mock.CanTakeover(_sensorSuiteWithAltitude50.Object)
            ).Returns(false);
            _flightSegmentCommanderC.Setup(
                mock => mock.CanTakeover(_sensorSuiteWithAltitude50.Object)
            ).Returns(true);
            _flightSegmentCommanderD.Setup(
                mock => mock.CanTakeover(_sensorSuiteWithAltitude50.Object)
            ).Returns(false);
            
            // alt 1
            // A true
            // B false
            // C true
            // D true
            _flightSegmentCommanderA.Setup(
                mock => mock.CanTakeover(_sensorSuiteWithAltitude1.Object)
            ).Returns(true);
            _flightSegmentCommanderB.Setup(
                mock => mock.CanTakeover(_sensorSuiteWithAltitude1.Object)
            ).Returns(false);
            _flightSegmentCommanderC.Setup(
                mock => mock.CanTakeover(_sensorSuiteWithAltitude1.Object)
            ).Returns(true);
            _flightSegmentCommanderD.Setup(
                mock => mock.CanTakeover(_sensorSuiteWithAltitude1.Object)
            ).Returns(true);
            
            _flightSegmentCommandersLoader.Setup(mock => mock.LoadFlightSegmentCommanders())
                .Returns(new List<IFlightSegmentCommander>
                {
                    _flightSegmentCommanderA.Object,
                    _flightSegmentCommanderB.Object,
                    _flightSegmentCommanderC.Object,
                    _flightSegmentCommanderD.Object,
                });

            var flightSegmentCommanders = CreateFlightSegmentCommanders();

            // THEN
            
            // alt 0 -> A;
            // alt 0 -> A;
            // alt 100 -> B;
            // alt 100 -> B;
            // alt 50 -> C;
            // alt 50 -> C;
            // alt 1 -> D;
            // alt 1 -> D;
            
            // TakeoverCondition, muss nicht immer true sein!, die KANTE muss genau 1x true sein, dann Wechsel
            
            Assert.That(flightSegmentCommanders.GetCurrentFlightSegmentCommander(_sensorSuiteWithAltitude0.Object),
                Is.EqualTo(_flightSegmentCommanderA.Object));

            Assert.That(flightSegmentCommanders.GetCurrentFlightSegmentCommander(_sensorSuiteWithAltitude0.Object),
                Is.EqualTo(_flightSegmentCommanderA.Object));
            
            Assert.That(flightSegmentCommanders.GetCurrentFlightSegmentCommander(_sensorSuiteWithAltitude100.Object),
                Is.EqualTo(_flightSegmentCommanderB.Object));

            Assert.That(flightSegmentCommanders.GetCurrentFlightSegmentCommander(_sensorSuiteWithAltitude100.Object),
                Is.EqualTo(_flightSegmentCommanderB.Object));
            
            Assert.That(flightSegmentCommanders.GetCurrentFlightSegmentCommander(_sensorSuiteWithAltitude50.Object),
                Is.EqualTo(_flightSegmentCommanderC.Object));

            Assert.That(flightSegmentCommanders.GetCurrentFlightSegmentCommander(_sensorSuiteWithAltitude50.Object),
                Is.EqualTo(_flightSegmentCommanderC.Object));
            
            Assert.That(flightSegmentCommanders.GetCurrentFlightSegmentCommander(_sensorSuiteWithAltitude1.Object),
                Is.EqualTo(_flightSegmentCommanderD.Object));

            Assert.That(flightSegmentCommanders.GetCurrentFlightSegmentCommander(_sensorSuiteWithAltitude1.Object),
                Is.EqualTo(_flightSegmentCommanderD.Object));
        }

        // [Test]
        // public void Should_get_the_current_flight_segment_commander_when_there_are_many()
        // {
        //     // GIVEN
        //     _missionTimer.SetupSequence(mock => mock.GetElapsedSeconds())
        //         .Returns(new Seconds(0L))
        //         .Returns(new Seconds(1L))
        //         .Returns(new Seconds(15L))
        //         .Returns(new Seconds(16L))
        //         .Returns(new Seconds(30L))
        //         .Returns(new Seconds(31L));
        //
        //     _flightSegmentConfigsLoader.Setup(mock => mock.LoadFlightSegmentConfigs())
        //         .Returns(new List<IFlightSegmentConfig>
        //         {
        //             CreateFlightSegmentConfig(new Seconds(0L)),
        //             CreateFlightSegmentConfig(new Seconds(15L)),
        //             CreateFlightSegmentConfig(new Seconds(30L))
        //         });
        //
        //     var flightSegmentCommanders = CreateFlightSegmentCommanders();
        //
        //     // THEN
        //     Assert.That(flightSegmentCommanders.GetCurrentFlightSegmentCommander()
        //         .TakeoverSecondsInMission, Is.EqualTo(new Seconds(0L)));
        //
        //     Assert.That(flightSegmentCommanders.GetCurrentFlightSegmentCommander()
        //         .TakeoverSecondsInMission, Is.EqualTo(new Seconds(0L)));
        //
        //     Assert.That(flightSegmentCommanders.GetCurrentFlightSegmentCommander()
        //         .TakeoverSecondsInMission, Is.EqualTo(new Seconds(15L)));
        //
        //     Assert.That(flightSegmentCommanders.GetCurrentFlightSegmentCommander()
        //         .TakeoverSecondsInMission, Is.EqualTo(new Seconds(15L)));
        //
        //     Assert.That(flightSegmentCommanders.GetCurrentFlightSegmentCommander()
        //         .TakeoverSecondsInMission, Is.EqualTo(new Seconds(30L)));
        //
        //     Assert.That(flightSegmentCommanders.GetCurrentFlightSegmentCommander()
        //         .TakeoverSecondsInMission, Is.EqualTo(new Seconds(30L)));
        // }

        private FlightSegmentCommanders CreateFlightSegmentCommanders() =>
            new FlightSegmentCommanders(_flightSegmentCommandersLoader.Object);
    }
}