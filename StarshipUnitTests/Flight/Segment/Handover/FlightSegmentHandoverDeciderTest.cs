using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using Starship.Flight.Segment.Config;
using Starship.Flight.Segment.Handover;
using Starship.Sensor;
using Starship.Sensor.Altitude;
using Starship.Sensor.Attitude;
using Starship.Sensor.Velocity;
using Starship.Telemetry;

namespace StarshipUnitTests.Flight.Segment.Handover
{
    public sealed class FlightSegmentHandoverDeciderTest
    {
        private Mock<IAttitudeSensor> _attitudeSensor;
        private Mock<IAltitudeSensor> _altitudeSensor;
        private Mock<IVelocitySensor> _velocitySensor;

        private ISensorSuite _sensorSuite;


        [SetUp]
        public void Setup()
        {
            _attitudeSensor = new Mock<IAttitudeSensor>();
            _altitudeSensor = new Mock<IAltitudeSensor>();
            _velocitySensor = new Mock<IVelocitySensor>();

            _sensorSuite = new SensorSuite(
                _attitudeSensor.Object,
                _altitudeSensor.Object,
                _velocitySensor.Object);
        }

        [Test]
        public void Should_handover_when_the_yaw_angle_equal_or_over_equal_condition_is_reached()
        {
            // GIVEN
            _attitudeSensor.Setup(mock => mock.YawAngleInDegrees).Returns(0.0F);

            var decider = new FlightSegmentHandoverDecider(CreateFlightSegmentConfig(
                handoverYawAngleInDegreesEqualOrOver: 0.0F,
                handoverYawAngleInDegreesEqualOrUnder: null,
                handoverRollAngleInDegreesEqualOrOver: null,
                handoverRollAngleInDegreesEqualOrUnder: null,
                handoverPitchAngleInDegreesEqualOrOver: null,
                handoverPitchAngleInDegreesEqualOrUnder: null,
                handoverAltitudeAboveTerrainInMetersEqualOrOver: null,
                handoverAltitudeAboveTerrainInMetersEqualOrUnder: null,
                handoverLateralVelocityInMetrePerSecondEqualOrOver: null,
                handoverLateralVelocityInMetrePerSecondEqualOrUnder: null,
                handoverVerticalVelocityInMetrePerSecondEqualOrOver: null,
                handoverVerticalVelocityInMetrePerSecondEqualOrUnder: null,
                handoverHorizontalVelocityInMetrePerSecondEqualOrOver: null,
                handoverHorizontalVelocityInMetrePerSecondEqualOrUnder: null));

            // WHEN
            var canHandover = decider.CanHandover(_sensorSuite);

            // THEN
            Assert.That(canHandover, Is.True);
        }

        [Test]
        public void Should_handover_when_the_yaw_angle_equal_or_over_over_condition_is_reached()
        {
            // GIVEN
            _attitudeSensor.Setup(mock => mock.YawAngleInDegrees).Returns(0.1F);

            var decider = new FlightSegmentHandoverDecider(CreateFlightSegmentConfig(
                handoverYawAngleInDegreesEqualOrOver: 0.0F,
                handoverYawAngleInDegreesEqualOrUnder: null,
                handoverRollAngleInDegreesEqualOrOver: null,
                handoverRollAngleInDegreesEqualOrUnder: null,
                handoverPitchAngleInDegreesEqualOrOver: null,
                handoverPitchAngleInDegreesEqualOrUnder: null,
                handoverAltitudeAboveTerrainInMetersEqualOrOver: null,
                handoverAltitudeAboveTerrainInMetersEqualOrUnder: null,
                handoverLateralVelocityInMetrePerSecondEqualOrOver: null,
                handoverLateralVelocityInMetrePerSecondEqualOrUnder: null,
                handoverVerticalVelocityInMetrePerSecondEqualOrOver: null,
                handoverVerticalVelocityInMetrePerSecondEqualOrUnder: null,
                handoverHorizontalVelocityInMetrePerSecondEqualOrOver: null,
                handoverHorizontalVelocityInMetrePerSecondEqualOrUnder: null));

            // WHEN
            var canHandover = decider.CanHandover(_sensorSuite);

            // THEN
            Assert.That(canHandover, Is.True);
        }

        [Test]
        public void Should_handover_when_the_yaw_angle_equal_or_under_equal_condition_is_reached()
        {
            // GIVEN
            _attitudeSensor.Setup(mock => mock.YawAngleInDegrees).Returns(0.0F);

            var decider = new FlightSegmentHandoverDecider(CreateFlightSegmentConfig(
                handoverYawAngleInDegreesEqualOrOver: null,
                handoverYawAngleInDegreesEqualOrUnder: 0.0F,
                handoverRollAngleInDegreesEqualOrOver: null,
                handoverRollAngleInDegreesEqualOrUnder: null,
                handoverPitchAngleInDegreesEqualOrOver: null,
                handoverPitchAngleInDegreesEqualOrUnder: null,
                handoverAltitudeAboveTerrainInMetersEqualOrOver: null,
                handoverAltitudeAboveTerrainInMetersEqualOrUnder: null,
                handoverLateralVelocityInMetrePerSecondEqualOrOver: null,
                handoverLateralVelocityInMetrePerSecondEqualOrUnder: null,
                handoverVerticalVelocityInMetrePerSecondEqualOrOver: null,
                handoverVerticalVelocityInMetrePerSecondEqualOrUnder: null,
                handoverHorizontalVelocityInMetrePerSecondEqualOrOver: null,
                handoverHorizontalVelocityInMetrePerSecondEqualOrUnder: null));

            // WHEN
            var canHandover = decider.CanHandover(_sensorSuite);

            // THEN
            Assert.That(canHandover, Is.True);
        }

        [Test]
        public void Should_handover_when_the_yaw_angle_equal_or_under_under_condition_is_reached()
        {
            // GIVEN
            _attitudeSensor.Setup(mock => mock.YawAngleInDegrees).Returns(-0.1F);

            var decider = new FlightSegmentHandoverDecider(CreateFlightSegmentConfig(
                handoverYawAngleInDegreesEqualOrOver: null,
                handoverYawAngleInDegreesEqualOrUnder: 0.0F,
                handoverRollAngleInDegreesEqualOrOver: null,
                handoverRollAngleInDegreesEqualOrUnder: null,
                handoverPitchAngleInDegreesEqualOrOver: null,
                handoverPitchAngleInDegreesEqualOrUnder: null,
                handoverAltitudeAboveTerrainInMetersEqualOrOver: null,
                handoverAltitudeAboveTerrainInMetersEqualOrUnder: null,
                handoverLateralVelocityInMetrePerSecondEqualOrOver: null,
                handoverLateralVelocityInMetrePerSecondEqualOrUnder: null,
                handoverVerticalVelocityInMetrePerSecondEqualOrOver: null,
                handoverVerticalVelocityInMetrePerSecondEqualOrUnder: null,
                handoverHorizontalVelocityInMetrePerSecondEqualOrOver: null,
                handoverHorizontalVelocityInMetrePerSecondEqualOrUnder: null));

            // WHEN
            var canHandover = decider.CanHandover(_sensorSuite);

            // THEN
            Assert.That(canHandover, Is.True);
        }

