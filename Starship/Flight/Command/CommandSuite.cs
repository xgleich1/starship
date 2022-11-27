using System.Collections.Generic;
using Starship.Flight.Command.Activation.Rcs;
using Starship.Flight.Command.Actuation.Engine;
using Starship.Flight.Command.Actuation.Flap;
using Starship.Flight.Command.Actuation.Leg;
using Starship.Flight.Command.Throttle.Main;
using Starship.Telemetry;

namespace Starship.Flight.Command
{
    public readonly struct CommandSuite : ICommandSuite
    {
        public TopLeftRcsActivationCommand TopLeftRcsActivationCommand { get; }
        public TopRightRcsActivationCommand TopRightRcsActivationCommand { get; }
        public BottomLeftRcsActivationCommand BottomLeftRcsActivationCommand { get; }
        public BottomRightRcsActivationCommand BottomRightRcsActivationCommand { get; }
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
            TopLeftRcsActivationCommand topLeftRcsActivationCommand,
            TopRightRcsActivationCommand topRightRcsActivationCommand,
            BottomLeftRcsActivationCommand bottomLeftRcsActivationCommand,
            BottomRightRcsActivationCommand bottomRightRcsActivationCommand,
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
            TopLeftRcsActivationCommand = topLeftRcsActivationCommand;
            TopRightRcsActivationCommand = topRightRcsActivationCommand;
            BottomLeftRcsActivationCommand = bottomLeftRcsActivationCommand;
            BottomRightRcsActivationCommand = bottomRightRcsActivationCommand;
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

            telemetry.AddRange(TopLeftRcsActivationCommand.ProvideTelemetry());
            telemetry.AddRange(TopRightRcsActivationCommand.ProvideTelemetry());
            telemetry.AddRange(BottomLeftRcsActivationCommand.ProvideTelemetry());
            telemetry.AddRange(BottomRightRcsActivationCommand.ProvideTelemetry());
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