using Starship.Flight.Command;
using Starship.Flight.Command.Actuation.Engine;
using Starship.Flight.Command.Actuation.Flap;
using Starship.Flight.Command.Throttle.Main;
using Starship.Sensor;
using Starship.Utility.Timing.Units;

namespace Starship.Flight.Segment.Ascent
{
    // Currently under development
    public sealed class AscentFlightCommander : FlightSegmentCommander
    {
        private readonly AscentAttitudeRegulator _yawRegulator = new AscentAttitudeRegulator();
        private readonly AscentAttitudeRegulator _rollRegulator = new AscentAttitudeRegulator();
        private readonly AscentAttitudeRegulator _pitchRegulator = new AscentAttitudeRegulator();


        public AscentFlightCommander() : base(new Seconds(0L))
        {
        }

        public override ICommandSuite CommandFlight(ISensorSuite sensorSuite)
        {
            var currentYawAngleInDegrees = sensorSuite.AttitudeSensor.YawAngleInDegrees;
            var currentRollAngleInDegrees = sensorSuite.AttitudeSensor.RollAngleInDegrees;
            var currentPitchAngleInDegrees = sensorSuite.AttitudeSensor.PitchAngleInDegrees;

            const float desiredYawAngleInDegrees = 0.0F;
            const float desiredRollAngleInDegrees = 0.0F;
            const float desiredPitchAngleInDegrees = 0.0F;

            var yawPercent = _yawRegulator
                .RegulateValue(currentYawAngleInDegrees, desiredYawAngleInDegrees);
            var rollPercent = _rollRegulator
                .RegulateValue(currentRollAngleInDegrees, desiredRollAngleInDegrees);
            var pitchPercent = _pitchRegulator
                .RegulateValue(currentPitchAngleInDegrees, desiredPitchAngleInDegrees);

            return new CommandSuite(
                new ThrottleTopMainEngineCommand(0.25F),
                new ThrottleBottomLeftMainEngineCommand(0.25F),
                new ThrottleBottomRightMainEngineCommand(0.25F),
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