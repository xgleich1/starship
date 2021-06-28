using Moq;
using NUnit.Framework;
using Starship.Control;
using Starship.Control.MainEnginesAttitude;
using Starship.Control.MainEnginesThrottle;
using Starship.Control.RcsEnginesThrottle;
using Starship.Flight.Command;

namespace StarshipUnitTests.Control
{
    public class ControlSuiteTest
    {
        private Mock<IRcsEnginesThrottleControl> _rcsEnginesThrottleControl;
        private Mock<IMainEnginesThrottleControl> _mainEnginesThrottleControl;
        private Mock<IMainEnginesAttitudeControl> _mainEnginesAttitudeControl;
        private ControlSuite _controlSuite;

        private IFlightCommand _flightCommand;


        [Test]
        public void Should_control_the_throttle_of_the_rcs_engines()
        {
            // WHEN
            _controlSuite.ExertControl(_flightCommand);

            // THEN
            _rcsEnginesThrottleControl.Verify(mock =>
                mock.ControlRcsEnginesThrottle(_flightCommand));
        }

        [Test]
        public void Should_control_the_throttle_of_the_main_engines()
        {
            // WHEN
            _controlSuite.ExertControl(_flightCommand);

            // THEN
            _mainEnginesThrottleControl.Verify(mock =>
                mock.ControlMainEnginesThrottle(_flightCommand));
        }

        [Test]
        public void Should_control_the_attitude_of_the_main_engines()
        {
            // WHEN
            _controlSuite.ExertControl(_flightCommand);

            // THEN
            _mainEnginesAttitudeControl.Verify(mock =>
                mock.ControlMainEnginesAttitude(_flightCommand));
        }

        [SetUp]
        public void Setup()
        {
            _rcsEnginesThrottleControl =
                new Mock<IRcsEnginesThrottleControl>();

            _mainEnginesThrottleControl =
                new Mock<IMainEnginesThrottleControl>();

            _mainEnginesAttitudeControl =
                new Mock<IMainEnginesAttitudeControl>();

            _controlSuite = new ControlSuite(
                _rcsEnginesThrottleControl.Object,
                _mainEnginesThrottleControl.Object,
                _mainEnginesAttitudeControl.Object);

            _flightCommand =
                new Mock<IFlightCommand>().Object;
        }
    }
}