        [Test]
        public void Should_handover_when_the_roll_angle_equal_or_over_equal_condition_is_reached()
        {
            // GIVEN
            _attitudeSensor.Setup(mock => mock.RollAngleInDegrees).Returns(0.0F);

            var decider = new FlightSegmentHandoverDecider(CreateFlightSegmentConfig(
                handoverYawAngleInDegreesEqualOrOver: null,
                handoverYawAngleInDegreesEqualOrUnder: null,
                handoverRollAngleInDegreesEqualOrOver: 0.0F,
                handoverRollAngleInDegreesEqualOrUnder: null,
                handoverPitchAngleInDegreesEqualOrOver: null,
                handoverPitchAngleInDegreesEqualOrUnder: null,
                handoverAltitudeAboveTerrainInMetersEqualOrOver: null,
                handoverAltitudeAboveTerrainInMetersEqualOrUnder: null,
                handoverLateralVelocityInMetrePerSecondEqualOrOver: null,
                handoverLateralVelocityInMetrePerSecondEqualOrUnder: null,
                handoverVerticalVelocityInMetrePerSecondEqualOrOver: null,
                handoverVerticalVelocityInMetrePerSecondEqualOrUnder: null,
                handoverHorizontalVelocityInMetrePerSecondEqualOrOver: null,
                handoverHorizontalVelocityInMetrePerSecondEqualOrUnder: null));

            // WHEN
            var canHandover = decider.CanHandover(_sensorSuite);

            // THEN
            Assert.That(canHandover, Is.True);
        }

        [Test]
        public void Should_handover_when_the_roll_angle_equal_or_over_over_condition_is_reached()
        {
            // GIVEN
            _attitudeSensor.Setup(mock => mock.RollAngleInDegrees).Returns(0.1F);

            var decider = new FlightSegmentHandoverDecider(CreateFlightSegmentConfig(
                handoverYawAngleInDegreesEqualOrOver: null,
                handoverYawAngleInDegreesEqualOrUnder: null,
                handoverRollAngleInDegreesEqualOrOver: 0.0F,
                handoverRollAngleInDegreesEqualOrUnder: null,
                handoverPitchAngleInDegreesEqualOrOver: null,
                handoverPitchAngleInDegreesEqualOrUnder: null,
                handoverAltitudeAboveTerrainInMetersEqualOrOver: null,
                handoverAltitudeAboveTerrainInMetersEqualOrUnder: null,
                handoverLateralVelocityInMetrePerSecondEqualOrOver: null,
                handoverLateralVelocityInMetrePerSecondEqualOrUnder: null,
                handoverVerticalVelocityInMetrePerSecondEqualOrOver: null,
                handoverVerticalVelocityInMetrePerSecondEqualOrUnder: null,
                handoverHorizontalVelocityInMetrePerSecondEqualOrOver: null,
                handoverHorizontalVelocityInMetrePerSecondEqualOrUnder: null));

            // WHEN
            var canHandover = decider.CanHandover(_sensorSuite);

            // THEN
            Assert.That(canHandover, Is.True);
        }

        [Test]
        public void Should_handover_when_the_roll_angle_equal_or_under_equal_condition_is_reached()
        {
            // GIVEN
            _attitudeSensor.Setup(mock => mock.RollAngleInDegrees).Returns(0.0F);

            var decider = new FlightSegmentHandoverDecider(CreateFlightSegmentConfig(
                handoverYawAngleInDegreesEqualOrOver: null,
                handoverYawAngleInDegreesEqualOrUnder: null,
                handoverRollAngleInDegreesEqualOrOver: null,
                handoverRollAngleInDegreesEqualOrUnder: 0.0F,
                handoverPitchAngleInDegreesEqualOrOver: null,
                handoverPitchAngleInDegreesEqualOrUnder: null,
                handoverAltitudeAboveTerrainInMetersEqualOrOver: null,
                handoverAltitudeAboveTerrainInMetersEqualOrUnder: null,
                handoverLateralVelocityInMetrePerSecondEqualOrOver: null,
                handoverLateralVelocityInMetrePerSecondEqualOrUnder: null,
                handoverVerticalVelocityInMetrePerSecondEqualOrOver: null,
                handoverVerticalVelocityInMetrePerSecondEqualOrUnder: null,
                handoverHorizontalVelocityInMetrePerSecondEqualOrOver: null,
                handoverHorizontalVelocityInMetrePerSecondEqualOrUnder: null));

            // WHEN
            var canHandover = decider.CanHandover(_sensorSuite);

            // THEN
            Assert.That(canHandover, Is.True);
        }

        [Test]
        public void Should_handover_when_the_roll_angle_equal_or_under_under_condition_is_reached()
        {
            // GIVEN
            _attitudeSensor.Setup(mock => mock.RollAngleInDegrees).Returns(-0.1F);

            var decider = new FlightSegmentHandoverDecider(CreateFlightSegmentConfig(
                handoverYawAngleInDegreesEqualOrOver: null,
                handoverYawAngleInDegreesEqualOrUnder: null,
                handoverRollAngleInDegreesEqualOrOver: null,
                handoverRollAngleInDegreesEqualOrUnder: 0.0F,
                handoverPitchAngleInDegreesEqualOrOver: null,
                handoverPitchAngleInDegreesEqualOrUnder: null,
                handoverAltitudeAboveTerrainInMetersEqualOrOver: null,
                handoverAltitudeAboveTerrainInMetersEqualOrUnder: null,
                handoverLateralVelocityInMetrePerSecondEqualOrOver: null,
                handoverLateralVelocityInMetrePerSecondEqualOrUnder: null,
                handoverVerticalVelocityInMetrePerSecondEqualOrOver: null,
                handoverVerticalVelocityInMetrePerSecondEqualOrUnder: null,
                handoverHorizontalVelocityInMetrePerSecondEqualOrOver: null,
                handoverHorizontalVelocityInMetrePerSecondEqualOrUnder: null));

            // WHEN
            var canHandover = decider.CanHandover(_sensorSuite);

            // THEN
            Assert.That(canHandover, Is.True);
        }

        [Test]
        public void Should_handover_when_the_pitch_angle_equal_or_over_equal_condition_is_reached()
        {
            // GIVEN
            _attitudeSensor.Setup(mock => mock.PitchAngleInDegrees).Returns(0.0F);

            var decider = new FlightSegmentHandoverDecider(CreateFlightSegmentConfig(
                handoverYawAngleInDegreesEqualOrOver: null,
                handoverYawAngleInDegreesEqualOrUnder: null,
                handoverRollAngleInDegreesEqualOrOver: null,
                handoverRollAngleInDegreesEqualOrUnder: null,
                handoverPitchAngleInDegreesEqualOrOver: 0.0F,
                handoverPitchAngleInDegreesEqualOrUnder: null,
                handoverAltitudeAboveTerrainInMetersEqualOrOver: null,
                handoverAltitudeAboveTerrainInMetersEqualOrUnder: null,
                handoverLateralVelocityInMetrePerSecondEqualOrOver: null,
                handoverLateralVelocityInMetrePerSecondEqualOrUnder: null,
                handoverVerticalVelocityInMetrePerSecondEqualOrOver: null,
                handoverVerticalVelocityInMetrePerSecondEqualOrUnder: null,
                handoverHorizontalVelocityInMetrePerSecondEqualOrOver: null,
                handoverHorizontalVelocityInMetrePerSecondEqualOrUnder: null));

            // WHEN
            var canHandover = decider.CanHandover(_sensorSuite);

            // THEN
            Assert.That(canHandover, Is.True);
        }

