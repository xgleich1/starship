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

        private const float FlapsActuationPidRegulatorMinimumOutput = -0.5F / 3.0F;
        private const float FlapsActuationPidRegulatorMaximumOutput = +0.5F / 3.0F;


        public FlapsActuationSegmentCommander(FlightSegmentConfig flightSegmentConfig)
        {
            _flightSegmentConfig = flightSegmentConfig;

            _flapsYawPidRegulator = CreateFlapsYawPidRegulator();
            _flapsRollPidRegulator = CreateFlapsRollPidRegulator();
            _flapsPitchPidRegulator = CreateFlapsPitchPidRegulator();
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
                $"FlapsYawPidRegulatorProportionalGain:{_flightSegmentConfig.FlapsYawPidRegulatorProportionalGain}"),
            new TelemetryMessage(
                $"FlapsYawPidRegulatorIntegralGain:{_flightSegmentConfig.FlapsYawPidRegulatorIntegralGain}"),
            new TelemetryMessage(
                $"FlapsYawPidRegulatorDerivativeGain:{_flightSegmentConfig.FlapsYawPidRegulatorDerivativeGain}"),
            new TelemetryMessage(
                $"FlapsRollPidRegulatorProportionalGain:{_flightSegmentConfig.FlapsRollPidRegulatorProportionalGain}"),
            new TelemetryMessage(
                $"FlapsRollPidRegulatorIntegralGain:{_flightSegmentConfig.FlapsRollPidRegulatorIntegralGain}"),
            new TelemetryMessage(
                $"FlapsRollPidRegulatorDerivativeGain:{_flightSegmentConfig.FlapsRollPidRegulatorDerivativeGain}"),
            new TelemetryMessage(
                $"FlapsPitchPidRegulatorProportionalGain:{_flightSegmentConfig.FlapsPitchPidRegulatorProportionalGain}"),
            new TelemetryMessage(
                $"FlapsPitchPidRegulatorIntegralGain:{_flightSegmentConfig.FlapsPitchPidRegulatorIntegralGain}"),
            new TelemetryMessage(
                $"FlapsPitchPidRegulatorDerivativeGain:{_flightSegmentConfig.FlapsPitchPidRegulatorDerivativeGain}"),
            new TelemetryMessage(
                "------------------------------------------------")
        };

        public override bool Equals(object obj) =>
            ReferenceEquals(this, obj) || obj is FlapsActuationSegmentCommander other
            && _flightSegmentConfig.Equals(other._flightSegmentConfig);

        public override int GetHashCode() => _flightSegmentConfig.GetHashCode();

        private PidRegulator CreateFlapsYawPidRegulator() => new PidRegulator(
            FlapsActuationPidRegulatorMinimumOutput,
            FlapsActuationPidRegulatorMaximumOutput,
            _flightSegmentConfig.FlapsYawPidRegulatorProportionalGain ?? 0.0F,
            _flightSegmentConfig.FlapsYawPidRegulatorIntegralGain ?? 0.0F,
            _flightSegmentConfig.FlapsYawPidRegulatorDerivativeGain ?? 0.0F);

        private PidRegulator CreateFlapsRollPidRegulator() => new PidRegulator(
            FlapsActuationPidRegulatorMinimumOutput,
            FlapsActuationPidRegulatorMaximumOutput,
            _flightSegmentConfig.FlapsRollPidRegulatorProportionalGain ?? 0.0F,
            _flightSegmentConfig.FlapsRollPidRegulatorIntegralGain ?? 0.0F,
            _flightSegmentConfig.FlapsRollPidRegulatorDerivativeGain ?? 0.0F);

        private PidRegulator CreateFlapsPitchPidRegulator() => new PidRegulator(
            FlapsActuationPidRegulatorMinimumOutput,
            FlapsActuationPidRegulatorMaximumOutput,
            _flightSegmentConfig.FlapsPitchPidRegulatorProportionalGain ?? 0.0F,
            _flightSegmentConfig.FlapsPitchPidRegulatorIntegralGain ?? 0.0F,
            _flightSegmentConfig.FlapsPitchPidRegulatorDerivativeGain ?? 0.0F);

        private float RegulateFlapsYawPercent(ISensorSuite sensorSuite) => _flapsYawPidRegulator
            .RegulateValue(_flightSegmentConfig.DesiredYawAngleInDegrees, sensorSuite.AttitudeSensor.YawAngleInDegrees);

        private float RegulateFlapsRollPercent(ISensorSuite sensorSuite) => _flapsRollPidRegulator
            .RegulateValue(_flightSegmentConfig.DesiredRollAngleInDegrees, sensorSuite.AttitudeSensor.RollAngleInDegrees);

        private float RegulateFlapsPitchPercent(ISensorSuite sensorSuite) => _flapsPitchPidRegulator
            .RegulateValue(_flightSegmentConfig.DesiredPitchAngleInDegrees, sensorSuite.AttitudeSensor.PitchAngleInDegrees);
    }
}