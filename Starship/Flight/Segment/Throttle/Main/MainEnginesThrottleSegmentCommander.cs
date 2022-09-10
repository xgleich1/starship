using System.Collections.Generic;
using Starship.Flight.Command.Throttle.Main;
using Starship.Flight.Segment.Config;
using Starship.Sensor;
using Starship.Telemetry;
using Starship.Utility.Math;

namespace Starship.Flight.Segment.Throttle.Main
{
    // Currently under development
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
                .TopMainEngineThrottlePercentOverwrite ?? regulatedMainEnginesThrottlePercent ?? 0.0F;

            var bottomLeftMainEngineThrottlePercent = _flightSegmentConfig
                .BottomLeftMainEngineThrottlePercentOverwrite ?? regulatedMainEnginesThrottlePercent ?? 0.0F;

            var bottomRightMainEngineThrottlePercent = _flightSegmentConfig
                .BottomRightMainEngineThrottlePercentOverwrite ?? regulatedMainEnginesThrottlePercent ?? 0.0F;

            return new MainEnginesThrottleSegmentCommands(
                new TopMainEngineThrottleCommand(topMainEngineThrottlePercent.Clamp(0.0F, 1.0F)),
                new BottomLeftMainEngineThrottleCommand(bottomLeftMainEngineThrottlePercent.Clamp(0.0F, 1.0F)),
                new BottomRightMainEngineThrottleCommand(bottomRightMainEngineThrottlePercent.Clamp(0.0F, 1.0F)));
        }

        public IEnumerable<TelemetryMessage> ProvideTelemetry() => new List<TelemetryMessage>();

        private PidRegulator CreateMainEnginesThrottlePidRegulator() => new PidRegulator(
            0.05F,
            1.0F,
            _flightSegmentConfig.MainEnginesThrottlePidRegulatorProportionalGain ?? 0.0F,
            _flightSegmentConfig.MainEnginesThrottlePidRegulatorIntegralGain ?? 0.0F,
            _flightSegmentConfig.MainEnginesThrottlePidRegulatorDerivativeGain ?? 0.0F);

        private float? RegulateMainEnginesThrottlePercent(ISensorSuite sensorSuite)
        {
            if (!_flightSegmentConfig.DesiredVerticalVelocityInMetrePerSecond.HasValue)
            {
                return null;
            }

            return _mainEnginesThrottlePidRegulator.RegulateValue(
                _flightSegmentConfig.DesiredVerticalVelocityInMetrePerSecond.Value,
                sensorSuite.VelocitySensor.VerticalVelocityInMetrePerSecond);
        }
    }
}