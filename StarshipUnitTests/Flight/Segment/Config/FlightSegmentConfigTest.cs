using System.Collections.Generic;
using NUnit.Framework;
using Starship.Flight.Segment.Config;
using Starship.Telemetry;
using Starship.Utility.Timing.Units;

namespace StarshipUnitTests.Flight.Segment.Config
{
    public sealed class FlightSegmentConfigTest
    {
        [Test]
        public void Should_expose_the_takeover_seconds_in_mission()
        {
            // GIVEN
            var config = new FlightSegmentConfig(
                new Seconds(0L),
                null, null, null,
                0.0F, 0.0F, 0.0F,
                0.0F, 0.0F, 0.0F,
                null, null, null,
                0.0F, 0.0F, 0.0F,
                null, null, null, null);

            // THEN
            Assert.That(config.TakeoverSecondsInMission, Is.EqualTo(new Seconds(0L)));
        }

        [Test]
        public void Should_expose_the_top_main_engine_throttle_percent_overwrite()
        {
            // GIVEN
            var config = new FlightSegmentConfig(
                new Seconds(0L),
                1.0F, null, null,
                0.0F, 0.0F, 0.0F,
                0.0F, 0.0F, 0.0F,
                null, null, null,
                0.0F, 0.0F, 0.0F,
                null, null, null, null);

            // THEN
            Assert.That(config.TopMainEngineThrottlePercentOverwrite, Is.EqualTo(1.0F));
        }

        [Test]
        public void Should_expose_the_bottom_left_main_engine_throttle_percent_overwrite()
        {
            // GIVEN
            var config = new FlightSegmentConfig(
                new Seconds(0L),
                null, 1.0F, null,
                0.0F, 0.0F, 0.0F,
                0.0F, 0.0F, 0.0F,
                null, null, null,
                0.0F, 0.0F, 0.0F,
                null, null, null, null);

            // THEN
            Assert.That(config.BottomLeftMainEngineThrottlePercentOverwrite, Is.EqualTo(1.0F));
        }

        [Test]
        public void Should_expose_the_bottom_right_main_engine_throttle_percent_overwrite()
        {
            // GIVEN
            var config = new FlightSegmentConfig(
                new Seconds(0L),
                null, null, 1.0F,
                0.0F, 0.0F, 0.0F,
                0.0F, 0.0F, 0.0F,
                null, null, null,
                0.0F, 0.0F, 0.0F,
                null, null, null, null);

            // THEN
            Assert.That(config.BottomRightMainEngineThrottlePercentOverwrite, Is.EqualTo(1.0F));
        }

        [Test]
        public void Should_expose_the_desired_yaw_angle_in_degrees()
        {
            // GIVEN
            var config = new FlightSegmentConfig(
                new Seconds(0L),
                null, null, null,
                -90.0F, 0.0F, 0.0F,
                0.0F, 0.0F, 0.0F,
                null, null, null,
                0.0F, 0.0F, 0.0F,
                null, null, null, null);

            // THEN
            Assert.That(config.DesiredYawAngleInDegrees, Is.EqualTo(-90.0F));
        }

        [Test]
        public void Should_expose_the_desired_roll_angle_in_degrees()
        {
            // GIVEN
            var config = new FlightSegmentConfig(
                new Seconds(0L),
                null, null, null,
                0.0F, -90.0F, 0.0F,
                0.0F, 0.0F, 0.0F,
                null, null, null,
                0.0F, 0.0F, 0.0F,
                null, null, null, null);

            // THEN
            Assert.That(config.DesiredRollAngleInDegrees, Is.EqualTo(-90.0F));
        }

        [Test]
        public void Should_expose_the_desired_pitch_angle_in_degrees()
        {
            // GIVEN
            var config = new FlightSegmentConfig(
                new Seconds(0L),
                null, null, null,
                0.0F, 0.0F, -90.0F,
                0.0F, 0.0F, 0.0F,
                null, null, null,
                0.0F, 0.0F, 0.0F,
                null, null, null, null);

            // THEN
            Assert.That(config.DesiredPitchAngleInDegrees, Is.EqualTo(-90.0F));
        }

        [Test]
        public void Should_expose_the_yaw_with_main_engines_proportional_gain()
        {
            // GIVEN
            var config = new FlightSegmentConfig(
                new Seconds(0L),
                null, null, null,
                0.0F, 0.0F, 0.0F,
                0.01F, 0.0F, 0.0F,
                null, null, null,
                0.0F, 0.0F, 0.0F,
                null, null, null, null);

            // THEN
            Assert.That(config.YawWithMainEnginesProportionalGain, Is.EqualTo(0.01F));
        }

