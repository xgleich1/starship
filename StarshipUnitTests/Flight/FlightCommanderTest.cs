using Moq;
using NUnit.Framework;
using Starship.Control;
using Starship.Flight;
using Starship.Flight.Command;
using Starship.Flight.Segment;
using Starship.Mission;
using Starship.Sensor;
using Starship.Telemetry;

namespace StarshipUnitTests.Flight
{
    public sealed class FlightCommanderTest
    {
        private Mock<IMissionTimer> _missionTimer;
        private Mock<ITelemetryEmitter> _telemetryEmitter;
        private Mock<IFlightSegmentCommander> _flightSegmentCommander;
        private Mock<IFlightSegmentCommanders> _flightSegmentCommanders;
        private FlightCommander _flightCommander;

        private Mock<ISensorSuite> _sensorSuite;
        private Mock<IControlSuite> _controlSuite;
        private Mock<ICommandSuite> _commandSuite;


        [SetUp]
        public void Setup()
        {
            _missionTimer = new Mock<IMissionTimer>();
            _telemetryEmitter = new Mock<ITelemetryEmitter>();
            _flightSegmentCommander = new Mock<IFlightSegmentCommander>();
            _flightSegmentCommanders = new Mock<IFlightSegmentCommanders>();
            _flightCommander = new FlightCommander(
                _missionTimer.Object,
                _telemetryEmitter.Object,
                _flightSegmentCommanders.Object);

            _sensorSuite = new Mock<ISensorSuite>();
            _controlSuite = new Mock<IControlSuite>();
            _commandSuite = new Mock<ICommandSuite>();
        }

        [Test]
        public void Should_start_the_mission_timer_when_starting_a_flight()
        {
            // GIVEN
            SetupMissionTimerIsRunning(false);

            SetupCurrentFlightSegmentCommander(_flightSegmentCommander.Object);

            // WHEN
            _flightCommander.CommandFlight(_sensorSuite.Object, _controlSuite.Object);

            // THEN
            _missionTimer.Verify(mock => mock.StartWithZeroSeconds());
        }

        [Test]
        public void Should_start_the_mission_timer_only_once_in_a_flight()
        {
            // GIVEN
            SetupMissionTimerIsRunning(true);

            SetupCurrentFlightSegmentCommander(_flightSegmentCommander.Object);

            // WHEN
            _flightCommander.CommandFlight(_sensorSuite.Object, _controlSuite.Object);

            // THEN
            _missionTimer.Verify(mock => mock.StartWithZeroSeconds(), Times.Never());
        }

        [Test]
        public void Should_emit_the_telemetry_of_the_current_sensor_output()
        {
            // GIVEN
            SetupCurrentFlightSegmentCommander(_flightSegmentCommander.Object);

            // WHEN
            _flightCommander.CommandFlight(_sensorSuite.Object, _controlSuite.Object);

            // THEN
            _telemetryEmitter.Verify(mock => mock.EmitTelemetry(_sensorSuite.Object));
        }

        [Test]
        public void Should_emit_the_telemetry_of_the_current_flight_segment_commander()
        {
            // GIVEN
            SetupCurrentFlightSegmentCommander(_flightSegmentCommander.Object);

            // WHEN
            _flightCommander.CommandFlight(_sensorSuite.Object, _controlSuite.Object);

            // THEN
            _telemetryEmitter.Verify(mock => mock.EmitTelemetry(_flightSegmentCommander.Object));
        }

        [Test]
        public void Should_emit_the_telemetry_of_the_current_flight_segment_commanders_commands()
        {
            // GIVEN
            SetupCurrentFlightSegmentCommands(_commandSuite.Object);

            SetupCurrentFlightSegmentCommander(_flightSegmentCommander.Object);

            // WHEN
            _flightCommander.CommandFlight(_sensorSuite.Object, _controlSuite.Object);

            // THEN
            _telemetryEmitter.Verify(mock => mock.EmitTelemetry(_commandSuite.Object));
        }

        [Test]
        public void Should_control_the_flight_with_the_current_flight_segment_commanders_commands()
        {
            // GIVEN
            SetupCurrentFlightSegmentCommands(_commandSuite.Object);

            SetupCurrentFlightSegmentCommander(_flightSegmentCommander.Object);

            // WHEN
            _flightCommander.CommandFlight(_sensorSuite.Object, _controlSuite.Object);

            // THEN
            _controlSuite.Verify(mock => mock.ExertControl(_commandSuite.Object));
        }

        private void SetupMissionTimerIsRunning(bool isRunning) =>
            _missionTimer.Setup(
                mock => mock.IsRunning
            ).Returns(isRunning);

        private void SetupCurrentFlightSegmentCommands(ICommandSuite commandSuite) =>
            _flightSegmentCommander.Setup(
                mock => mock.CommandFlight(_sensorSuite.Object)
            ).Returns(commandSuite);

        private void SetupCurrentFlightSegmentCommander(IFlightSegmentCommander flightSegmentCommander) =>
            _flightSegmentCommanders.Setup(
                mock => mock.GetCurrentFlightSegmentCommander()
            ).Returns(flightSegmentCommander);
    }
}