using System.Collections.Generic;
using Starship.Flight.Command.Actuation.Engine;
using Starship.Flight.Command.Actuation.Flap;
using Starship.Flight.Command.Actuation.Leg;
using Starship.Flight.Command.Throttle.Main;
using Starship.Telemetry;

namespace Starship.Flight.Command
{
    public readonly struct CommandSuite : ICommandSuite
    {
        public LegsActuationCommand LegsActuationCommand { get; }
        public TopLeftFlapActuationCommand TopLeftFlapActuationCommand { get; }
        public TopRightFlapActuationCommand TopRightFlapActuationCommand { get; }
        public BottomLeftFlapActuationCommand BottomLeftFlapActuationCommand { get; }
        public BottomRightFlapActuationCommand BottomRightFlapActuationCommand { get; }
        public MainEnginesYawCommand MainEnginesYawCommand { get; }
        public MainEnginesRollCommand MainEnginesRollCommand { get; }
        public MainEnginesPitchCommand MainEnginesPitchCommand { get; }
        public TopMainEngineThrottleCommand TopMainEngineThrottleCommand { get; }
        public BottomLeftMainEngineThrottleCommand BottomLeftMainEngineThrottleCommand { get; }
        public BottomRightMainEngineThrottleCommand BottomRightMainEngineThrottleCommand { get; }


        public CommandSuite(
            LegsActuationCommand legsActuationCommand,
            TopLeftFlapActuationCommand topLeftFlapActuationCommand,
            TopRightFlapActuationCommand topRightFlapActuationCommand,
            BottomLeftFlapActuationCommand bottomLeftFlapActuationCommand,
            BottomRightFlapActuationCommand bottomRightFlapActuationCommand,
            MainEnginesYawCommand mainEnginesYawCommand,
            MainEnginesRollCommand mainEnginesRollCommand,
            MainEnginesPitchCommand mainEnginesPitchCommand,
            TopMainEngineThrottleCommand topMainEngineThrottleCommand,
            BottomLeftMainEngineThrottleCommand bottomLeftMainEngineThrottleCommand,
            BottomRightMainEngineThrottleCommand bottomRightMainEngineThrottleCommand)
        {
            LegsActuationCommand = legsActuationCommand;
            TopLeftFlapActuationCommand = topLeftFlapActuationCommand;
            TopRightFlapActuationCommand = topRightFlapActuationCommand;
            BottomLeftFlapActuationCommand = bottomLeftFlapActuationCommand;
            BottomRightFlapActuationCommand = bottomRightFlapActuationCommand;
            MainEnginesYawCommand = mainEnginesYawCommand;
            MainEnginesRollCommand = mainEnginesRollCommand;
            MainEnginesPitchCommand = mainEnginesPitchCommand;
            TopMainEngineThrottleCommand = topMainEngineThrottleCommand;
            BottomLeftMainEngineThrottleCommand = bottomLeftMainEngineThrottleCommand;
            BottomRightMainEngineThrottleCommand = bottomRightMainEngineThrottleCommand;
        }

        public IEnumerable<TelemetryMessage> ProvideTelemetry()
        {
            var telemetry = new List<TelemetryMessage>();

            telemetry.AddRange(LegsActuationCommand.ProvideTelemetry());
            telemetry.AddRange(TopLeftFlapActuationCommand.ProvideTelemetry());
            telemetry.AddRange(TopRightFlapActuationCommand.ProvideTelemetry());
            telemetry.AddRange(BottomLeftFlapActuationCommand.ProvideTelemetry());
            telemetry.AddRange(BottomRightFlapActuationCommand.ProvideTelemetry());
            telemetry.AddRange(MainEnginesYawCommand.ProvideTelemetry());
            telemetry.AddRange(MainEnginesRollCommand.ProvideTelemetry());
            telemetry.AddRange(MainEnginesPitchCommand.ProvideTelemetry());
            telemetry.AddRange(TopMainEngineThrottleCommand.ProvideTelemetry());
            telemetry.AddRange(BottomLeftMainEngineThrottleCommand.ProvideTelemetry());
            telemetry.AddRange(BottomRightMainEngineThrottleCommand.ProvideTelemetry());

            return telemetry;
        }
    }
}