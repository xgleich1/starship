using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using Starship.Flight.Command;
using Starship.Flight.Command.Activation.Rcs;
using Starship.Flight.Command.Actuation.Engine;
using Starship.Flight.Command.Actuation.Flap;
using Starship.Flight.Command.Actuation.Leg;
using Starship.Flight.Command.Throttle.Main;
using Starship.Flight.Segment;
using Starship.Flight.Segment.Activation.Rcs;
using Starship.Flight.Segment.Actuation.Engine;
using Starship.Flight.Segment.Actuation.Flap;
using Starship.Flight.Segment.Actuation.Leg;
using Starship.Flight.Segment.Handover;
using Starship.Flight.Segment.Throttle.Main;
using Starship.Sensor;
using Starship.Telemetry;

namespace StarshipUnitTests.Flight.Segment
{
    public sealed class FlightSegmentCommanderTest
    {
        private Mock<IFlightSegmentHandoverDecider> _flightSegmentHandoverDecider;
        private Mock<IRcsActivationSegmentCommander> _rcsActivationSegmentCommander;
        private Mock<ILegsActuationSegmentCommander> _legsActuationSegmentCommander;
        private Mock<IFlapsActuationSegmentCommander> _flapsActuationSegmentCommander;
        private Mock<IMainEnginesGimbalSegmentCommander> _mainEnginesGimbalSegmentCommander;
        private Mock<IMainEnginesThrottleSegmentCommander> _mainEnginesThrottleSegmentCommander;
        private FlightSegmentCommander _flightSegmentCommander;

        private Mock<ISensorSuite> _sensorSuite;


        [SetUp]
        public void Setup()
        {
            _flightSegmentHandoverDecider = new Mock<IFlightSegmentHandoverDecider>();
            _rcsActivationSegmentCommander = new Mock<IRcsActivationSegmentCommander>();
            _legsActuationSegmentCommander = new Mock<ILegsActuationSegmentCommander>();
            _flapsActuationSegmentCommander = new Mock<IFlapsActuationSegmentCommander>();
            _mainEnginesGimbalSegmentCommander = new Mock<IMainEnginesGimbalSegmentCommander>();
            _mainEnginesThrottleSegmentCommander = new Mock<IMainEnginesThrottleSegmentCommander>();
            _flightSegmentCommander = new FlightSegmentCommander(
                _flightSegmentHandoverDecider.Object,
                _rcsActivationSegmentCommander.Object,
                _legsActuationSegmentCommander.Object,
                _flapsActuationSegmentCommander.Object,
                _mainEnginesGimbalSegmentCommander.Object,
                _mainEnginesThrottleSegmentCommander.Object);

            _sensorSuite = new Mock<ISensorSuite>();
        }

        [Test]
        public void Should_decide_to_handover_based_on_the_current_sensor_output()
        {
            // GIVEN
            _flightSegmentHandoverDecider.Setup(mock => mock.CanHandover(_sensorSuite.Object))
                .Returns(true);

            // WHEN
            var canHandover = _flightSegmentCommander.CanHandover(_sensorSuite.Object);

            // THEN
            Assert.That(canHandover, Is.True);
        }

