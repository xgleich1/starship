using Moq;
using NUnit.Framework;
using Starship.Control;
using Starship.Control.Actuation.Engine;
using Starship.Control.Actuation.Flap;
using Starship.Control.Throttle.Main;
using Starship.Control.Throttle.Rcs;
using Starship.Flight.Command;
using Starship.Flight.Command.Actuation.Engine;
using Starship.Flight.Command.Actuation.Flap;
using Starship.Flight.Command.Throttle.Main;
using Starship.Flight.Command.Throttle.Rcs;

namespace StarshipUnitTests.Control
{
    public sealed class ControlSuiteTest
    {
        private Mock<IRcsEnginesThrottleControl> _rcsEnginesThrottleControl;
        private Mock<IMainEnginesThrottleControl> _mainEnginesThrottleControl;
        private Mock<IMainEnginesGimbalControl> _mainEnginesGimbalControl;
        private Mock<IFlapsActuationControl> _flapsActuationControl;
        private ControlSuite _controlSuite;


        [SetUp]
        public void Setup()
        {
            _rcsEnginesThrottleControl =
                new Mock<IRcsEnginesThrottleControl>();
            _mainEnginesThrottleControl =
                new Mock<IMainEnginesThrottleControl>();
            _mainEnginesGimbalControl =
                new Mock<IMainEnginesGimbalControl>();
            _flapsActuationControl =
                new Mock<IFlapsActuationControl>();

            _controlSuite = new ControlSuite(
                _rcsEnginesThrottleControl.Object,
                _mainEnginesThrottleControl.Object,
                _mainEnginesGimbalControl.Object,
                _flapsActuationControl.Object);
        }

        [Test]
        public void Should_throttle_the_rcs_engines()
        {
            // GIVEN
            var commandSuite = CreateCommandSuite();

            // WHEN
            _controlSuite.ExertControl(commandSuite);

            // THEN
            _rcsEnginesThrottleControl.Verify(mock =>
                mock.ThrottleRcsEngines(
                    commandSuite.ThrottleTopLeftRcsEngineCommand,
                    commandSuite.ThrottleTopRightRcsEngineCommand,
                    commandSuite.ThrottleBottomLeftRcsEngineCommand,
                    commandSuite.ThrottleBottomRightRcsEngineCommand));
        }

        [Test]
        public void Should_throttle_the_main_engines()
        {
            // GIVEN
            var commandSuite = CreateCommandSuite();

            // WHEN
            _controlSuite.ExertControl(commandSuite);

            // THEN
            _mainEnginesThrottleControl.Verify(mock =>
                mock.ThrottleMainEngines(
                    commandSuite.ThrottleTopMainEngineCommand,
                    commandSuite.ThrottleBottomLeftMainEngineCommand,
                    commandSuite.ThrottleBottomRightMainEngineCommand));
        }

        [Test]
        public void Should_gimbal_the_main_engines()
        {
            // GIVEN
            var commandSuite = CreateCommandSuite();

            // WHEN
            _controlSuite.ExertControl(commandSuite);

            // THEN
            _mainEnginesGimbalControl.Verify(mock =>
                mock.GimbalMainEngines(
                    commandSuite.YawMainEnginesCommand,
                    commandSuite.RollMainEnginesCommand,
                    commandSuite.PitchMainEnginesCommand));
        }

        [Test]
        public void Should_actuate_the_flaps()
        {
            // GIVEN
            var commandSuite = CreateCommandSuite();

            // WHEN
            _controlSuite.ExertControl(commandSuite);

            // THEN
            _flapsActuationControl.Verify(mock =>
                mock.ActuateFlaps(
                    commandSuite.ActuateTopLeftFlapCommand,
                    commandSuite.ActuateTopRightFlapCommand,
                    commandSuite.ActuateBottomLeftFlapCommand,
                    commandSuite.ActuateBottomRightFlapCommand));
        }

        private static CommandSuite CreateCommandSuite() =>
            new CommandSuite(
                new ThrottleTopLeftRcsEngineCommand(0.0F),
                new ThrottleTopRightRcsEngineCommand(0.0F),
                new ThrottleBottomLeftRcsEngineCommand(0.0F),
                new ThrottleBottomRightRcsEngineCommand(0.0F),
                new ThrottleTopMainEngineCommand(0.0F),
                new ThrottleBottomLeftMainEngineCommand(0.0F),
                new ThrottleBottomRightMainEngineCommand(0.0F),
                new YawMainEnginesCommand(0.0F),
                new RollMainEnginesCommand(0.0F),
                new PitchMainEnginesCommand(0.0F),
                new ActuateTopLeftFlapCommand(0.0F),
                new ActuateTopRightFlapCommand(0.0F),
                new ActuateBottomLeftFlapCommand(0.0F),
                new ActuateBottomRightFlapCommand(0.0F));
    }
}