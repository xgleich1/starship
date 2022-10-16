using System.Collections.Generic;
using Starship.Flight.Command.Actuation.Engine;
using Starship.Flight.Segment.Config;
using Starship.Sensor;
using Starship.Telemetry;
using Starship.Utility.Math;

namespace Starship.Flight.Segment.Actuation.Engine
{
    public sealed class MainEnginesGimbalSegmentCommander : IMainEnginesGimbalSegmentCommander
    {
        private readonly FlightSegmentConfig _flightSegmentConfig;

        private readonly PidRegulator _lateralVelocityOffsetPidRegulator;
        private readonly PidRegulator _horizontalVelocityOffsetPidRegulator;

        private readonly PidRegulator _mainEnginesYawPidRegulator;
        private readonly PidRegulator _mainEnginesRollPidRegulator;
        private readonly PidRegulator _mainEnginesPitchPidRegulator;


        public MainEnginesGimbalSegmentCommander(FlightSegmentConfig flightSegmentConfig)
        {
            _flightSegmentConfig = flightSegmentConfig;

            _lateralVelocityOffsetPidRegulator = CreateLateralVelocityOffsetPidRegulator();
            _horizontalVelocityOffsetPidRegulator = CreateHorizontalVelocityOffsetPidRegulator();

            _mainEnginesYawPidRegulator = CreateMainEnginesGimbalPidRegulator();
            _mainEnginesRollPidRegulator = CreateMainEnginesGimbalPidRegulator();
            _mainEnginesPitchPidRegulator = CreateMainEnginesGimbalPidRegulator();
        }

        public MainEnginesGimbalSegmentCommands CommandMainEnginesGimbal(ISensorSuite sensorSuite)
        {
            var regulatedLateralVelocityOffset =
                RegulateLateralVelocityOffset(sensorSuite);

            var regulatedHorizontalVelocityOffset =
                RegulateHorizontalVelocityOffset(sensorSuite);

            var regulatedMainEnginesYawPercent =
                RegulateMainEnginesYawPercent(sensorSuite, regulatedLateralVelocityOffset);

            var regulatedMainEnginesRollPercent =
                RegulateMainEnginesRollPercent(sensorSuite);

            var regulatedMainEnginesPitchPercent =
                RegulateMainEnginesPitchPercent(sensorSuite, regulatedHorizontalVelocityOffset);

            var mainEnginesYawPercent = _flightSegmentConfig
                .MainEnginesYawPercentOverwrite ?? regulatedMainEnginesYawPercent;

            var mainEnginesRollPercent = _flightSegmentConfig
                .MainEnginesRollPercentOverwrite ?? regulatedMainEnginesRollPercent;

            var mainEnginesPitchPercent = _flightSegmentConfig
                .MainEnginesPitchPercentOverwrite ?? regulatedMainEnginesPitchPercent;

            return new MainEnginesGimbalSegmentCommands(
                new MainEnginesYawCommand(mainEnginesYawPercent),
                new MainEnginesRollCommand(mainEnginesRollPercent),
                new MainEnginesPitchCommand(mainEnginesPitchPercent));
        }

        public IEnumerable<TelemetryMessage> ProvideTelemetry() => new List<TelemetryMessage>
        {
            new TelemetryMessage(
                "--- Main Engines Gimbal Segment Commander Config ---"),
            new TelemetryMessage(
                $"DesiredYawAngleInDegrees:{_flightSegmentConfig.DesiredYawAngleInDegrees}"),
            new TelemetryMessage(
                $"DesiredRollAngleInDegrees:{_flightSegmentConfig.DesiredRollAngleInDegrees}"),
            new TelemetryMessage(
                $"DesiredPitchAngleInDegrees:{_flightSegmentConfig.DesiredPitchAngleInDegrees}"),
            new TelemetryMessage(
                $"DesiredLateralVelocityInMetrePerSecond:{_flightSegmentConfig.DesiredLateralVelocityInMetrePerSecond}"),
            new TelemetryMessage(
                $"DesiredHorizontalVelocityInMetrePerSecond:{_flightSegmentConfig.DesiredHorizontalVelocityInMetrePerSecond}"),
            new TelemetryMessage(
                $"MainEnginesYawPercentOverwrite:{_flightSegmentConfig.MainEnginesYawPercentOverwrite}"),
            new TelemetryMessage(
                $"MainEnginesRollPercentOverwrite:{_flightSegmentConfig.MainEnginesRollPercentOverwrite}"),
            new TelemetryMessage(
                $"MainEnginesPitchPercentOverwrite:{_flightSegmentConfig.MainEnginesPitchPercentOverwrite}"),
            new TelemetryMessage(
                $"MainEnginesGimbalPidRegulatorProportionalGain:{_flightSegmentConfig.MainEnginesGimbalPidRegulatorProportionalGain}"),
            new TelemetryMessage(
                $"MainEnginesGimbalPidRegulatorIntegralGain:{_flightSegmentConfig.MainEnginesGimbalPidRegulatorIntegralGain}"),
            new TelemetryMessage(
                $"MainEnginesGimbalPidRegulatorDerivativeGain:{_flightSegmentConfig.MainEnginesGimbalPidRegulatorDerivativeGain}"),
            new TelemetryMessage(
                $"LateralVelocityOffsetPidRegulatorProportionalGain:{_flightSegmentConfig.LateralVelocityOffsetPidRegulatorProportionalGain}"),
            new TelemetryMessage(
                $"LateralVelocityOffsetPidRegulatorIntegralGain:{_flightSegmentConfig.LateralVelocityOffsetPidRegulatorIntegralGain}"),
            new TelemetryMessage(
                $"LateralVelocityOffsetPidRegulatorDerivativeGain:{_flightSegmentConfig.LateralVelocityOffsetPidRegulatorDerivativeGain}"),
            new TelemetryMessage(
                $"HorizontalVelocityOffsetPidRegulatorProportionalGain:{_flightSegmentConfig.HorizontalVelocityOffsetPidRegulatorProportionalGain}"),
            new TelemetryMessage(
                $"HorizontalVelocityOffsetPidRegulatorIntegralGain:{_flightSegmentConfig.HorizontalVelocityOffsetPidRegulatorIntegralGain}"),
            new TelemetryMessage(
                $"HorizontalVelocityOffsetPidRegulatorDerivativeGain:{_flightSegmentConfig.HorizontalVelocityOffsetPidRegulatorDerivativeGain}"),
            new TelemetryMessage(
                "----------------------------------------------------")
        };