        [Test]
        public void Should_command_the_flight_segment_using_the_current_sensor_output()
        {
            // GIVEN
            var topLeftRcsActivationCommand = new TopLeftRcsActivationCommand(false);
            var topRightRcsActivationCommand = new TopRightRcsActivationCommand(false);
            var bottomLeftRcsActivationCommand = new BottomLeftRcsActivationCommand(false);
            var bottomRightRcsActivationCommand = new BottomRightRcsActivationCommand(false);
            var legsActuationCommand = new LegsActuationCommand(false);
            var topLeftFlapActuationCommand = new TopLeftFlapActuationCommand(1.0F);
            var topRightFlapActuationCommand = new TopRightFlapActuationCommand(1.0F);
            var bottomLeftFlapActuationCommand = new BottomLeftFlapActuationCommand(1.0F);
            var bottomRightFlapActuationCommand = new BottomRightFlapActuationCommand(1.0F);
            var mainEnginesYawCommand = new MainEnginesYawCommand(0.0F);
            var mainEnginesRollCommand = new MainEnginesRollCommand(0.0F);
            var mainEnginesPitchCommand = new MainEnginesPitchCommand(0.0F);
            var topMainEngineThrottleCommand = new TopMainEngineThrottleCommand(1.0F);
            var bottomLeftMainEngineThrottleCommand = new BottomLeftMainEngineThrottleCommand(1.0F);
            var bottomRightMainEngineThrottleCommand = new BottomRightMainEngineThrottleCommand(1.0F);

            _rcsActivationSegmentCommander.Setup(mock => mock.CommandRcsActivation(_sensorSuite.Object))
                .Returns(new RcsActivationSegmentCommands(
                    topLeftRcsActivationCommand,
                    topRightRcsActivationCommand,
                    bottomLeftRcsActivationCommand,
                    bottomRightRcsActivationCommand));

            _legsActuationSegmentCommander.Setup(mock => mock.CommandLegsActuation(_sensorSuite.Object))
                .Returns(legsActuationCommand);

            _flapsActuationSegmentCommander.Setup(mock => mock.CommandFlapsActuation(_sensorSuite.Object))
                .Returns(new FlapsActuationSegmentCommands(
                    topLeftFlapActuationCommand,
                    topRightFlapActuationCommand,
                    bottomLeftFlapActuationCommand,
                    bottomRightFlapActuationCommand));

            _mainEnginesGimbalSegmentCommander.Setup(mock => mock.CommandMainEnginesGimbal(_sensorSuite.Object))
                .Returns(new MainEnginesGimbalSegmentCommands(
                    mainEnginesYawCommand,
                    mainEnginesRollCommand,
                    mainEnginesPitchCommand));

            _mainEnginesThrottleSegmentCommander.Setup(mock => mock.CommandMainEnginesThrottle(_sensorSuite.Object))
                .Returns(new MainEnginesThrottleSegmentCommands(
                    topMainEngineThrottleCommand,
                    bottomLeftMainEngineThrottleCommand,
                    bottomRightMainEngineThrottleCommand));

            // WHEN
            var commandSuite = _flightSegmentCommander.CommandFlight(_sensorSuite.Object);

            // THEN
            Assert.That(commandSuite, Is.EqualTo(new CommandSuite(
                topLeftRcsActivationCommand,
                topRightRcsActivationCommand,
                bottomLeftRcsActivationCommand,
                bottomRightRcsActivationCommand,
                legsActuationCommand,
                topLeftFlapActuationCommand,
                topRightFlapActuationCommand,
                bottomLeftFlapActuationCommand,
                bottomRightFlapActuationCommand,
                mainEnginesYawCommand,
                mainEnginesRollCommand,
                mainEnginesPitchCommand,
                topMainEngineThrottleCommand,
                bottomLeftMainEngineThrottleCommand,
                bottomRightMainEngineThrottleCommand)));
        }

