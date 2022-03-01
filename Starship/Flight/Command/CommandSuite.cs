using System.Collections.Generic;
using Starship.Flight.Command.Actuation.Engine;
using Starship.Flight.Command.Actuation.Flap;
using Starship.Flight.Command.Throttle.Main;
using Starship.Telemetry;

namespace Starship.Flight.Command
{
    public sealed class CommandSuite : ICommandSuite
    {
        public ThrottleTopMainEngineCommand ThrottleTopMainEngineCommand { get; }
        public ThrottleBottomLeftMainEngineCommand ThrottleBottomLeftMainEngineCommand { get; }
        public ThrottleBottomRightMainEngineCommand ThrottleBottomRightMainEngineCommand { get; }
        public YawMainEnginesCommand YawMainEnginesCommand { get; }
        public RollMainEnginesCommand RollMainEnginesCommand { get; }
        public PitchMainEnginesCommand PitchMainEnginesCommand { get; }
        public ActuateTopLeftFlapCommand ActuateTopLeftFlapCommand { get; }
        public ActuateTopRightFlapCommand ActuateTopRightFlapCommand { get; }
        public ActuateBottomLeftFlapCommand ActuateBottomLeftFlapCommand { get; }
        public ActuateBottomRightFlapCommand ActuateBottomRightFlapCommand { get; }


        public CommandSuite(
            ThrottleTopMainEngineCommand throttleTopMainEngineCommand,
            ThrottleBottomLeftMainEngineCommand throttleBottomLeftMainEngineCommand,
            ThrottleBottomRightMainEngineCommand throttleBottomRightMainEngineCommand,
            YawMainEnginesCommand yawMainEnginesCommand,
            RollMainEnginesCommand rollMainEnginesCommand,
            PitchMainEnginesCommand pitchMainEnginesCommand,
            ActuateTopLeftFlapCommand actuateTopLeftFlapCommand,
            ActuateTopRightFlapCommand actuateTopRightFlapCommand,
            ActuateBottomLeftFlapCommand actuateBottomLeftFlapCommand,
            ActuateBottomRightFlapCommand actuateBottomRightFlapCommand)
        {
            ThrottleTopMainEngineCommand = throttleTopMainEngineCommand;
            ThrottleBottomLeftMainEngineCommand = throttleBottomLeftMainEngineCommand;
            ThrottleBottomRightMainEngineCommand = throttleBottomRightMainEngineCommand;
            YawMainEnginesCommand = yawMainEnginesCommand;
            RollMainEnginesCommand = rollMainEnginesCommand;
            PitchMainEnginesCommand = pitchMainEnginesCommand;
            ActuateTopLeftFlapCommand = actuateTopLeftFlapCommand;
            ActuateTopRightFlapCommand = actuateTopRightFlapCommand;
            ActuateBottomLeftFlapCommand = actuateBottomLeftFlapCommand;
            ActuateBottomRightFlapCommand = actuateBottomRightFlapCommand;
        }

        public IEnumerable<TelemetryMessage> ProvideTelemetry()
        {
            var telemetry = new List<TelemetryMessage>();

            telemetry.AddRange(ThrottleTopMainEngineCommand.ProvideTelemetry());
            telemetry.AddRange(ThrottleBottomLeftMainEngineCommand.ProvideTelemetry());
            telemetry.AddRange(ThrottleBottomRightMainEngineCommand.ProvideTelemetry());
            telemetry.AddRange(YawMainEnginesCommand.ProvideTelemetry());
            telemetry.AddRange(RollMainEnginesCommand.ProvideTelemetry());
            telemetry.AddRange(PitchMainEnginesCommand.ProvideTelemetry());
            telemetry.AddRange(ActuateTopLeftFlapCommand.ProvideTelemetry());
            telemetry.AddRange(ActuateTopRightFlapCommand.ProvideTelemetry());
            telemetry.AddRange(ActuateBottomLeftFlapCommand.ProvideTelemetry());
            telemetry.AddRange(ActuateBottomRightFlapCommand.ProvideTelemetry());

            return telemetry;
        }
    }
}