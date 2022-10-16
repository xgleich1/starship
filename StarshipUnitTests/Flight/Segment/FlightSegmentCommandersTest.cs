using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using Starship.Flight.Segment;
using Starship.Flight.Segment.Actuation.Engine;
using Starship.Flight.Segment.Actuation.Flap;
using Starship.Flight.Segment.Actuation.Leg;
using Starship.Flight.Segment.Config;
using Starship.Flight.Segment.Handover;
using Starship.Flight.Segment.Throttle.Main;
using Starship.Sensor;
using Starship.Sensor.Altitude;

namespace StarshipUnitTests.Flight.Segment
{
    public sealed class FlightSegmentCommandersTest
    {
        private Mock<IFlightSegmentConfigsLoader> _flightSegmentConfigsLoader;

        private Mock<IAltitudeSensor> _altitudeSensor;
        private Mock<ISensorSuite> _sensorSuite;


        [SetUp]
        public void Setup()
        {
            _flightSegmentConfigsLoader = new Mock<IFlightSegmentConfigsLoader>();

            _altitudeSensor = new Mock<IAltitudeSensor>();
            _sensorSuite = new Mock<ISensorSuite>();

            _sensorSuite.Setup(mock => mock.AltitudeSensor)
                .Returns(_altitudeSensor.Object);
        }

        [Test]
        public void Should_decide_the_current_flight_segment_commander_depending_on_the_handover_conditions()
        {
            // GIVEN
            var flightSegmentConfigWithHandoverAltitudeEqualOrOver100 =
                CreateFlightSegmentConfig(handoverAltitudeAboveTerrainInMetersEqualOrOver: 100.0F);
            var flightSegmentConfigWithHandoverAltitudeEqualOrOver200 =
                CreateFlightSegmentConfig(handoverAltitudeAboveTerrainInMetersEqualOrOver: 200.0F);
            var flightSegmentConfigWithHandoverAltitudeEqualOrOver300 =
                CreateFlightSegmentConfig(handoverAltitudeAboveTerrainInMetersEqualOrOver: 300.0F);

            _flightSegmentConfigsLoader.Setup(mock => mock.LoadFlightSegmentConfigs())
                .Returns(new List<FlightSegmentConfig>
                {
                    flightSegmentConfigWithHandoverAltitudeEqualOrOver100,
                    flightSegmentConfigWithHandoverAltitudeEqualOrOver200,
                    flightSegmentConfigWithHandoverAltitudeEqualOrOver300
                });

            _altitudeSensor.SetupSequence(mock => mock.AltitudeAboveTerrainInMeters)
                .Returns(0.0F)
                .Returns(50.0F)
                .Returns(100.0F)
                .Returns(150.0F)
                .Returns(200.0F);

            var flightSegmentCommanders = new FlightSegmentCommanders(_flightSegmentConfigsLoader.Object);

            // THEN
            Assert.That(flightSegmentCommanders.GetCurrentFlightSegmentCommander(_sensorSuite.Object),
                Is.EqualTo(CreateFlightSegmentCommander(flightSegmentConfigWithHandoverAltitudeEqualOrOver100)));

            Assert.That(flightSegmentCommanders.GetCurrentFlightSegmentCommander(_sensorSuite.Object),
                Is.EqualTo(CreateFlightSegmentCommander(flightSegmentConfigWithHandoverAltitudeEqualOrOver100)));

            Assert.That(flightSegmentCommanders.GetCurrentFlightSegmentCommander(_sensorSuite.Object),
                Is.EqualTo(CreateFlightSegmentCommander(flightSegmentConfigWithHandoverAltitudeEqualOrOver200)));

            Assert.That(flightSegmentCommanders.GetCurrentFlightSegmentCommander(_sensorSuite.Object),
                Is.EqualTo(CreateFlightSegmentCommander(flightSegmentConfigWithHandoverAltitudeEqualOrOver200)));

            Assert.That(flightSegmentCommanders.GetCurrentFlightSegmentCommander(_sensorSuite.Object),
                Is.EqualTo(CreateFlightSegmentCommander(flightSegmentConfigWithHandoverAltitudeEqualOrOver300)));
        }

        private static FlightSegmentConfig CreateFlightSegmentConfig(float? handoverAltitudeAboveTerrainInMetersEqualOrOver) =>
            new FlightSegmentConfig(
                null,
                null,
                null,
                null,
                null,
                null,
                handoverAltitudeAboveTerrainInMetersEqualOrOver,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                false,
                0,
                0,
                0,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null);

        private static FlightSegmentCommander CreateFlightSegmentCommander(FlightSegmentConfig flightSegmentConfig) =>
            new FlightSegmentCommander(
                new FlightSegmentHandoverDecider(flightSegmentConfig),
                new LegsActuationSegmentCommander(flightSegmentConfig),
                new FlapsActuationSegmentCommander(flightSegmentConfig),
                new MainEnginesGimbalSegmentCommander(flightSegmentConfig),
                new MainEnginesThrottleSegmentCommander(flightSegmentConfig));
    }
}