using Moq;
using NUnit.Framework;
using Starship.Control;
using Starship.Control.Attitude;
using Starship.Control.Throttle.Main;
using Starship.Control.Throttle.Rcs;
using Starship.Flight.Command;

namespace StarshipUnitTests.Control
{
    public sealed class ControlSuiteTest
    {
        private Mock<IRcsEnginesThrottleControl> _rcsEnginesThrottleControl;
        private Mock<IMainEnginesThrottleControl> _mainEnginesThrottleControl;
        private Mock<IMainEnginesAttitudeControl> _mainEnginesAttitudeControl;
        private ControlSuite _controlSuite;

        private ICommandSuite _commandSuite;


        [Test]
        public void Should_control_the_throttle_of_the_rcs_engines()
        {
            // WHEN
            _controlSuite.ExertControl(_commandSuite);

            // THEN
            _rcsEnginesThrottleControl.Verify(mock =>
                mock.ControlRcsEnginesThrottle(_commandSuite));
        }

        [Test]
        public void Should_control_the_throttle_of_the_main_engines()
        {
            // WHEN
            _controlSuite.ExertControl(_commandSuite);

            // THEN
            _mainEnginesThrottleControl.Verify(mock =>
                mock.ControlMainEnginesThrottle(_commandSuite));
        }

        [Test]
        public void Should_control_the_attitude_of_the_main_engines()
        {
            // WHEN
            _controlSuite.ExertControl(_commandSuite);

            // THEN
            _mainEnginesAttitudeControl.Verify(mock =>
                mock.ControlMainEnginesAttitude(_commandSuite));
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

            _commandSuite =
                new Mock<ICommandSuite>().Object;
        }
    }
}