using System.Collections.Generic;
using Starship.Flight.Command.Attitude;
using Starship.Flight.Command.Throttle.Main;
using Starship.Flight.Command.Throttle.Rcs;
using Starship.Telemetry;

namespace Starship.Flight.Command
{
    public sealed class CommandSuite : ICommandSuite
    {
        public TopLeftRcsEngineThrottleCommand TopLeftRcsEngineThrottleCommand { get; }
        public TopRightRcsEngineThrottleCommand TopRightRcsEngineThrottleCommand { get; }
        public BottomLeftRcsEngineThrottleCommand BottomLeftRcsEngineThrottleCommand { get; }
        public BottomRightRcsEngineThrottleCommand BottomRightRcsEngineThrottleCommand { get; }
        public TopMainEngineThrottleCommand TopMainEngineThrottleCommand { get; }
        public BottomLeftMainEngineThrottleCommand BottomLeftMainEngineThrottleCommand { get; }
        public BottomRightMainEngineThrottleCommand BottomRightMainEngineThrottleCommand { get; }
        public MainEngineAttitudeYawCommand MainEngineAttitudeYawCommand { get; }
        public MainEngineAttitudeRollCommand MainEngineAttitudeRollCommand { get; }
        public MainEngineAttitudePitchCommand MainEngineAttitudePitchCommand { get; }


        public CommandSuite(
            TopLeftRcsEngineThrottleCommand topLeftRcsEngineThrottleCommand,
            TopRightRcsEngineThrottleCommand topRightRcsEngineThrottleCommand,
            BottomLeftRcsEngineThrottleCommand bottomLeftRcsEngineThrottleCommand,
            BottomRightRcsEngineThrottleCommand bottomRightRcsEngineThrottleCommand,
            TopMainEngineThrottleCommand topMainEngineThrottleCommand,
            BottomLeftMainEngineThrottleCommand bottomLeftMainEngineThrottleCommand,
            BottomRightMainEngineThrottleCommand bottomRightMainEngineThrottleCommand,
            MainEngineAttitudeYawCommand mainEngineAttitudeYawCommand,
            MainEngineAttitudeRollCommand mainEngineAttitudeRollCommand,
            MainEngineAttitudePitchCommand mainEngineAttitudePitchCommand)
        {
            TopLeftRcsEngineThrottleCommand = topLeftRcsEngineThrottleCommand;
            TopRightRcsEngineThrottleCommand = topRightRcsEngineThrottleCommand;
            BottomLeftRcsEngineThrottleCommand = bottomLeftRcsEngineThrottleCommand;
            BottomRightRcsEngineThrottleCommand = bottomRightRcsEngineThrottleCommand;
            TopMainEngineThrottleCommand = topMainEngineThrottleCommand;
            BottomLeftMainEngineThrottleCommand = bottomLeftMainEngineThrottleCommand;
            BottomRightMainEngineThrottleCommand = bottomRightMainEngineThrottleCommand;
            MainEngineAttitudeYawCommand = mainEngineAttitudeYawCommand;
            MainEngineAttitudeRollCommand = mainEngineAttitudeRollCommand;
            MainEngineAttitudePitchCommand = mainEngineAttitudePitchCommand;
        }

        public IEnumerable<TelemetryMessage> ProvideTelemetry()
        {
            var telemetry = new List<TelemetryMessage>();

            telemetry.AddRange(TopLeftRcsEngineThrottleCommand.ProvideTelemetry());
            telemetry.AddRange(TopRightRcsEngineThrottleCommand.ProvideTelemetry());
            telemetry.AddRange(BottomLeftRcsEngineThrottleCommand.ProvideTelemetry());
            telemetry.AddRange(BottomRightRcsEngineThrottleCommand.ProvideTelemetry());
            telemetry.AddRange(TopMainEngineThrottleCommand.ProvideTelemetry());
            telemetry.AddRange(BottomLeftMainEngineThrottleCommand.ProvideTelemetry());
            telemetry.AddRange(BottomRightMainEngineThrottleCommand.ProvideTelemetry());
            telemetry.AddRange(MainEngineAttitudeYawCommand.ProvideTelemetry());
            telemetry.AddRange(MainEngineAttitudeRollCommand.ProvideTelemetry());
            telemetry.AddRange(MainEngineAttitudePitchCommand.ProvideTelemetry());

            return telemetry;
        }
    }
}