        [Test]
        public void Should_expose_the_roll_with_main_engines_proportional_gain()
        {
            // GIVEN
            var config = new FlightSegmentConfig(
                new Seconds(0L),
                null, null, null,
                0.0F, 0.0F, 0.0F,
                0.0F, 0.01F, 0.0F,
                null, null, null,
                0.0F, 0.0F, 0.0F,
                null, null, null, null);

            // THEN
            Assert.That(config.RollWithMainEnginesProportionalGain, Is.EqualTo(0.01F));
        }

        [Test]
        public void Should_expose_the_pitch_with_main_engines_proportional_gain()
        {
            // GIVEN
            var config = new FlightSegmentConfig(
                new Seconds(0L),
                null, null, null,
                0.0F, 0.0F, 0.0F,
                0.0F, 0.0F, 0.01F,
                null, null, null,
                0.0F, 0.0F, 0.0F,
                null, null, null, null);

            // THEN
            Assert.That(config.PitchWithMainEnginesProportionalGain, Is.EqualTo(0.01F));
        }

        [Test]
        public void Should_expose_the_main_engines_yaw_percent_overwrite()
        {
            // GIVEN
            var config = new FlightSegmentConfig(
                new Seconds(0L),
                null, null, null,
                0.0F, 0.0F, 0.0F,
                0.0F, 0.0F, 0.0F,
                1.0F, null, null,
                0.0F, 0.0F, 0.0F,
                null, null, null, null);

            // THEN
            Assert.That(config.MainEnginesYawPercentOverwrite, Is.EqualTo(1.0F));
        }

        [Test]
        public void Should_expose_the_main_engines_roll_percent_overwrite()
        {
            // GIVEN
            var config = new FlightSegmentConfig(
                new Seconds(0L),
                null, null, null,
                0.0F, 0.0F, 0.0F,
                0.0F, 0.0F, 0.0F,
                null, 1.0F, null,
                0.0F, 0.0F, 0.0F,
                null, null, null, null);

            // THEN
            Assert.That(config.MainEnginesRollPercentOverwrite, Is.EqualTo(1.0F));
        }

        [Test]
        public void Should_expose_the_main_engines_pitch_percent_overwrite()
        {
            // GIVEN
            var config = new FlightSegmentConfig(
                new Seconds(0L),
                null, null, null,
                0.0F, 0.0F, 0.0F,
                0.0F, 0.0F, 0.0F,
                null, null, 1.0F,
                0.0F, 0.0F, 0.0F,
                null, null, null, null);

            // THEN
            Assert.That(config.MainEnginesPitchPercentOverwrite, Is.EqualTo(1.0F));
        }

        [Test]
        public void Should_expose_the_yaw_with_flaps_proportional_gain()
        {
            // GIVEN
            var config = new FlightSegmentConfig(
                new Seconds(0L),
                null, null, null,
                0.0F, 0.0F, 0.0F,
                0.0F, 0.0F, 0.0F,
                null, null, null,
                0.02F, 0.0F, 0.0F,
                null, null, null, null);

            // THEN
            Assert.That(config.YawWithFlapsProportionalGain, Is.EqualTo(0.02F));
        }

        [Test]
        public void Should_expose_the_roll_with_flaps_proportional_gain()
        {
            // GIVEN
            var config = new FlightSegmentConfig(
                new Seconds(0L),
                null, null, null,
                0.0F, 0.0F, 0.0F,
                0.0F, 0.0F, 0.0F,
                null, null, null,
                0.0F, 0.02F, 0.0F,
                null, null, null, null);

            // THEN
            Assert.That(config.RollWithFlapsProportionalGain, Is.EqualTo(0.02F));
        }

        [Test]
        public void Should_expose_the_pitch_with_flaps_proportional_gain()
        {
            // GIVEN
            var config = new FlightSegmentConfig(
                new Seconds(0L),
                null, null, null,
                0.0F, 0.0F, 0.0F,
                0.0F, 0.0F, 0.0F,
                null, null, null,
                0.0F, 0.0F, 0.02F,
                null, null, null, null);

            // THEN
            Assert.That(config.PitchWithFlapsProportionalGain, Is.EqualTo(0.02F));
        }

        [Test]
        public void Should_expose_the_top_left_flap_deploy_percent_overwrite()
        {
            // GIVEN
            var config = new FlightSegmentConfig(
                new Seconds(0L),
                null, null, null,
                0.0F, 0.0F, 0.0F,
                0.0F, 0.0F, 0.0F,
                null, null, null,
                0.0F, 0.0F, 0.0F,
                1.0F, null, null, null);

            // THEN
            Assert.That(config.TopLeftFlapDeployPercentOverwrite, Is.EqualTo(1.0F));
        }

        [Test]
        public void Should_expose_the_top_right_flap_deploy_percent_overwrite()
        {
            // GIVEN
            var config = new FlightSegmentConfig(
                new Seconds(0L),
                null, null, null,
                0.0F, 0.0F, 0.0F,
                0.0F, 0.0F, 0.0F,
                null, null, null,
                0.0F, 0.0F, 0.0F,
                null, 1.0F, null, null);

            // THEN
            Assert.That(config.TopRightFlapDeployPercentOverwrite, Is.EqualTo(1.0F));
        }