        [Test]
        public void Should_provide_the_telemetry_of_each_sub_commander()
        {
            // GIVEN
            _rcsActivationSegmentCommander.Setup(mock => mock.ProvideTelemetry())
                .Returns(new List<TelemetryMessage>
                {
                    new TelemetryMessage("--- Rcs Activation Segment Commander Config ---"),
                    new TelemetryMessage("-----------------------------------------------")
                });

            _legsActuationSegmentCommander.Setup(mock => mock.ProvideTelemetry())
                .Returns(new List<TelemetryMessage>
                {
                    new TelemetryMessage("--- Legs Actuation Segment Commander Config ---"),
                    new TelemetryMessage("-----------------------------------------------")
                });

            _flapsActuationSegmentCommander.Setup(mock => mock.ProvideTelemetry())
                .Returns(new List<TelemetryMessage>
                {
                    new TelemetryMessage("--- Flaps Actuation Segment Commander Config ---"),
                    new TelemetryMessage("------------------------------------------------")
                });

            _mainEnginesGimbalSegmentCommander.Setup(mock => mock.ProvideTelemetry())
                .Returns(new List<TelemetryMessage>
                {
                    new TelemetryMessage("--- Main Engines Gimbal Segment Commander Config ---"),
                    new TelemetryMessage("----------------------------------------------------")
                });

            _mainEnginesThrottleSegmentCommander.Setup(mock => mock.ProvideTelemetry())
                .Returns(new List<TelemetryMessage>
                {
                    new TelemetryMessage("--- Main Engines Throttle Segment Commander Config ---"),
                    new TelemetryMessage("------------------------------------------------------")
                });

            // THEN
            var expectedTelemetry = new List<TelemetryMessage>
            {
                new TelemetryMessage("--- Rcs Activation Segment Commander Config ---"),
                new TelemetryMessage("-----------------------------------------------"),
                new TelemetryMessage("--- Legs Actuation Segment Commander Config ---"),
                new TelemetryMessage("-----------------------------------------------"),
                new TelemetryMessage("--- Flaps Actuation Segment Commander Config ---"),
                new TelemetryMessage("------------------------------------------------"),
                new TelemetryMessage("--- Main Engines Gimbal Segment Commander Config ---"),
                new TelemetryMessage("----------------------------------------------------"),
                new TelemetryMessage("--- Main Engines Throttle Segment Commander Config ---"),
                new TelemetryMessage("------------------------------------------------------")
            };

            Assert.That(_flightSegmentCommander.ProvideTelemetry(), Is.EqualTo(expectedTelemetry));
        }

        [Test]
        public void Should_provide_a_equality_by_value_method()
        {
            // GIVEN
            var flightSegmentHandoverDeciderA = new Mock<IFlightSegmentHandoverDecider>();
            var rcsActivationSegmentCommanderA = new Mock<IRcsActivationSegmentCommander>();
            var legsActuationSegmentCommanderA = new Mock<ILegsActuationSegmentCommander>();
            var flapsActuationSegmentCommanderA = new Mock<IFlapsActuationSegmentCommander>();
            var mainEnginesGimbalSegmentCommanderA = new Mock<IMainEnginesGimbalSegmentCommander>();
            var mainEnginesThrottleSegmentCommanderA = new Mock<IMainEnginesThrottleSegmentCommander>();

            var flightSegmentHandoverDeciderC = new Mock<IFlightSegmentHandoverDecider>();
            var rcsActivationSegmentCommanderC = new Mock<IRcsActivationSegmentCommander>();
            var legsActuationSegmentCommanderC = new Mock<ILegsActuationSegmentCommander>();
            var flapsActuationSegmentCommanderC = new Mock<IFlapsActuationSegmentCommander>();
            var mainEnginesGimbalSegmentCommanderC = new Mock<IMainEnginesGimbalSegmentCommander>();
            var mainEnginesThrottleSegmentCommanderC = new Mock<IMainEnginesThrottleSegmentCommander>();

            var flightSegmentCommanderA = new FlightSegmentCommander(
                flightSegmentHandoverDeciderA.Object,
                rcsActivationSegmentCommanderA.Object,
                legsActuationSegmentCommanderA.Object,
                flapsActuationSegmentCommanderA.Object,
                mainEnginesGimbalSegmentCommanderA.Object,
                mainEnginesThrottleSegmentCommanderA.Object);

            var flightSegmentCommanderB = new FlightSegmentCommander(
                flightSegmentHandoverDeciderA.Object,
                rcsActivationSegmentCommanderA.Object,
                legsActuationSegmentCommanderA.Object,
                flapsActuationSegmentCommanderA.Object,
                mainEnginesGimbalSegmentCommanderA.Object,
                mainEnginesThrottleSegmentCommanderA.Object);

            var flightSegmentCommanderC = new FlightSegmentCommander(
                flightSegmentHandoverDeciderC.Object,
                rcsActivationSegmentCommanderC.Object,
                legsActuationSegmentCommanderC.Object,
                flapsActuationSegmentCommanderC.Object,
                mainEnginesGimbalSegmentCommanderC.Object,
                mainEnginesThrottleSegmentCommanderC.Object);

            // THEN
            Assert.That(flightSegmentCommanderA.Equals(flightSegmentCommanderB), Is.True);
            Assert.That(flightSegmentCommanderA.Equals(flightSegmentCommanderC), Is.False);
        }
    }
}