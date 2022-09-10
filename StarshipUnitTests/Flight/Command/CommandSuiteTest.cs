using System.Collections.Generic;
using NUnit.Framework;
using Starship.Flight.Command;
using Starship.Flight.Command.Actuation.Engine;
using Starship.Flight.Command.Actuation.Flap;
using Starship.Flight.Command.Actuation.Leg;
using Starship.Flight.Command.Throttle.Main;
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
                new LegsActuationCommand(false),
                new TopLeftFlapActuationCommand(0.0F),
                new TopRightFlapActuationCommand(0.0F),
                new BottomLeftFlapActuationCommand(0.0F),
                new BottomRightFlapActuationCommand(0.0F),
                new MainEnginesYawCommand(0.0F),
                new MainEnginesRollCommand(0.0F),
                new MainEnginesPitchCommand(0.0F),
                new TopMainEngineThrottleCommand(0.0F),
                new BottomLeftMainEngineThrottleCommand(0.0F),
                new BottomRightMainEngineThrottleCommand(0.0F));

            // THEN
            var expectedTelemetry = new List<TelemetryMessage>
            {
                new TelemetryMessage("LegsExtended:False"),
                new TelemetryMessage("TopLeftFlapDeployPercent:0"),
                new TelemetryMessage("TopRightFlapDeployPercent:0"),
                new TelemetryMessage("BottomLeftFlapDeployPercent:0"),
                new TelemetryMessage("BottomRightFlapDeployPercent:0"),
                new TelemetryMessage("MainEnginesYawPercent:0"),
                new TelemetryMessage("MainEnginesRollPercent:0"),
                new TelemetryMessage("MainEnginesPitchPercent:0"),
                new TelemetryMessage("TopMainEngineThrottlePercent:0"),
                new TelemetryMessage("BottomLeftMainEngineThrottlePercent:0"),
                new TelemetryMessage("BottomRightMainEngineThrottlePercent:0")
            };

            Assert.That(commandSuite.ProvideTelemetry(), Is.EqualTo(expectedTelemetry));
        }
    }
}