        public override bool Equals(object obj) =>
            ReferenceEquals(this, obj) || obj is MainEnginesGimbalSegmentCommander other
            && _flightSegmentConfig.Equals(other._flightSegmentConfig);

        public override int GetHashCode() => _flightSegmentConfig.GetHashCode();

        private PidRegulator CreateLateralVelocityOffsetPidRegulator() => new PidRegulator(
            minimumOutput: -15.0F,
            maximumOutput: +15.0F,
            _flightSegmentConfig.LateralVelocityOffsetPidRegulatorProportionalGain ?? 0.0F,
            _flightSegmentConfig.LateralVelocityOffsetPidRegulatorIntegralGain ?? 0.0F,
            _flightSegmentConfig.LateralVelocityOffsetPidRegulatorDerivativeGain ?? 0.0F);

        private PidRegulator CreateHorizontalVelocityOffsetPidRegulator() => new PidRegulator(
            minimumOutput: -15.0F,
            maximumOutput: +15.0F,
            _flightSegmentConfig.HorizontalVelocityOffsetPidRegulatorProportionalGain ?? 0.0F,
            _flightSegmentConfig.HorizontalVelocityOffsetPidRegulatorIntegralGain ?? 0.0F,
            _flightSegmentConfig.HorizontalVelocityOffsetPidRegulatorDerivativeGain ?? 0.0F);

        private PidRegulator CreateMainEnginesGimbalPidRegulator() => new PidRegulator(
            minimumOutput: -1.0F,
            maximumOutput: +1.0F,
            _flightSegmentConfig.MainEnginesGimbalPidRegulatorProportionalGain ?? 0.0F,
            _flightSegmentConfig.MainEnginesGimbalPidRegulatorIntegralGain ?? 0.0F,
            _flightSegmentConfig.MainEnginesGimbalPidRegulatorDerivativeGain ?? 0.0F);

        private float RegulateLateralVelocityOffset(ISensorSuite sensorSuite)
        {
            if (!_flightSegmentConfig.DesiredLateralVelocityInMetrePerSecond.HasValue)
            {
                return 0.0F;
            }

            return _lateralVelocityOffsetPidRegulator.RegulateValue(
                _flightSegmentConfig.DesiredLateralVelocityInMetrePerSecond.Value,
                sensorSuite.VelocitySensor.LateralVelocityInMetrePerSecond);
        }

        private float RegulateHorizontalVelocityOffset(ISensorSuite sensorSuite)
        {
            if (!_flightSegmentConfig.DesiredHorizontalVelocityInMetrePerSecond.HasValue)
            {
                return 0.0F;
            }

            return _horizontalVelocityOffsetPidRegulator.RegulateValue(
                _flightSegmentConfig.DesiredHorizontalVelocityInMetrePerSecond.Value,
                sensorSuite.VelocitySensor.HorizontalVelocityInMetrePerSecond);
        }

        private float RegulateMainEnginesYawPercent(ISensorSuite sensorSuite, float yawOffset)
        {
            var desiredYawAngleInDegrees = _flightSegmentConfig.DesiredYawAngleInDegrees - yawOffset;

            return _mainEnginesYawPidRegulator
                .RegulateValue(desiredYawAngleInDegrees, sensorSuite.AttitudeSensor.YawAngleInDegrees);
        }

        private float RegulateMainEnginesRollPercent(ISensorSuite sensorSuite)
        {
            var desiredRollAngleInDegrees = _flightSegmentConfig.DesiredRollAngleInDegrees;

            return _mainEnginesRollPidRegulator
                .RegulateValue(desiredRollAngleInDegrees, sensorSuite.AttitudeSensor.RollAngleInDegrees);
        }

        private float RegulateMainEnginesPitchPercent(ISensorSuite sensorSuite, float pitchOffset)
        {
            var desiredPitchAngleInDegrees = _flightSegmentConfig.DesiredPitchAngleInDegrees - pitchOffset;

            return _mainEnginesPitchPidRegulator
                .RegulateValue(desiredPitchAngleInDegrees, sensorSuite.AttitudeSensor.PitchAngleInDegrees);
        }
    }
}