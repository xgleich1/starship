using Starship.Flight.Command;
using Starship.Flight.Command.Actuation.Engine;
using Starship.Flight.Command.Actuation.Flap;
using Starship.Flight.Command.Throttle.Main;
using Starship.Sensor;
using Starship.Utility.Timing.Units;

namespace Starship.Flight.Segment.Flip
{
    // Currently under development
    public sealed class FlipFlightCommander : FlightSegmentCommander
    {
        private readonly FlipAttitudeRegulator _yawRegulator = new FlipAttitudeRegulator();
        private readonly FlipAttitudeRegulator _rollRegulator = new FlipAttitudeRegulator();
        private readonly FlipAttitudeRegulator _pitchRegulator = new FlipAttitudeRegulator();


        public FlipFlightCommander() : base(new Seconds(30L))
        {
        }

        public override ICommandSuite CommandFlight(ISensorSuite sensorSuite)
        {
            var currentYawAngleInDegrees = sensorSuite.AttitudeSensor.YawAngleInDegrees;
            var currentRollAngleInDegrees = sensorSuite.AttitudeSensor.RollAngleInDegrees;
            var currentPitchAngleInDegrees = sensorSuite.AttitudeSensor.PitchAngleInDegrees;

            const float desiredYawAngleInDegrees = 0.0F;
            const float desiredRollAngleInDegrees = 0.0F;
            const float desiredPitchAngleInDegrees = -90.0F;

            var yawPercent = _yawRegulator
                .RegulateValue(currentYawAngleInDegrees, desiredYawAngleInDegrees);
            var rollPercent = _rollRegulator
                .RegulateValue(currentRollAngleInDegrees, desiredRollAngleInDegrees);
            var pitchPercent = _pitchRegulator
                .RegulateValue(currentPitchAngleInDegrees, desiredPitchAngleInDegrees);

            return new CommandSuite(
                new ThrottleTopMainEngineCommand(0.15F),
                new ThrottleBottomLeftMainEngineCommand(0.10F),
                new ThrottleBottomRightMainEngineCommand(0.10F),
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