        [Test]
        public void Should_expose_the_bottom_left_flap_deploy_percent_overwrite()
        {
            // GIVEN
            var config = new FlightSegmentConfig(
                new Seconds(0L),
                null, null, null,
                0.0F, 0.0F, 0.0F,
                0.0F, 0.0F, 0.0F,
                null, null, null,
                0.0F, 0.0F, 0.0F,
                null, null, 1.0F, null);

            // THEN
            Assert.That(config.BottomLeftFlapDeployPercentOverwrite, Is.EqualTo(1.0F));
        }

        [Test]
        public void Should_expose_the_bottom_right_flap_deploy_percent_overwrite()
        {
            // GIVEN
            var config = new FlightSegmentConfig(
                new Seconds(0L),
                null, null, null,
                0.0F, 0.0F, 0.0F,
                0.0F, 0.0F, 0.0F,
                null, null, null,
                0.0F, 0.0F, 0.0F,
                null, null, null, 1.0F);

            // THEN
            Assert.That(config.BottomRightFlapDeployPercentOverwrite, Is.EqualTo(1.0F));
        }

        [Test]
        public void Should_provide_a_equality_by_value_method()
        {
            // GIVEN
            var configA = new FlightSegmentConfig(
                new Seconds(0L),
                0.25F, 0.25F, 0.25F,
                0.0F, 0.0F, 0.0F,
                0.01F, 0.01F, 0.01F,
                null, null, null,
                0.0F, 0.0F, 0.0F,
                1.0F, 1.0F, 1.0F, 1.0F);

            var configB = new FlightSegmentConfig(
                new Seconds(0L),
                0.25F, 0.25F, 0.25F,
                0.0F, 0.0F, 0.0F,
                0.01F, 0.01F, 0.01F,
                null, null, null,
                0.0F, 0.0F, 0.0F,
                1.0F, 1.0F, 1.0F, 1.0F);

            var configC = new FlightSegmentConfig(
                new Seconds(30L),
                0.0F, 0.0F, 0.0F,
                0.0F, 0.0F, -90.0F,
                0.0F, 0.0F, 0.0F,
                0.0F, 0.0F, 0.0F,
                0.02F, 0.02F, 0.02F,
                null, null, null, null);

            // THEN
            Assert.That(configA.Equals(configB), Is.True);
            Assert.That(configA.Equals(configC), Is.False);
        }

        [Test]
        public void Should_provide_telemetry_containing_all_constants()
        {
            // GIVEN
            var config = new FlightSegmentConfig(
                new Seconds(0L),
                0.10F, 0.15F, 0.20F,
                0.0F, -45.0F, -90.0F,
                0.01F, 0.02F, 0.03F,
                0.4F, 0.5F, 0.6F,
                0.04F, 0.05F, 0.06F,
                0.7F, 0.8F, 0.9F, 1.0F);

            // THEN
            var expectedTelemetry = new List<TelemetryMessage>
            {
                new TelemetryMessage("TopMainEngineThrottlePercentOverwrite:0,1"),
                new TelemetryMessage("BottomLeftMainEngineThrottlePercentOverwrite:0,15"),
                new TelemetryMessage("BottomRightMainEngineThrottlePercentOverwrite:0,2"),
                new TelemetryMessage("DesiredYawAngleInDegrees:0"),
                new TelemetryMessage("DesiredRollAngleInDegrees:-45"),
                new TelemetryMessage("DesiredPitchAngleInDegrees:-90"),
                new TelemetryMessage("YawWithMainEnginesProportionalGain:0,01"),
                new TelemetryMessage("RollWithMainEnginesProportionalGain:0,02"),
                new TelemetryMessage("PitchWithMainEnginesProportionalGain:0,03"),
                new TelemetryMessage("MainEnginesYawPercentOverwrite:0,4"),
                new TelemetryMessage("MainEnginesRollPercentOverwrite:0,5"),
                new TelemetryMessage("MainEnginesPitchPercentOverwrite:0,6"),
                new TelemetryMessage("YawWithFlapsProportionalGain:0,04"),
                new TelemetryMessage("RollWithFlapsProportionalGain:0,05"),
                new TelemetryMessage("PitchWithFlapsProportionalGain:0,06"),
                new TelemetryMessage("TopLeftFlapDeployPercentOverwrite:0,7"),
                new TelemetryMessage("TopRightFlapDeployPercentOverwrite:0,8"),
                new TelemetryMessage("BottomLeftFlapDeployPercentOverwrite:0,9"),
                new TelemetryMessage("BottomRightFlapDeployPercentOverwrite:1")
            };

            Assert.That(config.ProvideTelemetry(), Is.EqualTo(expectedTelemetry));
        }
    }
}