using System.Collections.Generic;
using Starship.Flight.Command.Throttle.Main;
using Starship.Flight.Segment.Config;
using Starship.Sensor;
using Starship.Telemetry;
using Starship.Utility.Math;

namespace Starship.Flight.Segment.Throttle.Main
{
    public sealed class MainEnginesThrottleSegmentCommander : IMainEnginesThrottleSegmentCommander
    {
        private readonly FlightSegmentConfig _flightSegmentConfig;

        private readonly PidRegulator _mainEnginesThrottlePidRegulator;


        public MainEnginesThrottleSegmentCommander(FlightSegmentConfig flightSegmentConfig)
        {
            _flightSegmentConfig = flightSegmentConfig;

            _mainEnginesThrottlePidRegulator = CreateMainEnginesThrottlePidRegulator();
        }

        public MainEnginesThrottleSegmentCommands CommandMainEnginesThrottle(ISensorSuite sensorSuite)
        {
            var regulatedMainEnginesThrottlePercent = RegulateMainEnginesThrottlePercent(sensorSuite);

            var topMainEngineThrottlePercent = _flightSegmentConfig
                .TopMainEngineThrottlePercentOverwrite ?? regulatedMainEnginesThrottlePercent;

            var bottomLeftMainEngineThrottlePercent = _flightSegmentConfig
                .BottomLeftMainEngineThrottlePercentOverwrite ?? regulatedMainEnginesThrottlePercent;

            var bottomRightMainEngineThrottlePercent = _flightSegmentConfig
                .BottomRightMainEngineThrottlePercentOverwrite ?? regulatedMainEnginesThrottlePercent;

            return new MainEnginesThrottleSegmentCommands(
                new TopMainEngineThrottleCommand(topMainEngineThrottlePercent),
                new BottomLeftMainEngineThrottleCommand(bottomLeftMainEngineThrottlePercent),
                new BottomRightMainEngineThrottleCommand(bottomRightMainEngineThrottlePercent));
        }

        public IEnumerable<TelemetryMessage> ProvideTelemetry() => new List<TelemetryMessage>
        {
            new TelemetryMessage(
                "--- Main Engines Throttle Segment Commander Config ---"),
            new TelemetryMessage(
                $"DesiredVerticalVelocityInMetrePerSecond:{_flightSegmentConfig.DesiredVerticalVelocityInMetrePerSecond}"),
            new TelemetryMessage(
                $"TopMainEngineThrottlePercentOverwrite:{_flightSegmentConfig.TopMainEngineThrottlePercentOverwrite}"),
            new TelemetryMessage(
                $"BottomLeftMainEngineThrottlePercentOverwrite:{_flightSegmentConfig.BottomLeftMainEngineThrottlePercentOverwrite}"),
            new TelemetryMessage(
                $"BottomRightMainEngineThrottlePercentOverwrite:{_flightSegmentConfig.BottomRightMainEngineThrottlePercentOverwrite}"),
            new TelemetryMessage(
                $"MainEnginesThrottlePidRegulatorProportionalGain:{_flightSegmentConfig.MainEnginesThrottlePidRegulatorProportionalGain}"),
            new TelemetryMessage(
                $"MainEnginesThrottlePidRegulatorIntegralGain:{_flightSegmentConfig.MainEnginesThrottlePidRegulatorIntegralGain}"),
            new TelemetryMessage(
                $"MainEnginesThrottlePidRegulatorDerivativeGain:{_flightSegmentConfig.MainEnginesThrottlePidRegulatorDerivativeGain}"),
            new TelemetryMessage(
                "------------------------------------------------------")
        };

        public override bool Equals(object obj) =>
            ReferenceEquals(this, obj) || obj is MainEnginesThrottleSegmentCommander other
            && _flightSegmentConfig.Equals(other._flightSegmentConfig);

        public override int GetHashCode() => _flightSegmentConfig.GetHashCode();

        private PidRegulator CreateMainEnginesThrottlePidRegulator() => new PidRegulator(
            minimumOutput: 0.4F,
            maximumOutput: 1.0F,
            _flightSegmentConfig.MainEnginesThrottlePidRegulatorProportionalGain ?? 0.0F,
            _flightSegmentConfig.MainEnginesThrottlePidRegulatorIntegralGain ?? 0.0F,
            _flightSegmentConfig.MainEnginesThrottlePidRegulatorDerivativeGain ?? 0.0F);

        private float RegulateMainEnginesThrottlePercent(ISensorSuite sensorSuite)
        {
            if (!_flightSegmentConfig.DesiredVerticalVelocityInMetrePerSecond.HasValue)
            {
                return 0.0F;
            }

            return _mainEnginesThrottlePidRegulator.RegulateValue(
                _flightSegmentConfig.DesiredVerticalVelocityInMetrePerSecond.Value,
                sensorSuite.VelocitySensor.VerticalVelocityInMetrePerSecond);
        }
    }
}