        [Test]
        public void Should_handover_when_the_pitch_angle_equal_or_over_over_condition_is_reached()
        {
            // GIVEN
            _attitudeSensor.Setup(mock => mock.PitchAngleInDegrees).Returns(0.1F);

            var decider = new FlightSegmentHandoverDecider(CreateFlightSegmentConfig(
                handoverYawAngleInDegreesEqualOrOver: null,
                handoverYawAngleInDegreesEqualOrUnder: null,
                handoverRollAngleInDegreesEqualOrOver: null,
                handoverRollAngleInDegreesEqualOrUnder: null,
                handoverPitchAngleInDegreesEqualOrOver: 0.0F,
                handoverPitchAngleInDegreesEqualOrUnder: null,
                handoverAltitudeAboveTerrainInMetersEqualOrOver: null,
                handoverAltitudeAboveTerrainInMetersEqualOrUnder: null,
                handoverLateralVelocityInMetrePerSecondEqualOrOver: null,
                handoverLateralVelocityInMetrePerSecondEqualOrUnder: null,
                handoverVerticalVelocityInMetrePerSecondEqualOrOver: null,
                handoverVerticalVelocityInMetrePerSecondEqualOrUnder: null,
                handoverHorizontalVelocityInMetrePerSecondEqualOrOver: null,
                handoverHorizontalVelocityInMetrePerSecondEqualOrUnder: null));

            // WHEN
            var canHandover = decider.CanHandover(_sensorSuite);

            // THEN
            Assert.That(canHandover, Is.True);
        }

        [Test]
        public void Should_handover_when_the_pitch_angle_equal_or_under_equal_condition_is_reached()
        {
            // GIVEN
            _attitudeSensor.Setup(mock => mock.PitchAngleInDegrees).Returns(0.0F);

            var decider = new FlightSegmentHandoverDecider(CreateFlightSegmentConfig(
                handoverYawAngleInDegreesEqualOrOver: null,
                handoverYawAngleInDegreesEqualOrUnder: null,
                handoverRollAngleInDegreesEqualOrOver: null,
                handoverRollAngleInDegreesEqualOrUnder: null,
                handoverPitchAngleInDegreesEqualOrOver: null,
                handoverPitchAngleInDegreesEqualOrUnder: 0.0F,
                handoverAltitudeAboveTerrainInMetersEqualOrOver: null,
                handoverAltitudeAboveTerrainInMetersEqualOrUnder: null,
                handoverLateralVelocityInMetrePerSecondEqualOrOver: null,
                handoverLateralVelocityInMetrePerSecondEqualOrUnder: null,
                handoverVerticalVelocityInMetrePerSecondEqualOrOver: null,
                handoverVerticalVelocityInMetrePerSecondEqualOrUnder: null,
                handoverHorizontalVelocityInMetrePerSecondEqualOrOver: null,
                handoverHorizontalVelocityInMetrePerSecondEqualOrUnder: null));

            // WHEN
            var canHandover = decider.CanHandover(_sensorSuite);

            // THEN
            Assert.That(canHandover, Is.True);
        }

        [Test]
        public void Should_handover_when_the_pitch_angle_equal_or_under_under_condition_is_reached()
        {
            // GIVEN
            _attitudeSensor.Setup(mock => mock.PitchAngleInDegrees).Returns(-0.1F);

            var decider = new FlightSegmentHandoverDecider(CreateFlightSegmentConfig(
                handoverYawAngleInDegreesEqualOrOver: null,
                handoverYawAngleInDegreesEqualOrUnder: null,
                handoverRollAngleInDegreesEqualOrOver: null,
                handoverRollAngleInDegreesEqualOrUnder: null,
                handoverPitchAngleInDegreesEqualOrOver: null,
                handoverPitchAngleInDegreesEqualOrUnder: 0.0F,
                handoverAltitudeAboveTerrainInMetersEqualOrOver: null,
                handoverAltitudeAboveTerrainInMetersEqualOrUnder: null,
                handoverLateralVelocityInMetrePerSecondEqualOrOver: null,
                handoverLateralVelocityInMetrePerSecondEqualOrUnder: null,
                handoverVerticalVelocityInMetrePerSecondEqualOrOver: null,
                handoverVerticalVelocityInMetrePerSecondEqualOrUnder: null,
                handoverHorizontalVelocityInMetrePerSecondEqualOrOver: null,
                handoverHorizontalVelocityInMetrePerSecondEqualOrUnder: null));

            // WHEN
            var canHandover = decider.CanHandover(_sensorSuite);

            // THEN
            Assert.That(canHandover, Is.True);
        }

        [Test]
        public void Should_handover_when_the_altitude_equal_or_over_equal_condition_is_reached()
        {
            // GIVEN
            _altitudeSensor.Setup(mock => mock.AltitudeAboveTerrainInMeters).Returns(0.0F);

            var decider = new FlightSegmentHandoverDecider(CreateFlightSegmentConfig(
                handoverYawAngleInDegreesEqualOrOver: null,
                handoverYawAngleInDegreesEqualOrUnder: null,
                handoverRollAngleInDegreesEqualOrOver: null,
                handoverRollAngleInDegreesEqualOrUnder: null,
                handoverPitchAngleInDegreesEqualOrOver: null,
                handoverPitchAngleInDegreesEqualOrUnder: null,
                handoverAltitudeAboveTerrainInMetersEqualOrOver: 0.0F,
                handoverAltitudeAboveTerrainInMetersEqualOrUnder: null,
                handoverLateralVelocityInMetrePerSecondEqualOrOver: null,
                handoverLateralVelocityInMetrePerSecondEqualOrUnder: null,
                handoverVerticalVelocityInMetrePerSecondEqualOrOver: null,
                handoverVerticalVelocityInMetrePerSecondEqualOrUnder: null,
                handoverHorizontalVelocityInMetrePerSecondEqualOrOver: null,
                handoverHorizontalVelocityInMetrePerSecondEqualOrUnder: null));

            // WHEN
            var canHandover = decider.CanHandover(_sensorSuite);

            // THEN
            Assert.That(canHandover, Is.True);
        }

        [Test]
        public void Should_handover_when_the_altitude_equal_or_over_over_condition_is_reached()
        {
            // GIVEN
            _altitudeSensor.Setup(mock => mock.AltitudeAboveTerrainInMeters).Returns(0.1F);

            var decider = new FlightSegmentHandoverDecider(CreateFlightSegmentConfig(
                handoverYawAngleInDegreesEqualOrOver: null,
                handoverYawAngleInDegreesEqualOrUnder: null,
                handoverRollAngleInDegreesEqualOrOver: null,
                handoverRollAngleInDegreesEqualOrUnder: null,
                handoverPitchAngleInDegreesEqualOrOver: null,
                handoverPitchAngleInDegreesEqualOrUnder: null,
                handoverAltitudeAboveTerrainInMetersEqualOrOver: 0.0F,
                handoverAltitudeAboveTerrainInMetersEqualOrUnder: null,
                handoverLateralVelocityInMetrePerSecondEqualOrOver: null,
                handoverLateralVelocityInMetrePerSecondEqualOrUnder: null,
                handoverVerticalVelocityInMetrePerSecondEqualOrOver: null,
                handoverVerticalVelocityInMetrePerSecondEqualOrUnder: null,
                handoverHorizontalVelocityInMetrePerSecondEqualOrOver: null,
                handoverHorizontalVelocityInMetrePerSecondEqualOrUnder: null));

            // WHEN
            var canHandover = decider.CanHandover(_sensorSuite);

            // THEN
            Assert.That(canHandover, Is.True);
        }

