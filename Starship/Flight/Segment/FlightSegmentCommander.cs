using System.Collections.Generic;
using Starship.Flight.Command;
using Starship.Flight.Command.Actuation.Engine;
using Starship.Flight.Command.Actuation.Flap;
using Starship.Flight.Command.Throttle.Main;
using Starship.Flight.Regulator.Engine;
using Starship.Flight.Regulator.Flap;
using Starship.Flight.Segment.Config;
using Starship.Sensor;
using Starship.Telemetry;
using Starship.Utility.Math;
using Starship.Utility.Timing.Units;

namespace Starship.Flight.Segment
{
    // Currently under development
    public sealed class FlightSegmentCommander : IFlightSegmentCommander
    {
        public Seconds TakeoverSecondsInMission =>
            _flightSegmentConfig.TakeoverSecondsInMission;

        private readonly IFlightSegmentConfig _flightSegmentConfig;

        private readonly MainEnginesThrottleRegulator _mainEnginesThrottleRegulator;

        private readonly MainEnginesGimbalRegulator _mainEnginesYawRegulator;
        private readonly MainEnginesGimbalRegulator _mainEnginesRollRegulator;
        private readonly MainEnginesGimbalRegulator _mainEnginesPitchRegulator;

        private readonly FlapsActuationRegulator _flapsYawRegulator;
        private readonly FlapsActuationRegulator _flapsRollRegulator;
        private readonly FlapsActuationRegulator _flapsPitchRegulator;


        public FlightSegmentCommander(IFlightSegmentConfig flightSegmentConfig)
        {
            _flightSegmentConfig = flightSegmentConfig;

            _mainEnginesThrottleRegulator = CreateMainEnginesThrottleRegulator();

            _mainEnginesYawRegulator = CreateMainEnginesYawRegulator();
            _mainEnginesRollRegulator = CreateMainEnginesRollRegulator();
            _mainEnginesPitchRegulator = CreateMainEnginesPitchRegulator();

            _flapsYawRegulator = CreateFlapsYawRegulator();
            _flapsRollRegulator = CreateFlapsRollRegulator();
            _flapsPitchRegulator = CreateFlapsPitchRegulator();
        }

        public ICommandSuite CommandFlight(ISensorSuite sensorSuite)
        {
            var mainEnginesThrottlePercent = RegulateMainEnginesThrottlePercent(sensorSuite);

            var topMainEngineThrottlePercent = _flightSegmentConfig
                .TopMainEngineThrottlePercentOverwrite ?? mainEnginesThrottlePercent;
            var bottomLeftEngineThrottlePercent = _flightSegmentConfig
                .BottomLeftMainEngineThrottlePercentOverwrite ?? mainEnginesThrottlePercent;
            var bottomRightEngineThrottlePercent = _flightSegmentConfig
                .BottomRightMainEngineThrottlePercentOverwrite ?? mainEnginesThrottlePercent;

            var mainEnginesYawPercent = _flightSegmentConfig
                .MainEnginesYawPercentOverwrite ?? RegulateMainEnginesYawPercent(sensorSuite);
            var mainEnginesRollPercent = _flightSegmentConfig
                .MainEnginesRollPercentOverwrite ?? RegulateMainEnginesRollPercent(sensorSuite);
            var mainEnginesPitchPercent = _flightSegmentConfig
                .MainEnginesPitchPercentOverwrite ?? RegulateMainEnginesPitchPercent(sensorSuite);

            var flapsYawPercent = RegulateFlapsYawPercent(sensorSuite);
            var flapsRollPercent = RegulateFlapsRollPercent(sensorSuite);
            var flapsPitchPercent = RegulateFlapsPitchPercent(sensorSuite);

            var topLeftFlapDeployPercent = _flightSegmentConfig
                .TopLeftFlapDeployPercentOverwrite ?? 0.5F - flapsYawPercent + flapsRollPercent + flapsPitchPercent;
            var topRightFlapDeployPercent = _flightSegmentConfig
                .TopRightFlapDeployPercentOverwrite ?? 0.5F + flapsYawPercent - flapsRollPercent + flapsPitchPercent;
            var bottomLeftFlapDeployPercent = _flightSegmentConfig
                .BottomLeftFlapDeployPercentOverwrite ?? 0.5F + flapsYawPercent + flapsRollPercent - flapsPitchPercent;
            var bottomRightLeftFlapDeployPercent = _flightSegmentConfig
                .BottomRightFlapDeployPercentOverwrite ?? 0.5F - flapsYawPercent - flapsRollPercent - flapsPitchPercent;

            return new CommandSuite(
                new ThrottleTopMainEngineCommand(topMainEngineThrottlePercent.Clamp(0.0F, 1.0F)),
                new ThrottleBottomLeftMainEngineCommand(bottomLeftEngineThrottlePercent.Clamp(0.0F, 1.0F)),
                new ThrottleBottomRightMainEngineCommand(bottomRightEngineThrottlePercent.Clamp(0.0F, 1.0F)),
                new YawMainEnginesCommand(mainEnginesYawPercent.Clamp(-1.0F, 1.0F)),
                new RollMainEnginesCommand(mainEnginesRollPercent.Clamp(-1.0F, 1.0F)),
                new PitchMainEnginesCommand(mainEnginesPitchPercent.Clamp(-1.0F, 1.0F)),
                new ActuateTopLeftFlapCommand(topLeftFlapDeployPercent.Clamp(0.0F, 1.0F)),
                new ActuateTopRightFlapCommand(topRightFlapDeployPercent.Clamp(0.0F, 1.0F)),
                new ActuateBottomLeftFlapCommand(bottomLeftFlapDeployPercent.Clamp(0.0F, 1.0F)),
                new ActuateBottomRightFlapCommand(bottomRightLeftFlapDeployPercent.Clamp(0.0F, 1.0F)));
        }

