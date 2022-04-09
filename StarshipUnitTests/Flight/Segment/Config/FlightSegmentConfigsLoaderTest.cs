using System.Collections.Generic;
using NUnit.Framework;
using Starship.Flight.Segment.Config;
using Starship.Flight.Segment.Config.Path;
using Starship.Utility.Timing.Units;
using static System.IO.Directory;

namespace StarshipUnitTests.Flight.Segment.Config
{
    public sealed class FlightSegmentConfigsLoaderTest
    {
        private FlightSegmentConfigsLoader _flightSegmentConfigsLoader;


        [SetUp]
        public void Setup()
        {
            _flightSegmentConfigsLoader =
                new FlightSegmentConfigsLoader(
                    new TestFlightSegmentConfigsPath());
        }

        [Test]
        public void Should_load_the_serialized_flight_segment_configs()
        {
            // WHEN
            var flightSegmentConfigs = _flightSegmentConfigsLoader.LoadFlightSegmentConfigs();

            // THEN
            var expectedFlightSegmentConfigs = new List<FlightSegmentConfig>
            {
                new FlightSegmentConfig(
                    new Seconds(0L),
                    0.10F, 0.15F, 0.20F,
                    0.0F, -45.0F, -90.0F,
                    0.01F, 0.02F, 0.03F,
                    0.3F, 0.4F, 0.5F,
                    0.04F, 0.05F, 0.06F,
                    0.6F, 0.7F, 0.9F, 0.9F),
                new FlightSegmentConfig(
                    new Seconds(15L),
                    null, null, null,
                    0.0F, 0.0F, 0.0F,
                    0.0F, 0.0F, 0.0F,
                    null, null, null,
                    0.0F, 0.0F, 0.0F,
                    null, null, null, null),
                new FlightSegmentConfig(
                    new Seconds(30L),
                    0.15F, 0.20F, 0.25F,
                    -1.0F, -46.0F, -91.0F,
                    0.02F, 0.03F, 0.04F,
                    0.4F, 0.5F, 0.6F,
                    0.05F, 0.06F, 0.07F,
                    0.7F, 0.8F, 0.9F, 1.0F)
            };

            Assert.That(flightSegmentConfigs, Is.EqualTo(expectedFlightSegmentConfigs));
        }

        private sealed class TestFlightSegmentConfigsPath : IFlightSegmentConfigsPath
        {
            public string RawPath =>
                GetParent(GetCurrentDirectory()).Parent.Parent.FullName +
                @"\Flight\Segment\Config\test_flight_segment_configs.xml";
        }
    }
}