        [Test]
        public void Should_handover_when_the_altitude_equal_or_under_equal_condition_is_reached()
        {
            // GIVEN
            _altitudeSensor.Setup(mock => mock.AltitudeAboveTerrainInMeters).Returns(1.0F);

            var decider = new FlightSegmentHandoverDecider(CreateFlightSegmentConfig(
                handoverYawAngleInDegreesEqualOrOver: null,
                handoverYawAngleInDegreesEqualOrUnder: null,
                handoverRollAngleInDegreesEqualOrOver: null,
                handoverRollAngleInDegreesEqualOrUnder: null,
                handoverPitchAngleInDegreesEqualOrOver: null,
                handoverPitchAngleInDegreesEqualOrUnder: null,
                handoverAltitudeAboveTerrainInMetersEqualOrOver: null,
                handoverAltitudeAboveTerrainInMetersEqualOrUnder: 1.0F,
                handoverLateralVelocityInMetrePerSecondEqualOrOver: null,
                handoverLateralVelocityInMetrePerSecondEqualOrUnder: null,
                handoverVerticalVelocityInMetrePerSecondEqualOrOver: null,
                handoverVerticalVelocityInMetrePerSecondEqualOrUnder: null,
                handoverHorizontalVelocityInMetrePerSecondEqualOrOver: null,
                handoverHorizontalVelocityInMetrePerSecondEqualOrUnder: null));

            // WHEN
            var canHandover = decider.CanHandover(_sensorSuite);

            // THEN
            Assert.That(canHandover, Is.True);
        }

        [Test]
        public void Should_handover_when_the_altitude_equal_or_under_under_condition_is_reached()
        {
            // GIVEN
            _altitudeSensor.Setup(mock => mock.AltitudeAboveTerrainInMeters).Returns(0.9F);

            var decider = new FlightSegmentHandoverDecider(CreateFlightSegmentConfig(
                handoverYawAngleInDegreesEqualOrOver: null,
                handoverYawAngleInDegreesEqualOrUnder: null,
                handoverRollAngleInDegreesEqualOrOver: null,
                handoverRollAngleInDegreesEqualOrUnder: null,
                handoverPitchAngleInDegreesEqualOrOver: null,
                handoverPitchAngleInDegreesEqualOrUnder: null,
                handoverAltitudeAboveTerrainInMetersEqualOrOver: null,
                handoverAltitudeAboveTerrainInMetersEqualOrUnder: 1.0F,
                handoverLateralVelocityInMetrePerSecondEqualOrOver: null,
                handoverLateralVelocityInMetrePerSecondEqualOrUnder: null,
                handoverVerticalVelocityInMetrePerSecondEqualOrOver: null,
                handoverVerticalVelocityInMetrePerSecondEqualOrUnder: null,
                handoverHorizontalVelocityInMetrePerSecondEqualOrOver: null,
                handoverHorizontalVelocityInMetrePerSecondEqualOrUnder: null));

            // WHEN
            var canHandover = decider.CanHandover(_sensorSuite);

            // THEN
            Assert.That(canHandover, Is.True);
        }

        [Test]
        public void Should_handover_when_the_lateral_velocity_equal_or_over_equal_condition_is_reached()
        {
            // GIVEN
            _velocitySensor.Setup(mock => mock.LateralVelocityInMetrePerSecond).Returns(0.0F);

            var decider = new FlightSegmentHandoverDecider(CreateFlightSegmentConfig(
                handoverYawAngleInDegreesEqualOrOver: null,
                handoverYawAngleInDegreesEqualOrUnder: null,
                handoverRollAngleInDegreesEqualOrOver: null,
                handoverRollAngleInDegreesEqualOrUnder: null,
                handoverPitchAngleInDegreesEqualOrOver: null,
                handoverPitchAngleInDegreesEqualOrUnder: null,
                handoverAltitudeAboveTerrainInMetersEqualOrOver: null,
                handoverAltitudeAboveTerrainInMetersEqualOrUnder: null,
                handoverLateralVelocityInMetrePerSecondEqualOrOver: 0.0F,
                handoverLateralVelocityInMetrePerSecondEqualOrUnder: null,
                handoverVerticalVelocityInMetrePerSecondEqualOrOver: null,
                handoverVerticalVelocityInMetrePerSecondEqualOrUnder: null,
                handoverHorizontalVelocityInMetrePerSecondEqualOrOver: null,
                handoverHorizontalVelocityInMetrePerSecondEqualOrUnder: null));

            // WHEN
            var canHandover = decider.CanHandover(_sensorSuite);

            // THEN
            Assert.That(canHandover, Is.True);
        }

        [Test]
        public void Should_handover_when_the_lateral_velocity_equal_or_over_over_condition_is_reached()
        {
            // GIVEN
            _velocitySensor.Setup(mock => mock.LateralVelocityInMetrePerSecond).Returns(0.1F);

            var decider = new FlightSegmentHandoverDecider(CreateFlightSegmentConfig(
                handoverYawAngleInDegreesEqualOrOver: null,
                handoverYawAngleInDegreesEqualOrUnder: null,
                handoverRollAngleInDegreesEqualOrOver: null,
                handoverRollAngleInDegreesEqualOrUnder: null,
                handoverPitchAngleInDegreesEqualOrOver: null,
                handoverPitchAngleInDegreesEqualOrUnder: null,
                handoverAltitudeAboveTerrainInMetersEqualOrOver: null,
                handoverAltitudeAboveTerrainInMetersEqualOrUnder: null,
                handoverLateralVelocityInMetrePerSecondEqualOrOver: 0.0F,
                handoverLateralVelocityInMetrePerSecondEqualOrUnder: null,
                handoverVerticalVelocityInMetrePerSecondEqualOrOver: null,
                handoverVerticalVelocityInMetrePerSecondEqualOrUnder: null,
                handoverHorizontalVelocityInMetrePerSecondEqualOrOver: null,
                handoverHorizontalVelocityInMetrePerSecondEqualOrUnder: null));

            // WHEN
            var canHandover = decider.CanHandover(_sensorSuite);

            // THEN
            Assert.That(canHandover, Is.True);
        }

