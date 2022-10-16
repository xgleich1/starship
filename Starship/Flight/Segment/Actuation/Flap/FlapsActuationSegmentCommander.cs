using System.Collections.Generic;
using Starship.Flight.Command.Actuation.Flap;
using Starship.Flight.Segment.Config;
using Starship.Sensor;
using Starship.Telemetry;
using Starship.Utility.Math;

namespace Starship.Flight.Segment.Actuation.Flap
{
    public sealed class FlapsActuationSegmentCommander : IFlapsActuationSegmentCommander
    {
        private readonly FlightSegmentConfig _flightSegmentConfig;

        private readonly PidRegulator _flapsYawPidRegulator;
        private readonly PidRegulator _flapsRollPidRegulator;
        private readonly PidRegulator _flapsPitchPidRegulator;


        public FlapsActuationSegmentCommander(FlightSegmentConfig flightSegmentConfig)
        {
            _flightSegmentConfig = flightSegmentConfig;

            _flapsYawPidRegulator = CreateFlapsActuationPidRegulator();
            _flapsRollPidRegulator = CreateFlapsActuationPidRegulator();
            _flapsPitchPidRegulator = CreateFlapsActuationPidRegulator();
        }

        public FlapsActuationSegmentCommands CommandFlapsActuation(ISensorSuite sensorSuite)
        {
            var regulatedFlapsYawPercent = RegulateFlapsYawPercent(sensorSuite);
            var regulatedFlapsRollPercent = RegulateFlapsRollPercent(sensorSuite);
            var regulatedFlapsPitchPercent = RegulateFlapsPitchPercent(sensorSuite);

            var topLeftFlapDeployPercent = _flightSegmentConfig.TopLeftFlapDeployPercentOverwrite ??
                                           0.5F
                                           - regulatedFlapsYawPercent
                                           + regulatedFlapsRollPercent
                                           + regulatedFlapsPitchPercent;

            var topRightFlapDeployPercent = _flightSegmentConfig.TopRightFlapDeployPercentOverwrite ??
                                            0.5F
                                            + regulatedFlapsYawPercent
                                            - regulatedFlapsRollPercent
                                            + regulatedFlapsPitchPercent;

            var bottomLeftFlapDeployPercent = _flightSegmentConfig.BottomLeftFlapDeployPercentOverwrite ??
                                              0.5F
                                              + regulatedFlapsYawPercent
                                              + regulatedFlapsRollPercent
                                              - regulatedFlapsPitchPercent;

            var bottomRightLeftFlapDeployPercent = _flightSegmentConfig.BottomRightFlapDeployPercentOverwrite ??
                                                   0.5F
                                                   - regulatedFlapsYawPercent
                                                   - regulatedFlapsRollPercent
                                                   - regulatedFlapsPitchPercent;

            return new FlapsActuationSegmentCommands(
                new TopLeftFlapActuationCommand(topLeftFlapDeployPercent),
                new TopRightFlapActuationCommand(topRightFlapDeployPercent),
                new BottomLeftFlapActuationCommand(bottomLeftFlapDeployPercent),
                new BottomRightFlapActuationCommand(bottomRightLeftFlapDeployPercent));
        }

        public IEnumerable<TelemetryMessage> ProvideTelemetry() => new List<TelemetryMessage>
        {
            new TelemetryMessage(
                "--- Flaps Actuation Segment Commander Config ---"),
            new TelemetryMessage(
                $"DesiredYawAngleInDegrees:{_flightSegmentConfig.DesiredYawAngleInDegrees}"),
            new TelemetryMessage(
                $"DesiredRollAngleInDegrees:{_flightSegmentConfig.DesiredRollAngleInDegrees}"),
            new TelemetryMessage(
                $"DesiredPitchAngleInDegrees:{_flightSegmentConfig.DesiredPitchAngleInDegrees}"),
            new TelemetryMessage(
                $"TopLeftFlapDeployPercentOverwrite:{_flightSegmentConfig.TopLeftFlapDeployPercentOverwrite}"),
            new TelemetryMessage(
                $"TopRightFlapDeployPercentOverwrite:{_flightSegmentConfig.TopRightFlapDeployPercentOverwrite}"),
            new TelemetryMessage(
                $"BottomLeftFlapDeployPercentOverwrite:{_flightSegmentConfig.BottomLeftFlapDeployPercentOverwrite}"),
            new TelemetryMessage(
                $"BottomRightFlapDeployPercentOverwrite:{_flightSegmentConfig.BottomRightFlapDeployPercentOverwrite}"),
            new TelemetryMessage(
                $"FlapsActuationPidRegulatorProportionalGain:{_flightSegmentConfig.FlapsActuationPidRegulatorProportionalGain}"),
            new TelemetryMessage(
                $"FlapsActuationPidRegulatorIntegralGain:{_flightSegmentConfig.FlapsActuationPidRegulatorIntegralGain}"),
            new TelemetryMessage(
                $"FlapsActuationPidRegulatorDerivativeGain:{_flightSegmentConfig.FlapsActuationPidRegulatorDerivativeGain}"),
            new TelemetryMessage(
                "------------------------------------------------")
        };

        public override bool Equals(object obj) =>
            ReferenceEquals(this, obj) || obj is FlapsActuationSegmentCommander other
            && _flightSegmentConfig.Equals(other._flightSegmentConfig);

        public override int GetHashCode() => _flightSegmentConfig.GetHashCode();

        private PidRegulator CreateFlapsActuationPidRegulator() => new PidRegulator(
            minimumOutput: -0.5F / 3.0F,
            maximumOutput: +0.5F / 3.0F,
            _flightSegmentConfig.FlapsActuationPidRegulatorProportionalGain ?? 0.0F,
            _flightSegmentConfig.FlapsActuationPidRegulatorIntegralGain ?? 0.0F,
            _flightSegmentConfig.FlapsActuationPidRegulatorDerivativeGain ?? 0.0F);

        private float RegulateFlapsYawPercent(ISensorSuite sensorSuite) => _flapsYawPidRegulator
            .RegulateValue(_flightSegmentConfig.DesiredYawAngleInDegrees, sensorSuite.AttitudeSensor.YawAngleInDegrees);

        private float RegulateFlapsRollPercent(ISensorSuite sensorSuite) => _flapsRollPidRegulator
            .RegulateValue(_flightSegmentConfig.DesiredRollAngleInDegrees, sensorSuite.AttitudeSensor.RollAngleInDegrees);

        private float RegulateFlapsPitchPercent(ISensorSuite sensorSuite) => _flapsPitchPidRegulator
            .RegulateValue(_flightSegmentConfig.DesiredPitchAngleInDegrees, sensorSuite.AttitudeSensor.PitchAngleInDegrees);
    }
}