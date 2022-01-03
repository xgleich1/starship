using System.Collections.Generic;
using NUnit.Framework;
using Starship.Flight.Command;
using Starship.Flight.Command.Actuation.Engine;
using Starship.Flight.Command.Actuation.Flap;
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
                new ActuateTopLeftFlapCommand(0.0F),
                new ActuateTopRightFlapCommand(0.0F),
                new ActuateBottomLeftFlapCommand(0.0F),
                new ActuateBottomRightFlapCommand(0.0F));

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
                new TelemetryMessage("MainEnginesYawPercent:0"),
                new TelemetryMessage("MainEnginesRollPercent:0"),
                new TelemetryMessage("MainEnginesPitchPercent:0"),
                new TelemetryMessage("TopLeftFlapDeployPercent:0"),
                new TelemetryMessage("TopRightFlapDeployPercent:0"),
                new TelemetryMessage("BottomLeftFlapDeployPercent:0"),
                new TelemetryMessage("BottomRightFlapDeployPercent:0")
            };

            Assert.That(commandSuite.ProvideTelemetry(), Is.EqualTo(expectedTelemetry));
        }
    }
}