        [Test]
        public void Should_handover_when_the_lateral_velocity_equal_or_under_equal_condition_is_reached()
        {
            // GIVEN
            _velocitySensor.Setup(mock => mock.LateralVelocityInMetrePerSecond).Returns(0.0F);

            var decider = new FlightSegmentHandoverDecider(CreateFlightSegmentConfig(
                handoverYawAngleInDegreesEqualOrOver: null,
                handoverYawAngleInDegreesEqualOrUnder: null,
                handoverRollAngleInDegreesEqualOrOver: null,
                handoverRollAngleInDegreesEqualOrUnder: null,
                handoverPitchAngleInDegreesEqualOrOver: null,
                handoverPitchAngleInDegreesEqualOrUnder: null,
                handoverAltitudeAboveTerrainInMetersEqualOrOver: null,
                handoverAltitudeAboveTerrainInMetersEqualOrUnder: null,
                handoverLateralVelocityInMetrePerSecondEqualOrOver: null,
                handoverLateralVelocityInMetrePerSecondEqualOrUnder: 0.0F,
                handoverVerticalVelocityInMetrePerSecondEqualOrOver: null,
                handoverVerticalVelocityInMetrePerSecondEqualOrUnder: null,
                handoverHorizontalVelocityInMetrePerSecondEqualOrOver: null,
                handoverHorizontalVelocityInMetrePerSecondEqualOrUnder: null));

            // WHEN
            var canHandover = decider.CanHandover(_sensorSuite);

            // THEN
            Assert.That(canHandover, Is.True);
        }

        [Test]
        public void Should_handover_when_the_lateral_velocity_equal_or_under_under_condition_is_reached()
        {
            // GIVEN
            _velocitySensor.Setup(mock => mock.LateralVelocityInMetrePerSecond).Returns(-0.1F);

            var decider = new FlightSegmentHandoverDecider(CreateFlightSegmentConfig(
                handoverYawAngleInDegreesEqualOrOver: null,
                handoverYawAngleInDegreesEqualOrUnder: null,
                handoverRollAngleInDegreesEqualOrOver: null,
                handoverRollAngleInDegreesEqualOrUnder: null,
                handoverPitchAngleInDegreesEqualOrOver: null,
                handoverPitchAngleInDegreesEqualOrUnder: null,
                handoverAltitudeAboveTerrainInMetersEqualOrOver: null,
                handoverAltitudeAboveTerrainInMetersEqualOrUnder: null,
                handoverLateralVelocityInMetrePerSecondEqualOrOver: null,
                handoverLateralVelocityInMetrePerSecondEqualOrUnder: 0.0F,
                handoverVerticalVelocityInMetrePerSecondEqualOrOver: null,
                handoverVerticalVelocityInMetrePerSecondEqualOrUnder: null,
                handoverHorizontalVelocityInMetrePerSecondEqualOrOver: null,
                handoverHorizontalVelocityInMetrePerSecondEqualOrUnder: null));

            // WHEN
            var canHandover = decider.CanHandover(_sensorSuite);

            // THEN
            Assert.That(canHandover, Is.True);
        }

        [Test]
        public void Should_handover_when_the_vertical_velocity_equal_or_over_equal_condition_is_reached()
        {
            // GIVEN
            _velocitySensor.Setup(mock => mock.VerticalVelocityInMetrePerSecond).Returns(0.0F);

            var decider = new FlightSegmentHandoverDecider(CreateFlightSegmentConfig(
                handoverYawAngleInDegreesEqualOrOver: null,
                handoverYawAngleInDegreesEqualOrUnder: null,
                handoverRollAngleInDegreesEqualOrOver: null,
                handoverRollAngleInDegreesEqualOrUnder: null,
                handoverPitchAngleInDegreesEqualOrOver: null,
                handoverPitchAngleInDegreesEqualOrUnder: null,
                handoverAltitudeAboveTerrainInMetersEqualOrOver: null,
                handoverAltitudeAboveTerrainInMetersEqualOrUnder: null,
                handoverLateralVelocityInMetrePerSecondEqualOrOver: null,
                handoverLateralVelocityInMetrePerSecondEqualOrUnder: null,
                handoverVerticalVelocityInMetrePerSecondEqualOrOver: 0.0F,
                handoverVerticalVelocityInMetrePerSecondEqualOrUnder: null,
                handoverHorizontalVelocityInMetrePerSecondEqualOrOver: null,
                handoverHorizontalVelocityInMetrePerSecondEqualOrUnder: null));

            // WHEN
            var canHandover = decider.CanHandover(_sensorSuite);

            // THEN
            Assert.That(canHandover, Is.True);
        }

        [Test]
        public void Should_handover_when_the_vertical_velocity_equal_or_over_over_condition_is_reached()
        {
            // GIVEN
            _velocitySensor.Setup(mock => mock.VerticalVelocityInMetrePerSecond).Returns(0.1F);

            var decider = new FlightSegmentHandoverDecider(CreateFlightSegmentConfig(
                handoverYawAngleInDegreesEqualOrOver: null,
                handoverYawAngleInDegreesEqualOrUnder: null,
                handoverRollAngleInDegreesEqualOrOver: null,
                handoverRollAngleInDegreesEqualOrUnder: null,
                handoverPitchAngleInDegreesEqualOrOver: null,
                handoverPitchAngleInDegreesEqualOrUnder: null,
                handoverAltitudeAboveTerrainInMetersEqualOrOver: null,
                handoverAltitudeAboveTerrainInMetersEqualOrUnder: null,
                handoverLateralVelocityInMetrePerSecondEqualOrOver: null,
                handoverLateralVelocityInMetrePerSecondEqualOrUnder: null,
                handoverVerticalVelocityInMetrePerSecondEqualOrOver: 0.0F,
                handoverVerticalVelocityInMetrePerSecondEqualOrUnder: null,
                handoverHorizontalVelocityInMetrePerSecondEqualOrOver: null,
                handoverHorizontalVelocityInMetrePerSecondEqualOrUnder: null));

            // WHEN
            var canHandover = decider.CanHandover(_sensorSuite);

            // THEN
            Assert.That(canHandover, Is.True);
        }

        [Test]
        public void Should_handover_when_the_vertical_velocity_equal_or_under_equal_condition_is_reached()
        {
            // GIVEN
            _velocitySensor.Setup(mock => mock.VerticalVelocityInMetrePerSecond).Returns(0.0F);

            var decider = new FlightSegmentHandoverDecider(CreateFlightSegmentConfig(
                handoverYawAngleInDegreesEqualOrOver: null,
                handoverYawAngleInDegreesEqualOrUnder: null,
                handoverRollAngleInDegreesEqualOrOver: null,
                handoverRollAngleInDegreesEqualOrUnder: null,
                handoverPitchAngleInDegreesEqualOrOver: null,
                handoverPitchAngleInDegreesEqualOrUnder: null,
                handoverAltitudeAboveTerrainInMetersEqualOrOver: null,
                handoverAltitudeAboveTerrainInMetersEqualOrUnder: null,
                handoverLateralVelocityInMetrePerSecondEqualOrOver: null,
                handoverLateralVelocityInMetrePerSecondEqualOrUnder: null,
                handoverVerticalVelocityInMetrePerSecondEqualOrOver: null,
                handoverVerticalVelocityInMetrePerSecondEqualOrUnder: 0.0F,
                handoverHorizontalVelocityInMetrePerSecondEqualOrOver: null,
                handoverHorizontalVelocityInMetrePerSecondEqualOrUnder: null));

            // WHEN
            var canHandover = decider.CanHandover(_sensorSuite);

            // THEN
            Assert.That(canHandover, Is.True);
        }

