using Starship.Flight.Command;
using Starship.Flight.Command.Actuation.Engine;
using Starship.Flight.Command.Actuation.Flap;
using Starship.Flight.Command.Throttle.Main;
using Starship.Flight.Command.Throttle.Rcs;
using Starship.Sensor;
using Starship.Utility.Timing.Units;

namespace Starship.Flight.Segment.Ascent
{
    // Currently under development
    public sealed class AscentFlightCommander : FlightSegmentCommander
    {
        private readonly AscentAttitudeRegulator _yawRegulator =
            new AscentAttitudeRegulator();
        private readonly AscentAttitudeRegulator _rollRegulator =
            new AscentAttitudeRegulator();
        private readonly AscentAttitudeRegulator _pitchRegulator =
            new AscentAttitudeRegulator();


        public AscentFlightCommander() : base(new Seconds(0L))
        {
        }

        public override ICommandSuite CommandFlight(ISensorSuite sensorSuite)
        {
            var currentYawAngleInDegrees = sensorSuite.YawSensor.YawAngleInDegrees;
            var currentRollAngleInDegrees = sensorSuite.RollSensor.RollAngleInDegrees;
            var currentPitchAngleInDegrees = sensorSuite.PitchSensor.PitchAngleInDegrees;

            const float desiredYawAngleInDegrees = 90.0F;
            const float desiredRollAngleInDegrees = 90.0F;
            const float desiredPitchAngleInDegrees = 90.0F;

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
                new ThrottleTopMainEngineCommand(0.75F),
                new ThrottleBottomLeftMainEngineCommand(0.75F),
                new ThrottleBottomRightMainEngineCommand(0.75F),
                new YawMainEnginesCommand(yawPercent),
                new RollMainEnginesCommand(rollPercent),
                new PitchMainEnginesCommand(pitchPercent),
                new ActuateTopLeftFlapCommand(1.0F),
                new ActuateTopRightFlapCommand(1.0F),
                new ActuateBottomLeftFlapCommand(1.0F),
                new ActuateBottomRightFlapCommand(1.0F));
        }
    }
}