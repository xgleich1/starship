using Starship.Control;
using Starship.Flight.Command;
using Starship.Flight.Command.Attitude;
using Starship.Flight.Command.Throttle.Main;
using Starship.Flight.Command.Throttle.Rcs;
using Starship.Flight.Stabilization;
using Starship.Mission;
using Starship.Sensor;
using Starship.Telemetry;

namespace Starship.Flight
{
    // Currently under development
    public sealed class FlightCommander
    {
        private readonly IMissionTimer _missionTimer;
        private readonly ITelemetryEmitter _telemetryEmitter;

        private readonly AttitudeStabilizer _yawStabilizer = new AttitudeStabilizer();
        private readonly AttitudeStabilizer _rollStabilizer = new AttitudeStabilizer();
        private readonly AttitudeStabilizer _pitchStabilizer = new AttitudeStabilizer();

        private bool _missionStarted;


        public FlightCommander(
            IMissionTimer missionTimer,
            ITelemetryEmitter telemetryEmitter)
        {
            _missionTimer = missionTimer;
            _telemetryEmitter = telemetryEmitter;
        }

        public void CommandFlight(
            ISensorSuite sensorSuite,
            IControlSuite controlSuite)
        {
            // Do certain things only once.
            // This will become a state machine
            if (!_missionStarted)
            {
                _missionTimer.StartWithZeroSeconds();

                _missionStarted = true;
            }

            _telemetryEmitter.EmitTelemetry(sensorSuite);

            var commandSuite = CommandStableAscent(sensorSuite);

            _telemetryEmitter.EmitTelemetry(commandSuite);

            controlSuite.ExertControl(commandSuite);
        }

        private ICommandSuite CommandStableAscent(ISensorSuite sensorSuite)
        {
            var currentYawAngleInDegrees = sensorSuite.YawSensor.YawAngleInDegrees;
            var currentRollAngleInDegrees = sensorSuite.RollSensor.RollAngleInDegrees;
            var currentPitchAngleInDegrees = sensorSuite.PitchSensor.PitchAngleInDegrees;

            const float desiredYawAngleInDegrees = 90F;
            const float desiredRollAngleInDegrees = 90F;
            const float desiredPitchAngleInDegrees = 90F;

            var yawInput = _yawStabilizer
                .CalculateAttitudeInput(currentYawAngleInDegrees, desiredYawAngleInDegrees);
            var rollInput = _rollStabilizer
                .CalculateAttitudeInput(currentRollAngleInDegrees, desiredRollAngleInDegrees);
            var pitchInput = _pitchStabilizer
                .CalculateAttitudeInput(currentPitchAngleInDegrees, desiredPitchAngleInDegrees);

            return new CommandSuite(
                new TopLeftRcsEngineThrottleCommand(0.0F),
                new TopRightRcsEngineThrottleCommand(0.0F),
                new BottomLeftRcsEngineThrottleCommand(0.0F),
                new BottomRightRcsEngineThrottleCommand(0.0F),
                new TopMainEngineThrottleCommand(0.75F),
                new BottomLeftMainEngineThrottleCommand(0.75F),
                new BottomRightMainEngineThrottleCommand(0.75F),
                new MainEngineAttitudeYawCommand(yawInput),
                new MainEngineAttitudeRollCommand(rollInput),
                new MainEngineAttitudePitchCommand(pitchInput));
        }
    }
}