        [Test]
        public void Should_handover_when_the_vertical_velocity_equal_or_under_under_condition_is_reached()
        {
            // GIVEN
            _velocitySensor.Setup(mock => mock.LateralVelocityInMetrePerSecond).Returns(-0.1F);

            var decider = new FlightSegmentHandoverDecider(CreateFlightSegmentConfig(
                handoverYawAngleInDegreesEqualOrOver: null,
                handoverYawAngleInDegreesEqualOrUnder: null,
                handoverRollAngleInDegreesEqualOrOver: null,
                handoverRollAngleInDegreesEqualOrUnder: null,
                handoverPitchAngleInDegreesEqualOrOver: null,
                handoverPitchAngleInDegreesEqualOrUnder: null,
                handoverAltitudeAboveTerrainInMetersEqualOrOver: null,
                handoverAltitudeAboveTerrainInMetersEqualOrUnder: null,
                handoverLateralVelocityInMetrePerSecondEqualOrOver: null,
                handoverLateralVelocityInMetrePerSecondEqualOrUnder: null,
                handoverVerticalVelocityInMetrePerSecondEqualOrOver: null,
                handoverVerticalVelocityInMetrePerSecondEqualOrUnder: 0.0F,
                handoverHorizontalVelocityInMetrePerSecondEqualOrOver: null,
                handoverHorizontalVelocityInMetrePerSecondEqualOrUnder: null));

            // WHEN
            var canHandover = decider.CanHandover(_sensorSuite);

            // THEN
            Assert.That(canHandover, Is.True);
        }

        [Test]
        public void Should_handover_when_the_horizontal_velocity_equal_or_over_equal_condition_is_reached()
        {
            // GIVEN
            _velocitySensor.Setup(mock => mock.HorizontalVelocityInMetrePerSecond).Returns(0.0F);

            var decider = new FlightSegmentHandoverDecider(CreateFlightSegmentConfig(
                handoverYawAngleInDegreesEqualOrOver: null,
                handoverYawAngleInDegreesEqualOrUnder: null,
                handoverRollAngleInDegreesEqualOrOver: null,
                handoverRollAngleInDegreesEqualOrUnder: null,
                handoverPitchAngleInDegreesEqualOrOver: null,
                handoverPitchAngleInDegreesEqualOrUnder: null,
                handoverAltitudeAboveTerrainInMetersEqualOrOver: null,
                handoverAltitudeAboveTerrainInMetersEqualOrUnder: null,
                handoverLateralVelocityInMetrePerSecondEqualOrOver: null,
                handoverLateralVelocityInMetrePerSecondEqualOrUnder: null,
                handoverVerticalVelocityInMetrePerSecondEqualOrOver: null,
                handoverVerticalVelocityInMetrePerSecondEqualOrUnder: null,
                handoverHorizontalVelocityInMetrePerSecondEqualOrOver: 0.0F,
                handoverHorizontalVelocityInMetrePerSecondEqualOrUnder: null));

            // WHEN
            var canHandover = decider.CanHandover(_sensorSuite);

            // THEN
            Assert.That(canHandover, Is.True);
        }

        [Test]
        public void Should_handover_when_the_horizontal_velocity_equal_or_over_over_condition_is_reached()
        {
            // GIVEN
            _velocitySensor.Setup(mock => mock.HorizontalVelocityInMetrePerSecond).Returns(0.1F);

            var decider = new FlightSegmentHandoverDecider(CreateFlightSegmentConfig(
                handoverYawAngleInDegreesEqualOrOver: null,
                handoverYawAngleInDegreesEqualOrUnder: null,
                handoverRollAngleInDegreesEqualOrOver: null,
                handoverRollAngleInDegreesEqualOrUnder: null,
                handoverPitchAngleInDegreesEqualOrOver: null,
                handoverPitchAngleInDegreesEqualOrUnder: null,
                handoverAltitudeAboveTerrainInMetersEqualOrOver: null,
                handoverAltitudeAboveTerrainInMetersEqualOrUnder: null,
                handoverLateralVelocityInMetrePerSecondEqualOrOver: null,
                handoverLateralVelocityInMetrePerSecondEqualOrUnder: null,
                handoverVerticalVelocityInMetrePerSecondEqualOrOver: null,
                handoverVerticalVelocityInMetrePerSecondEqualOrUnder: null,
                handoverHorizontalVelocityInMetrePerSecondEqualOrOver: 0.0F,
                handoverHorizontalVelocityInMetrePerSecondEqualOrUnder: null));

            // WHEN
            var canHandover = decider.CanHandover(_sensorSuite);

            // THEN
            Assert.That(canHandover, Is.True);
        }

        [Test]
        public void Should_handover_when_the_horizontal_velocity_equal_or_under_equal_condition_is_reached()
        {
            // GIVEN
            _velocitySensor.Setup(mock => mock.HorizontalVelocityInMetrePerSecond).Returns(0.0F);

            var decider = new FlightSegmentHandoverDecider(CreateFlightSegmentConfig(
                handoverYawAngleInDegreesEqualOrOver: null,
                handoverYawAngleInDegreesEqualOrUnder: null,
                handoverRollAngleInDegreesEqualOrOver: null,
                handoverRollAngleInDegreesEqualOrUnder: null,
                handoverPitchAngleInDegreesEqualOrOver: null,
                handoverPitchAngleInDegreesEqualOrUnder: null,
                handoverAltitudeAboveTerrainInMetersEqualOrOver: null,
                handoverAltitudeAboveTerrainInMetersEqualOrUnder: null,
                handoverLateralVelocityInMetrePerSecondEqualOrOver: null,
                handoverLateralVelocityInMetrePerSecondEqualOrUnder: null,
                handoverVerticalVelocityInMetrePerSecondEqualOrOver: null,
                handoverVerticalVelocityInMetrePerSecondEqualOrUnder: null,
                handoverHorizontalVelocityInMetrePerSecondEqualOrOver: null,
                handoverHorizontalVelocityInMetrePerSecondEqualOrUnder: 0.0F));

            // WHEN
            var canHandover = decider.CanHandover(_sensorSuite);

            // THEN
            Assert.That(canHandover, Is.True);
        }

        [Test]
        public void Should_handover_when_the_horizontal_velocity_equal_or_under_under_condition_is_reached()
        {
            // GIVEN
            _velocitySensor.Setup(mock => mock.HorizontalVelocityInMetrePerSecond).Returns(-0.1F);

            var decider = new FlightSegmentHandoverDecider(CreateFlightSegmentConfig(
                handoverYawAngleInDegreesEqualOrOver: null,
                handoverYawAngleInDegreesEqualOrUnder: null,
                handoverRollAngleInDegreesEqualOrOver: null,
                handoverRollAngleInDegreesEqualOrUnder: null,
                handoverPitchAngleInDegreesEqualOrOver: null,
                handoverPitchAngleInDegreesEqualOrUnder: null,
                handoverAltitudeAboveTerrainInMetersEqualOrOver: null,
                handoverAltitudeAboveTerrainInMetersEqualOrUnder: null,
                handoverLateralVelocityInMetrePerSecondEqualOrOver: null,
                handoverLateralVelocityInMetrePerSecondEqualOrUnder: null,
                handoverVerticalVelocityInMetrePerSecondEqualOrOver: null,
                handoverVerticalVelocityInMetrePerSecondEqualOrUnder: null,
                handoverHorizontalVelocityInMetrePerSecondEqualOrOver: null,
                handoverHorizontalVelocityInMetrePerSecondEqualOrUnder: 0.0F));

            // WHEN
            var canHandover = decider.CanHandover(_sensorSuite);

            // THEN
            Assert.That(canHandover, Is.True);
        }

