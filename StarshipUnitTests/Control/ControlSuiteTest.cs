using Moq;
using NUnit.Framework;
using Starship.Control;
using Starship.Control.Attitude;
using Starship.Control.Throttle.Main;
using Starship.Control.Throttle.Rcs;
using Starship.Flight.Command;
using Starship.Flight.Command.Attitude;
using Starship.Flight.Command.Throttle.Main;
using Starship.Flight.Command.Throttle.Rcs;

namespace StarshipUnitTests.Control
{
    public sealed class ControlSuiteTest
    {
        private Mock<IRcsEnginesThrottleControl> _rcsEnginesThrottleControl;
        private Mock<IMainEnginesThrottleControl> _mainEnginesThrottleControl;
        private Mock<IMainEnginesAttitudeControl> _mainEnginesAttitudeControl;
        private ControlSuite _controlSuite;


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
        }

        [Test]
        public void Should_control_the_throttle_of_the_rcs_engines()
        {
            // GIVEN
            var commandSuite = CreateCommandSuite();

            // WHEN
            _controlSuite.ExertControl(commandSuite);

            // THEN
            _rcsEnginesThrottleControl.Verify(mock =>
                mock.ControlRcsEnginesThrottle(
                    commandSuite.TopLeftRcsEngineThrottleCommand,
                    commandSuite.TopRightRcsEngineThrottleCommand,
                    commandSuite.BottomLeftRcsEngineThrottleCommand,
                    commandSuite.BottomRightRcsEngineThrottleCommand));
        }

        [Test]
        public void Should_control_the_throttle_of_the_main_engines()
        {
            // GIVEN
            var commandSuite = CreateCommandSuite();

            // WHEN
            _controlSuite.ExertControl(commandSuite);

            // THEN
            _mainEnginesThrottleControl.Verify(mock =>
                mock.ControlMainEnginesThrottle(
                    commandSuite.TopMainEngineThrottleCommand,
                    commandSuite.BottomLeftMainEngineThrottleCommand,
                    commandSuite.BottomRightMainEngineThrottleCommand));
        }

        [Test]
        public void Should_control_the_attitude_of_the_main_engines()
        {
            // GIVEN
            var commandSuite = CreateCommandSuite();

            // WHEN
            _controlSuite.ExertControl(commandSuite);

            // THEN
            _mainEnginesAttitudeControl.Verify(mock =>
                mock.ControlMainEnginesAttitude(
                    commandSuite.MainEngineAttitudeYawCommand,
                    commandSuite.MainEngineAttitudeRollCommand,
                    commandSuite.MainEngineAttitudePitchCommand));
        }

        private static CommandSuite CreateCommandSuite() =>
            new CommandSuite(
                new TopLeftRcsEngineThrottleCommand(0F),
                new TopRightRcsEngineThrottleCommand(0F),
                new BottomLeftRcsEngineThrottleCommand(0F),
                new BottomRightRcsEngineThrottleCommand(0F),
                new TopMainEngineThrottleCommand(0F),
                new BottomLeftMainEngineThrottleCommand(0F),
                new BottomRightMainEngineThrottleCommand(0F),
                new MainEngineAttitudeYawCommand(0F),
                new MainEngineAttitudeRollCommand(0F),
                new MainEngineAttitudePitchCommand(0F));
    }
}