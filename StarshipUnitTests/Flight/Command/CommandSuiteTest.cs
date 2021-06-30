using System.Collections.Generic;
using NUnit.Framework;
using Starship.Flight.Command;
using Starship.Flight.Command.Attitude;
using Starship.Flight.Command.Throttle.Main;
using Starship.Flight.Command.Throttle.Rcs;
using Starship.Telemetry;

namespace StarshipUnitTests.Flight.Command
{
    public sealed class CommandSuiteTest
    {
        [Test]
        public void Should_provide_the_telemetry_of_each_command()
        {
            // GIVEN
            var commandSuite = new CommandSuite(
                new TopLeftRcsEngineThrottleCommand(0.0f),
                new TopRightRcsEngineThrottleCommand(0.0f),
                new BottomLeftRcsEngineThrottleCommand(0.0f),
                new BottomRightRcsEngineThrottleCommand(0.0f),
                new TopMainEngineThrottleCommand(0.0f),
                new BottomLeftMainEngineThrottleCommand(0.0f),
                new BottomRightMainEngineThrottleCommand(0.0f),
                new MainEngineAttitudeYawCommand(0.0f),
                new MainEngineAttitudeRollCommand(0.0f),
                new MainEngineAttitudePitchCommand(0.0f));

            // THEN
            var expectedTelemetry = new List<TelemetryMessage>
            {
                new TelemetryMessage("TopLeftRcsEngineThrottlePercent:0"),
                new TelemetryMessage("TopRightRcsEngineThrottlePercent:0"),
                new TelemetryMessage("BottomLeftRcsEngineThrottlePercent:0"),
                new TelemetryMessage("BottomRightRcsEngineThrottlePercent:0"),
                new TelemetryMessage("TopMainEngineThrottlePercent:0"),
                new TelemetryMessage("BottomLeftMainEngineThrottlePercent:0"),
                new TelemetryMessage("BottomRightMainEngineThrottlePercent:0"),
                new TelemetryMessage("MainEngineAttitudeYawInput:0"),
                new TelemetryMessage("MainEngineAttitudeRollInput:0"),
                new TelemetryMessage("MainEngineAttitudePitchInput:0")
            };

            Assert.That(commandSuite.ProvideTelemetry(), Is.EqualTo(expectedTelemetry));
        }
    }
}