        [Test]
        public void Should_handover_when_multiple_handover_conditions_are_reached()
        {
            // GIVEN
            _attitudeSensor.Setup(mock => mock.YawAngleInDegrees).Returns(0.0F);
            _velocitySensor.Setup(mock => mock.HorizontalVelocityInMetrePerSecond).Returns(0.0F);

            var decider = new FlightSegmentHandoverDecider(CreateFlightSegmentConfig(
                handoverYawAngleInDegreesEqualOrOver: 0.0F,
                handoverYawAngleInDegreesEqualOrUnder: null,
                handoverRollAngleInDegreesEqualOrOver: null,
                handoverRollAngleInDegreesEqualOrUnder: null,
                handoverPitchAngleInDegreesEqualOrOver: null,
                handoverPitchAngleInDegreesEqualOrUnder: null,
                handoverAltitudeAboveTerrainInMetersEqualOrOver: null,
                handoverAltitudeAboveTerrainInMetersEqualOrUnder: null,
                handoverLateralVelocityInMetrePerSecondEqualOrOver: null,
                handoverLateralVelocityInMetrePerSecondEqualOrUnder: null,
                handoverVerticalVelocityInMetrePerSecondEqualOrOver: null,
                handoverVerticalVelocityInMetrePerSecondEqualOrUnder: null,
                handoverHorizontalVelocityInMetrePerSecondEqualOrOver: null,
                handoverHorizontalVelocityInMetrePerSecondEqualOrUnder: 0.0F));

            // WHEN
            var canHandover = decider.CanHandover(_sensorSuite);

            // THEN
            Assert.That(canHandover, Is.True);
        }

        [Test]
        public void Should_not_handover_when_no_handover_condition_is_reached()
        {
            // GIVEN
            _attitudeSensor.Setup(mock => mock.YawAngleInDegrees).Returns(0.0F);
            _attitudeSensor.Setup(mock => mock.RollAngleInDegrees).Returns(0.0F);
            _attitudeSensor.Setup(mock => mock.PitchAngleInDegrees).Returns(0.0F);
            _altitudeSensor.Setup(mock => mock.AltitudeAboveTerrainInMeters).Returns(0.5F);
            _velocitySensor.Setup(mock => mock.LateralVelocityInMetrePerSecond).Returns(0.0F);
            _velocitySensor.Setup(mock => mock.VerticalVelocityInMetrePerSecond).Returns(0.0F);
            _velocitySensor.Setup(mock => mock.HorizontalVelocityInMetrePerSecond).Returns(0.0F);

            var decider = new FlightSegmentHandoverDecider(CreateFlightSegmentConfig(
                handoverYawAngleInDegreesEqualOrOver: 1.0F,
                handoverYawAngleInDegreesEqualOrUnder: -1.0F,
                handoverRollAngleInDegreesEqualOrOver: 1.0F,
                handoverRollAngleInDegreesEqualOrUnder: -1.0F,
                handoverPitchAngleInDegreesEqualOrOver: 1.0F,
                handoverPitchAngleInDegreesEqualOrUnder: -1.0F,
                handoverAltitudeAboveTerrainInMetersEqualOrOver: 1.0F,
                handoverAltitudeAboveTerrainInMetersEqualOrUnder: 0.0F,
                handoverLateralVelocityInMetrePerSecondEqualOrOver: 1.0F,
                handoverLateralVelocityInMetrePerSecondEqualOrUnder: -1.0F,
                handoverVerticalVelocityInMetrePerSecondEqualOrOver: 1.0F,
                handoverVerticalVelocityInMetrePerSecondEqualOrUnder: -1.0F,
                handoverHorizontalVelocityInMetrePerSecondEqualOrOver: 1.0F,
                handoverHorizontalVelocityInMetrePerSecondEqualOrUnder: -1.0F));

            // WHEN
            var canHandover = decider.CanHandover(_sensorSuite);

            // THEN
            Assert.That(canHandover, Is.False);
        }

        [Test]
        public void Should_not_handover_when_there_are_no_handover_conditions()
        {
            // GIVEN
            var decider = new FlightSegmentHandoverDecider(CreateFlightSegmentConfig(
                handoverYawAngleInDegreesEqualOrOver: null,
                handoverYawAngleInDegreesEqualOrUnder: null,
                handoverRollAngleInDegreesEqualOrOver: null,
                handoverRollAngleInDegreesEqualOrUnder: null,
                handoverPitchAngleInDegreesEqualOrOver: null,
                handoverPitchAngleInDegreesEqualOrUnder: null,
                handoverAltitudeAboveTerrainInMetersEqualOrOver: null,
                handoverAltitudeAboveTerrainInMetersEqualOrUnder: null,
                handoverLateralVelocityInMetrePerSecondEqualOrOver: null,
                handoverLateralVelocityInMetrePerSecondEqualOrUnder: null,
                handoverVerticalVelocityInMetrePerSecondEqualOrOver: null,
                handoverVerticalVelocityInMetrePerSecondEqualOrUnder: null,
                handoverHorizontalVelocityInMetrePerSecondEqualOrOver: null,
                handoverHorizontalVelocityInMetrePerSecondEqualOrUnder: null));

            // WHEN
            var canHandover = decider.CanHandover(_sensorSuite);

            // THEN
            Assert.That(canHandover, Is.False);
        }

        [Test]
        public void Should_provide_telemetry_consisting_of_the_processed_config_values()
        {
            // GIVEN
            var decider = new FlightSegmentHandoverDecider(CreateFlightSegmentConfig(
                handoverYawAngleInDegreesEqualOrOver: 0.0F,
                handoverYawAngleInDegreesEqualOrUnder: 0.1F,
                handoverRollAngleInDegreesEqualOrOver: 0.2F,
                handoverRollAngleInDegreesEqualOrUnder: 0.3F,
                handoverPitchAngleInDegreesEqualOrOver: 0.4F,
                handoverPitchAngleInDegreesEqualOrUnder: 0.5F,
                handoverAltitudeAboveTerrainInMetersEqualOrOver: 0.6F,
                handoverAltitudeAboveTerrainInMetersEqualOrUnder: 0.7F,
                handoverLateralVelocityInMetrePerSecondEqualOrOver: 0.8F,
                handoverLateralVelocityInMetrePerSecondEqualOrUnder: 0.9F,
                handoverVerticalVelocityInMetrePerSecondEqualOrOver: 1.0F,
                handoverVerticalVelocityInMetrePerSecondEqualOrUnder: 1.1F,
                handoverHorizontalVelocityInMetrePerSecondEqualOrOver: 1.2F,
                handoverHorizontalVelocityInMetrePerSecondEqualOrUnder: 1.3F));

            // THEN
            var expectedTelemetry = new List<TelemetryMessage>
            {
                new TelemetryMessage("--- Flight Segment Handover Decider Config ---"),
                new TelemetryMessage("HandoverYawAngleInDegreesEqualOrOver:0"),
                new TelemetryMessage("HandoverYawAngleInDegreesEqualOrUnder:0,1"),
                new TelemetryMessage("HandoverRollAngleInDegreesEqualOrOver:0,2"),
                new TelemetryMessage("HandoverRollAngleInDegreesEqualOrUnder:0,3"),
                new TelemetryMessage("HandoverPitchAngleInDegreesEqualOrOver:0,4"),
                new TelemetryMessage("HandoverPitchAngleInDegreesEqualOrUnder:0,5"),
                new TelemetryMessage("HandoverAltitudeAboveTerrainInMetersEqualOrOver:0,6"),
                new TelemetryMessage("HandoverAltitudeAboveTerrainInMetersEqualOrUnder:0,7"),
                new TelemetryMessage("HandoverLateralVelocityInMetrePerSecondEqualOrOver:0,8"),
                new TelemetryMessage("HandoverLateralVelocityInMetrePerSecondEqualOrUnder:0,9"),
                new TelemetryMessage("HandoverVerticalVelocityInMetrePerSecondEqualOrOver:1"),
                new TelemetryMessage("HandoverVerticalVelocityInMetrePerSecondEqualOrUnder:1,1"),
                new TelemetryMessage("HandoverHorizontalVelocityInMetrePerSecondEqualOrOver:1,2"),
                new TelemetryMessage("HandoverHorizontalVelocityInMetrePerSecondEqualOrUnder:1,3"),
                new TelemetryMessage("----------------------------------------------")
            };

            Assert.That(decider.ProvideTelemetry(), Is.EqualTo(expectedTelemetry));
        }

