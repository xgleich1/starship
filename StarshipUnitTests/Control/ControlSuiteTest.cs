using Moq;
using NUnit.Framework;
using Starship.Control;
using Starship.Control.Activation.Rcs;
using Starship.Control.Actuation.Engine;
using Starship.Control.Actuation.Flap;
using Starship.Control.Actuation.Leg;
using Starship.Control.Throttle.Main;
using Starship.Flight.Command;
using Starship.Flight.Command.Activation.Rcs;
using Starship.Flight.Command.Actuation.Engine;
using Starship.Flight.Command.Actuation.Flap;
using Starship.Flight.Command.Actuation.Leg;
using Starship.Flight.Command.Throttle.Main;

namespace StarshipUnitTests.Control
{
    public sealed class ControlSuiteTest
    {
        private Mock<IRcsActivationControl> _rcsActivationControl;
        private Mock<ILegsActuationControl> _legsActuationControl;
        private Mock<IFlapsActuationControl> _flapsActuationControl;
        private Mock<IMainEnginesGimbalControl> _mainEnginesGimbalControl;
        private Mock<IMainEnginesThrottleControl> _mainEnginesThrottleControl;
        private ControlSuite _controlSuite;


        [SetUp]
        public void Setup()
        {
            _rcsActivationControl = new Mock<IRcsActivationControl>();
            _legsActuationControl = new Mock<ILegsActuationControl>();
            _flapsActuationControl = new Mock<IFlapsActuationControl>();
            _mainEnginesGimbalControl = new Mock<IMainEnginesGimbalControl>();
            _mainEnginesThrottleControl = new Mock<IMainEnginesThrottleControl>();

            _controlSuite = new ControlSuite(
                _rcsActivationControl.Object,
                _legsActuationControl.Object,
                _flapsActuationControl.Object,
                _mainEnginesGimbalControl.Object,
                _mainEnginesThrottleControl.Object);
        }

        [Test]
        public void Should_activate_the_rcs()
        {
            // GIVEN
            var commandSuite = CreateCommandSuite();

            // WHEN
            _controlSuite.ExertControl(commandSuite);

            // THEN
            _rcsActivationControl.Verify(mock =>
                mock.ActivateRcs(
                    commandSuite.TopLeftRcsActivationCommand,
                    commandSuite.TopRightRcsActivationCommand,
                    commandSuite.BottomLeftRcsActivationCommand,
                    commandSuite.BottomRightRcsActivationCommand));
        }

        [Test]
        public void Should_actuate_the_legs()
        {
            // GIVEN
            var commandSuite = CreateCommandSuite();

            // WHEN
            _controlSuite.ExertControl(commandSuite);

            // THEN
            _legsActuationControl.Verify(mock =>
                mock.ActuateLegs(commandSuite.LegsActuationCommand));
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
                    commandSuite.TopLeftFlapActuationCommand,
                    commandSuite.TopRightFlapActuationCommand,
                    commandSuite.BottomLeftFlapActuationCommand,
                    commandSuite.BottomRightFlapActuationCommand));
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
                    commandSuite.MainEnginesYawCommand,
                    commandSuite.MainEnginesRollCommand,
                    commandSuite.MainEnginesPitchCommand));
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
                    commandSuite.TopMainEngineThrottleCommand,
                    commandSuite.BottomLeftMainEngineThrottleCommand,
                    commandSuite.BottomRightMainEngineThrottleCommand));
        }

        private static CommandSuite CreateCommandSuite() => new CommandSuite(
            new TopLeftRcsActivationCommand(false),
            new TopRightRcsActivationCommand(false),
            new BottomLeftRcsActivationCommand(false),
            new BottomRightRcsActivationCommand(false),
            new LegsActuationCommand(false),
            new TopLeftFlapActuationCommand(0.0F),
            new TopRightFlapActuationCommand(0.0F),
            new BottomLeftFlapActuationCommand(0.0F),
            new BottomRightFlapActuationCommand(0.0F),
            new MainEnginesYawCommand(0.0F),
            new MainEnginesRollCommand(0.0F),
            new MainEnginesPitchCommand(0.0F),
            new TopMainEngineThrottleCommand(0.0F),
            new BottomLeftMainEngineThrottleCommand(0.0F),
            new BottomRightMainEngineThrottleCommand(0.0F));
    }
}