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
                RegulateLateralVelocityOffset(sensorSuite) ?? 0.0F;

            var regulatedHorizontalVelocityOffset =
                RegulateHorizontalVelocityOffset(sensorSuite) ?? 0.0F;

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
                new MainEnginesYawCommand(mainEnginesYawPercent.Clamp(-1.0F, 1.0F)),
                new MainEnginesRollCommand(mainEnginesRollPercent.Clamp(-1.0F, 1.0F)),
                new MainEnginesPitchCommand(mainEnginesPitchPercent.Clamp(-1.0F, 1.0F)));
        }

        public IEnumerable<TelemetryMessage> ProvideTelemetry() => new List<TelemetryMessage>();

        private PidRegulator CreateLateralVelocityOffsetPidRegulator() =>
            new PidRegulator(
                -15.0F,
                +15.0F,
                _flightSegmentConfig.LateralVelocityOffsetPidRegulatorProportionalGain ?? 0.0F,
                _flightSegmentConfig.LateralVelocityOffsetPidRegulatorIntegralGain ?? 0.0F,
                _flightSegmentConfig.LateralVelocityOffsetPidRegulatorDerivativeGain ?? 0.0F);

        private PidRegulator CreateHorizontalVelocityOffsetPidRegulator() =>
            new PidRegulator(
                -15.0F,
                +15.0F,
                _flightSegmentConfig.HorizontalVelocityOffsetPidRegulatorProportionalGain ?? 0.0F,
                _flightSegmentConfig.HorizontalVelocityOffsetPidRegulatorIntegralGain ?? 0.0F,
                _flightSegmentConfig.HorizontalVelocityOffsetPidRegulatorDerivativeGain ?? 0.0F);

        private PidRegulator CreateMainEnginesGimbalPidRegulator() =>
            new PidRegulator(
                -1.0F,
                +1.0F,
                _flightSegmentConfig.MainEnginesGimbalPidRegulatorProportionalGain ?? 0.0F,
                _flightSegmentConfig.MainEnginesGimbalPidRegulatorIntegralGain ?? 0.0F,
                _flightSegmentConfig.MainEnginesGimbalPidRegulatorDerivativeGain ?? 0.0F);

        private float? RegulateLateralVelocityOffset(ISensorSuite sensorSuite)
        {
            if (!_flightSegmentConfig.DesiredLateralVelocityInMetrePerSecond.HasValue)
            {
                return null;
            }

            return _lateralVelocityOffsetPidRegulator.RegulateValue(
                _flightSegmentConfig.DesiredLateralVelocityInMetrePerSecond.Value,
                sensorSuite.VelocitySensor.LateralVelocityInMetrePerSecond);
        }

        private float? RegulateHorizontalVelocityOffset(ISensorSuite sensorSuite)
        {
            if (!_flightSegmentConfig.DesiredHorizontalVelocityInMetrePerSecond.HasValue)
            {
                return null;
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