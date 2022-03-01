using Starship.Flight.Command;
using Starship.Flight.Command.Actuation.Engine;
using Starship.Flight.Command.Actuation.Flap;
using Starship.Flight.Command.Throttle.Main;
using Starship.Sensor;
using Starship.Utility.Math;
using Starship.Utility.Timing.Units;

namespace Starship.Flight.Segment.Flop
{
    // Currently under development
    public sealed class FlopFlightCommander : FlightSegmentCommander
    {
        private readonly FlopAttitudeRegulator _yawRegulator = new FlopAttitudeRegulator();
        private readonly FlopAttitudeRegulator _rollRegulator = new FlopAttitudeRegulator();
        private readonly FlopAttitudeRegulator _pitchRegulator = new FlopAttitudeRegulator();

        public FlopFlightCommander() : base(new Seconds(32L))
        {
        }

        public override ICommandSuite CommandFlight(ISensorSuite sensorSuite)
        {
            // Pitch angle starts with 0.
            // Positive pitch: To the back, pitch angle getting more.
            // Negative pitch: To the front, pitch angle getting less.

            // Max Pitch Forward (-0.5F) ->
            // ActuateTopLeftFlapCommand(0.0F),
            // ActuateTopRightFlapCommand(0.0F)
            // ActuateBottomLeftFlapCommand(1.0F)
            // ActuateBottomRightFlapCommand(1.0F)

            // Max Pitch Backward (+0.5) ->
            // ActuateTopLeftFlapCommand(1.0F),
            // ActuateTopRightFlapCommand(1.0F)
            // ActuateBottomLeftFlapCommand(0.0F)
            // ActuateBottomRightFlapCommand(0.0F)

            var currentPitchAngleInDegrees = sensorSuite.AttitudeSensor.PitchAngleInDegrees;

            const float desiredPitchAngleInDegrees = -90.0F;

            var pitchPercent = _pitchRegulator
                .RegulateValue(currentPitchAngleInDegrees, desiredPitchAngleInDegrees);

            // Roll angle starts with 0.
            // Positive roll: With the clock (right), roll angle getting more.
            // Negative roll: Against the clock (left), roll angle getting less.

            // Max Roll To Right (with the clock) (0.5F) ->
            // ActuateTopLeftFlapCommand(1.0F),
            // ActuateTopRightFlapCommand(0.0F)
            // ActuateBottomLeftFlapCommand(1.0F)
            // ActuateBottomRightFlapCommand(0.0F)

            // Max Roll To Left (against the clock) (-0.5F) ->
            // ActuateTopLeftFlapCommand(0.0F),
            // ActuateTopRightFlapCommand(1.0F)
            // ActuateBottomLeftFlapCommand(0.0F)
            // ActuateBottomRightFlapCommand(1.0F)

            var currentRollAngleInDegrees = sensorSuite.AttitudeSensor.RollAngleInDegrees;

            const float desiredRollAngleInDegrees = 0.0F;

            var rollPercent = _rollRegulator
                .RegulateValue(currentRollAngleInDegrees, desiredRollAngleInDegrees);

            // Yaw angle starts with 0.
            // Positive yaw: To the right with yaw angle getting more.
            // Negative yaw: To The left with yaw angle getting less.

            // Max Yaw To Left (-0.5F) 
            // ActuateTopLeftFlapCommand(0.0F),
            // ActuateTopRightFlapCommand(1.0F)
            // ActuateBottomLeftFlapCommand(1.0F)
            // ActuateBottomRightFlapCommand(0.0F)

            // Max Yaw To Right (0.5F) ->
            // ActuateTopLeftFlapCommand(1.0F),
            // ActuateTopRightFlapCommand(0.0F)
            // ActuateBottomLeftFlapCommand(0.0F)
            // ActuateBottomRightFlapCommand(1.0F)

            var currentYawAngleInDegrees = sensorSuite.AttitudeSensor.YawAngleInDegrees;

            const float desiredYawAngleInDegrees = 0.0F;

            var yawPercent = _yawRegulator
                .RegulateValue(currentYawAngleInDegrees, desiredYawAngleInDegrees);

            return new CommandSuite(
                new ThrottleTopMainEngineCommand(0.0F),
                new ThrottleBottomLeftMainEngineCommand(0.0F),
                new ThrottleBottomRightMainEngineCommand(0.0F),
                new YawMainEnginesCommand(0.0F),
                new RollMainEnginesCommand(0.0F),
                new PitchMainEnginesCommand(0.0F),
                new ActuateTopLeftFlapCommand((0.5F + yawPercent + rollPercent + pitchPercent).Clamp(0.0F, 1.0F)),
                new ActuateTopRightFlapCommand((0.5F - yawPercent - rollPercent + pitchPercent).Clamp(0.0F, 1.0F)),
                new ActuateBottomLeftFlapCommand((0.5F - yawPercent + rollPercent - pitchPercent).Clamp(0.0F, 1.0F)),
                new ActuateBottomRightFlapCommand((0.5F + yawPercent - rollPercent - pitchPercent).Clamp(0.0F, 1.0F)));
        }

        // Pitch
        // new ActuateTopLeftFlapCommand((0.5F + pitchPercent).Clamp(0.0F, 1.0F)),
        // new ActuateTopRightFlapCommand((0.5F + pitchPercent).Clamp(0.0F, 1.0F)),
        // new ActuateBottomLeftFlapCommand((0.5F - pitchPercent).Clamp(0.0F, 1.0F)),
        // new ActuateBottomRightFlapCommand((0.5F - pitchPercent).Clamp(0.0F, 1.0F)));

        // Roll + Pitch
        // new ActuateTopLeftFlapCommand((0.5F + rollPercent + pitchPercent).Clamp(0.0F, 1.0F)),
        // new ActuateTopRightFlapCommand((0.5F - rollPercent + pitchPercent).Clamp(0.0F, 1.0F)),
        // new ActuateBottomLeftFlapCommand((0.5F + rollPercent - pitchPercent).Clamp(0.0F, 1.0F)),
        // new ActuateBottomRightFlapCommand((0.5F - rollPercent - pitchPercent).Clamp(0.0F, 1.0F)));

        // Yaw + Roll + Pitch
        // new ActuateTopLeftFlapCommand((0.5F + yawPercent + rollPercent + pitchPercent).Clamp(0.0F, 1.0F)),
        // new ActuateTopRightFlapCommand((0.5F - yawPercent - rollPercent + pitchPercent).Clamp(0.0F, 1.0F)),
        // new ActuateBottomLeftFlapCommand((0.5F - yawPercent + rollPercent - pitchPercent).Clamp(0.0F, 1.0F)),
        // new ActuateBottomRightFlapCommand((0.5F + yawPercent - rollPercent - pitchPercent).Clamp(0.0F, 1.0F)));
    }
}