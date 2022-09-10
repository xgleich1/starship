using System.Collections.Generic;
using Starship.Flight.Command.Actuation.Flap;
using Starship.Flight.Segment.Config;
using Starship.Sensor;
using Starship.Telemetry;
using Starship.Utility.Math;

namespace Starship.Flight.Segment.Actuation.Flap
{
    // Currently under development
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
                new TopLeftFlapActuationCommand(topLeftFlapDeployPercent.Clamp(0.0F, 1.0F)),
                new TopRightFlapActuationCommand(topRightFlapDeployPercent.Clamp(0.0F, 1.0F)),
                new BottomLeftFlapActuationCommand(bottomLeftFlapDeployPercent.Clamp(0.0F, 1.0F)),
                new BottomRightFlapActuationCommand(bottomRightLeftFlapDeployPercent.Clamp(0.0F, 1.0F)));
        }

        public IEnumerable<TelemetryMessage> ProvideTelemetry() => new List<TelemetryMessage>();

        private PidRegulator CreateFlapsActuationPidRegulator() => new PidRegulator(
            -0.5F / 3.0F,
            +0.5F / 3.0F,
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