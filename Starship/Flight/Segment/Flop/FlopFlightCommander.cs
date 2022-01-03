using Starship.Flight.Command;
using Starship.Flight.Command.Actuation.Engine;
using Starship.Flight.Command.Actuation.Flap;
using Starship.Flight.Command.Throttle.Main;
using Starship.Flight.Command.Throttle.Rcs;
using Starship.Sensor;
using Starship.Utility.Timing.Units;

namespace Starship.Flight.Segment.Flop
{
    // Currently under development
    public sealed class FlopFlightCommander : FlightSegmentCommander
    {
        public FlopFlightCommander() : base(new Seconds(17L))
        {
        }

        public override ICommandSuite CommandFlight(ISensorSuite sensorSuite)
        {
            // Pitch/roll/yaw must be done at the same time (with priority?)

            // Max Pitch Forward ->
            // ActuateTopLeftFlapCommand(0.0F),
            // ActuateTopRightFlapCommand(0.0F)
            // ActuateBottomLeftFlapCommand(1.0F)
            // ActuateBottomRightFlapCommand(1.0F)

            // Max Pitch Backward ->
            // ActuateTopLeftFlapCommand(1.0F),
            // ActuateTopRightFlapCommand(1.0F)
            // ActuateBottomLeftFlapCommand(0.0F)
            // ActuateBottomRightFlapCommand(0.0F)

            // Max Roll To Left ->
            // ActuateTopLeftFlapCommand(0.0F),
            // ActuateTopRightFlapCommand(1.0F)
            // ActuateBottomLeftFlapCommand(0.0F)
            // ActuateBottomRightFlapCommand(1.0F)

            // Max Roll To Right ->
            // ActuateTopLeftFlapCommand(1.0F),
            // ActuateTopRightFlapCommand(0.0F)
            // ActuateBottomLeftFlapCommand(1.0F)
            // ActuateBottomRightFlapCommand(0.0F)

            // Max Yaw To Left ->
            // ActuateTopLeftFlapCommand(1.0F),
            // ActuateTopRightFlapCommand(0.0F)
            // ActuateBottomLeftFlapCommand(0.0F)
            // ActuateBottomRightFlapCommand(1.0F)

            // Max Yaw To Right ->
            // ActuateTopLeftFlapCommand(0.0F),
            // ActuateTopRightFlapCommand(1.0F)
            // ActuateBottomLeftFlapCommand(1.0F)
            // ActuateBottomRightFlapCommand(0.0F)

            return new CommandSuite(
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
                new ActuateTopLeftFlapCommand(0.5F),
                new ActuateTopRightFlapCommand(0.5F),
                new ActuateBottomLeftFlapCommand(0.5F),
                new ActuateBottomRightFlapCommand(0.5F));
        }
    }
}