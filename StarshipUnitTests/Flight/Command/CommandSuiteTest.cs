using System.Collections.Generic;
using NUnit.Framework;
using Starship.Flight.Command;
using Starship.Flight.Command.Activation.Rcs;
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
                new TopLeftRcsActivationCommand(false),
                new TopRightRcsActivationCommand(false),
                new BottomLeftRcsActivationCommand(false),
                new BottomRightRcsActivationCommand(false),
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
                new TelemetryMessage("TopLeftRcsActivated:False"),
                new TelemetryMessage("TopRightRcsActivated:False"),
                new TelemetryMessage("BottomLeftRcsActivated:False"),
                new TelemetryMessage("BottomRightRcsActivated:False"),
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

        [Test]
        public void Should_provide_a_equality_by_value_method()
        {
            // GIVEN
            var commandSuiteA = new CommandSuite(
                new TopLeftRcsActivationCommand(false),
                new TopRightRcsActivationCommand(false),
                new BottomLeftRcsActivationCommand(false),
                new BottomRightRcsActivationCommand(false),
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

            var commandSuiteB = new CommandSuite(
                new TopLeftRcsActivationCommand(false),
                new TopRightRcsActivationCommand(false),
                new BottomLeftRcsActivationCommand(false),
                new BottomRightRcsActivationCommand(false),
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

            var commandSuiteC = new CommandSuite(
                new TopLeftRcsActivationCommand(true),
                new TopRightRcsActivationCommand(false),
                new BottomLeftRcsActivationCommand(true),
                new BottomRightRcsActivationCommand(false),
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
            Assert.That(commandSuiteA.Equals(commandSuiteB), Is.True);
            Assert.That(commandSuiteA.Equals(commandSuiteC), Is.False);
        }
    }
}