        public IEnumerable<TelemetryMessage> ProvideTelemetry()
        {
            var telemetry = new List<TelemetryMessage>();

            telemetry.AddRange(_flightSegmentConfig.ProvideTelemetry());

            return telemetry;
        }

        private MainEnginesThrottleRegulator CreateMainEnginesThrottleRegulator() => new MainEnginesThrottleRegulator(
            _flightSegmentConfig.DesiredVerticalVelocityInMetrePerSecond,
            _flightSegmentConfig.MainEnginesThrottleProportionalGain,
            _flightSegmentConfig.MainEnginesThrottleIntegralGain,
            _flightSegmentConfig.MainEnginesThrottleDerivativeGain);

        private MainEnginesGimbalRegulator CreateMainEnginesYawRegulator() => new MainEnginesGimbalRegulator(
            _flightSegmentConfig.DesiredYawAngleInDegrees,
            _flightSegmentConfig.MainEnginesGimbalProportionalGain,
            _flightSegmentConfig.MainEnginesGimbalIntegralGain,
            _flightSegmentConfig.MainEnginesGimbalDerivativeGain);

        private MainEnginesGimbalRegulator CreateMainEnginesRollRegulator() => new MainEnginesGimbalRegulator(
            _flightSegmentConfig.DesiredRollAngleInDegrees,
            _flightSegmentConfig.MainEnginesGimbalProportionalGain,
            _flightSegmentConfig.MainEnginesGimbalIntegralGain,
            _flightSegmentConfig.MainEnginesGimbalDerivativeGain);

        private MainEnginesGimbalRegulator CreateMainEnginesPitchRegulator() => new MainEnginesGimbalRegulator(
            _flightSegmentConfig.DesiredPitchAngleInDegrees,
            _flightSegmentConfig.MainEnginesGimbalProportionalGain,
            _flightSegmentConfig.MainEnginesGimbalIntegralGain,
            _flightSegmentConfig.MainEnginesGimbalDerivativeGain);

        private FlapsActuationRegulator CreateFlapsYawRegulator() => new FlapsActuationRegulator(
            _flightSegmentConfig.DesiredYawAngleInDegrees,
            _flightSegmentConfig.FlapsYawProportionalGain,
            _flightSegmentConfig.FlapsYawIntegralGain,
            _flightSegmentConfig.FlapsYawDerivativeGain);

        private FlapsActuationRegulator CreateFlapsRollRegulator() => new FlapsActuationRegulator(
            _flightSegmentConfig.DesiredRollAngleInDegrees,
            _flightSegmentConfig.FlapsRollProportionalGain,
            _flightSegmentConfig.FlapsRollIntegralGain,
            _flightSegmentConfig.FlapsRollDerivativeGain);

        private FlapsActuationRegulator CreateFlapsPitchRegulator() => new FlapsActuationRegulator(
            _flightSegmentConfig.DesiredPitchAngleInDegrees,
            _flightSegmentConfig.FlapsPitchProportionalGain,
            _flightSegmentConfig.FlapsPitchIntegralGain,
            _flightSegmentConfig.FlapsPitchDerivativeGain);

        private float RegulateMainEnginesThrottlePercent(ISensorSuite sensorSuite) => _mainEnginesThrottleRegulator
            .RegulateValue(sensorSuite.VelocitySensor.VerticalVelocityInMetrePerSecond);

        private float RegulateMainEnginesYawPercent(ISensorSuite sensorSuite) => _mainEnginesYawRegulator
            .RegulateValue(sensorSuite.AttitudeSensor.YawAngleInDegrees);

        private float RegulateMainEnginesRollPercent(ISensorSuite sensorSuite) => _mainEnginesRollRegulator
            .RegulateValue(sensorSuite.AttitudeSensor.RollAngleInDegrees);

        private float RegulateMainEnginesPitchPercent(ISensorSuite sensorSuite) => _mainEnginesPitchRegulator
            .RegulateValue(sensorSuite.AttitudeSensor.PitchAngleInDegrees);

        private float RegulateFlapsYawPercent(ISensorSuite sensorSuite) => _flapsYawRegulator
            .RegulateValue(sensorSuite.AttitudeSensor.YawAngleInDegrees);

        private float RegulateFlapsRollPercent(ISensorSuite sensorSuite) => _flapsRollRegulator
            .RegulateValue(sensorSuite.AttitudeSensor.RollAngleInDegrees);

        private float RegulateFlapsPitchPercent(ISensorSuite sensorSuite) => _flapsPitchRegulator
            .RegulateValue(sensorSuite.AttitudeSensor.PitchAngleInDegrees);
    }
}