        [Test]
        public void Should_provide_a_equality_by_value_method()
        {
            // GIVEN
            var deciderA = new FlightSegmentHandoverDecider(CreateFlightSegmentConfig(
                handoverYawAngleInDegreesEqualOrOver: null,
                handoverYawAngleInDegreesEqualOrUnder: null,
                handoverRollAngleInDegreesEqualOrOver: null,
                handoverRollAngleInDegreesEqualOrUnder: null,
                handoverPitchAngleInDegreesEqualOrOver: null,
                handoverPitchAngleInDegreesEqualOrUnder: null,
                handoverAltitudeAboveTerrainInMetersEqualOrOver: 1000.0F,
                handoverAltitudeAboveTerrainInMetersEqualOrUnder: null,
                handoverLateralVelocityInMetrePerSecondEqualOrOver: null,
                handoverLateralVelocityInMetrePerSecondEqualOrUnder: null,
                handoverVerticalVelocityInMetrePerSecondEqualOrOver: null,
                handoverVerticalVelocityInMetrePerSecondEqualOrUnder: null,
                handoverHorizontalVelocityInMetrePerSecondEqualOrOver: null,
                handoverHorizontalVelocityInMetrePerSecondEqualOrUnder: null));

            var deciderB = new FlightSegmentHandoverDecider(CreateFlightSegmentConfig(
                handoverYawAngleInDegreesEqualOrOver: null,
                handoverYawAngleInDegreesEqualOrUnder: null,
                handoverRollAngleInDegreesEqualOrOver: null,
                handoverRollAngleInDegreesEqualOrUnder: null,
                handoverPitchAngleInDegreesEqualOrOver: null,
                handoverPitchAngleInDegreesEqualOrUnder: null,
                handoverAltitudeAboveTerrainInMetersEqualOrOver: 1000.0F,
                handoverAltitudeAboveTerrainInMetersEqualOrUnder: null,
                handoverLateralVelocityInMetrePerSecondEqualOrOver: null,
                handoverLateralVelocityInMetrePerSecondEqualOrUnder: null,
                handoverVerticalVelocityInMetrePerSecondEqualOrOver: null,
                handoverVerticalVelocityInMetrePerSecondEqualOrUnder: null,
                handoverHorizontalVelocityInMetrePerSecondEqualOrOver: null,
                handoverHorizontalVelocityInMetrePerSecondEqualOrUnder: null));

            var deciderC = new FlightSegmentHandoverDecider(CreateFlightSegmentConfig(
                handoverYawAngleInDegreesEqualOrOver: null,
                handoverYawAngleInDegreesEqualOrUnder: null,
                handoverRollAngleInDegreesEqualOrOver: null,
                handoverRollAngleInDegreesEqualOrUnder: null,
                handoverPitchAngleInDegreesEqualOrOver: null,
                handoverPitchAngleInDegreesEqualOrUnder: null,
                handoverAltitudeAboveTerrainInMetersEqualOrOver: null,
                handoverAltitudeAboveTerrainInMetersEqualOrUnder: null,
                handoverLateralVelocityInMetrePerSecondEqualOrOver: null,
                handoverLateralVelocityInMetrePerSecondEqualOrUnder: null,
                handoverVerticalVelocityInMetrePerSecondEqualOrOver: null,
                handoverVerticalVelocityInMetrePerSecondEqualOrUnder: 0.0F,
                handoverHorizontalVelocityInMetrePerSecondEqualOrOver: null,
                handoverHorizontalVelocityInMetrePerSecondEqualOrUnder: null));

            // THEN
            Assert.That(deciderA.Equals(deciderB), Is.True);
            Assert.That(deciderA.Equals(deciderC), Is.False);
        }

        private static FlightSegmentConfig CreateFlightSegmentConfig(
            float? handoverYawAngleInDegreesEqualOrOver,
            float? handoverYawAngleInDegreesEqualOrUnder,
            float? handoverRollAngleInDegreesEqualOrOver,
            float? handoverRollAngleInDegreesEqualOrUnder,
            float? handoverPitchAngleInDegreesEqualOrOver,
            float? handoverPitchAngleInDegreesEqualOrUnder,
            float? handoverAltitudeAboveTerrainInMetersEqualOrOver,
            float? handoverAltitudeAboveTerrainInMetersEqualOrUnder,
            float? handoverLateralVelocityInMetrePerSecondEqualOrOver,
            float? handoverLateralVelocityInMetrePerSecondEqualOrUnder,
            float? handoverVerticalVelocityInMetrePerSecondEqualOrOver,
            float? handoverVerticalVelocityInMetrePerSecondEqualOrUnder,
            float? handoverHorizontalVelocityInMetrePerSecondEqualOrOver,
            float? handoverHorizontalVelocityInMetrePerSecondEqualOrUnder
        ) => new FlightSegmentConfig(
            handoverYawAngleInDegreesEqualOrOver,
            handoverYawAngleInDegreesEqualOrUnder,
            handoverRollAngleInDegreesEqualOrOver,
            handoverRollAngleInDegreesEqualOrUnder,
            handoverPitchAngleInDegreesEqualOrOver,
            handoverPitchAngleInDegreesEqualOrUnder,
            handoverAltitudeAboveTerrainInMetersEqualOrOver,
            handoverAltitudeAboveTerrainInMetersEqualOrUnder,
            handoverLateralVelocityInMetrePerSecondEqualOrOver,
            handoverLateralVelocityInMetrePerSecondEqualOrUnder,
            handoverVerticalVelocityInMetrePerSecondEqualOrOver,
            handoverVerticalVelocityInMetrePerSecondEqualOrUnder,
            handoverHorizontalVelocityInMetrePerSecondEqualOrOver,
            handoverHorizontalVelocityInMetrePerSecondEqualOrUnder,
            false,
            0.0F,
            0.0F,
            0.0F,
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
    }
}