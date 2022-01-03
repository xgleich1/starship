using Starship.Flight.Command;
using Starship.Flight.Command.Actuation.Engine;
using Starship.Flight.Command.Actuation.Flap;
using Starship.Flight.Command.Throttle.Main;
using Starship.Flight.Command.Throttle.Rcs;
using Starship.Sensor;
using Starship.Utility.Timing.Units;

namespace Starship.Flight.Segment.Flip
{
    // Currently under development
    public sealed class FlipFlightCommander : FlightSegmentCommander
    {
        private readonly FlipAttitudeRegulator _yawRegulator =
            new FlipAttitudeRegulator();
        private readonly FlipAttitudeRegulator _rollRegulator =
            new FlipAttitudeRegulator();
        private readonly FlipAttitudeRegulator _pitchRegulator =
            new FlipAttitudeRegulator();


        public FlipFlightCommander() : base(new Seconds(15L))
        {
        }

        public override ICommandSuite CommandFlight(ISensorSuite sensorSuite)
        {
            var currentYawAngleInDegrees = sensorSuite.YawSensor.YawAngleInDegrees;
            var currentRollAngleInDegrees = sensorSuite.RollSensor.RollAngleInDegrees;
            var currentPitchAngleInDegrees = sensorSuite.PitchSensor.PitchAngleInDegrees;

            const float desiredYawAngleInDegrees = 90.0F;
            const float desiredRollAngleInDegrees = 90.0F;
            const float desiredPitchAngleInDegrees = 0.0F;

            var yawPercent = _yawRegulator
                .RegulateValue(currentYawAngleInDegrees, desiredYawAngleInDegrees);
            var rollPercent = _rollRegulator
                .RegulateValue(currentRollAngleInDegrees, desiredRollAngleInDegrees);
            var pitchPercent = _pitchRegulator
                .RegulateValue(currentPitchAngleInDegrees, desiredPitchAngleInDegrees);

            return new CommandSuite(
                new ThrottleTopLeftRcsEngineCommand(0.0F),
                new ThrottleTopRightRcsEngineCommand(0.0F),
                new ThrottleBottomLeftRcsEngineCommand(0.0F),
                new ThrottleBottomRightRcsEngineCommand(0.0F),
                new ThrottleTopMainEngineCommand(1.0F),
                new ThrottleBottomLeftMainEngineCommand(1.0F),
                new ThrottleBottomRightMainEngineCommand(1.0F),
                new YawMainEnginesCommand(yawPercent),
                new RollMainEnginesCommand(rollPercent),
                new PitchMainEnginesCommand(pitchPercent),
                new ActuateTopLeftFlapCommand(1.0F),
                new ActuateTopRightFlapCommand(1.0F),
                new ActuateBottomLeftFlapCommand(0.0F),
                new ActuateBottomRightFlapCommand(0.0F));
        }
    }
}