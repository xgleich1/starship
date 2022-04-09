using System.Collections.Generic;
using Starship.Flight.Command;
using Starship.Flight.Command.Actuation.Engine;
using Starship.Flight.Command.Actuation.Flap;
using Starship.Flight.Command.Throttle.Main;
using Starship.Flight.Regulator.Actuation.Engine;
using Starship.Flight.Regulator.Actuation.Flap;
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

        private readonly FlightSegmentConfig _flightSegmentConfig;

        private readonly MainEnginesGimbalRegulator _yawWithMainEnginesRegulator;
        private readonly MainEnginesGimbalRegulator _rollWithMainEnginesRegulator;
        private readonly MainEnginesGimbalRegulator _pitchWithMainEnginesRegulator;

        private readonly FlapsActuationRegulator _yawWithFlapsRegulator;
        private readonly FlapsActuationRegulator _rollWithFlapsRegulator;
        private readonly FlapsActuationRegulator _pitchWithFlapsRegulator;


        public FlightSegmentCommander(FlightSegmentConfig flightSegmentConfig)
        {
            _flightSegmentConfig = flightSegmentConfig;

            _yawWithMainEnginesRegulator = new MainEnginesGimbalRegulator(
                _flightSegmentConfig.YawWithMainEnginesProportionalGain);
            _rollWithMainEnginesRegulator = new MainEnginesGimbalRegulator(
                _flightSegmentConfig.RollWithMainEnginesProportionalGain);
            _pitchWithMainEnginesRegulator = new MainEnginesGimbalRegulator(
                _flightSegmentConfig.PitchWithMainEnginesProportionalGain);

            _yawWithFlapsRegulator = new FlapsActuationRegulator(
                _flightSegmentConfig.YawWithFlapsProportionalGain);
            _rollWithFlapsRegulator = new FlapsActuationRegulator(
                _flightSegmentConfig.RollWithFlapsProportionalGain);
            _pitchWithFlapsRegulator = new FlapsActuationRegulator(
                _flightSegmentConfig.PitchWithFlapsProportionalGain);
        }

        public ICommandSuite CommandFlight(ISensorSuite sensorSuite)
        {
            var yawWithFlapsPercent =
                _yawWithFlapsRegulator.RegulateValue(
                    sensorSuite.AttitudeSensor.YawAngleInDegrees,
                    _flightSegmentConfig.DesiredYawAngleInDegrees);

            var rollWithFlapsPercent =
                _rollWithFlapsRegulator.RegulateValue(
                    sensorSuite.AttitudeSensor.RollAngleInDegrees,
                    _flightSegmentConfig.DesiredRollAngleInDegrees);

            var pitchWithFlapsPercent =
                _pitchWithFlapsRegulator.RegulateValue(
                    sensorSuite.AttitudeSensor.PitchAngleInDegrees,
                    _flightSegmentConfig.DesiredPitchAngleInDegrees);

            var topLeftFlapDeployPercent = _flightSegmentConfig.TopLeftFlapDeployPercentOverwrite ??
                                           0.5F + yawWithFlapsPercent + rollWithFlapsPercent + pitchWithFlapsPercent;

            var topRightFlapDeployPercent = _flightSegmentConfig.TopRightFlapDeployPercentOverwrite ??
                                            0.5F - yawWithFlapsPercent - rollWithFlapsPercent + pitchWithFlapsPercent;

            var bottomLeftFlapDeployPercent = _flightSegmentConfig.BottomLeftFlapDeployPercentOverwrite ??
                                              0.5F - yawWithFlapsPercent + rollWithFlapsPercent - pitchWithFlapsPercent;

            var bottomRightLeftFlapDeployPercent = _flightSegmentConfig.BottomRightFlapDeployPercentOverwrite ??
                                                   0.5F + yawWithFlapsPercent - rollWithFlapsPercent - pitchWithFlapsPercent;
            return new CommandSuite(
                CommandTopMainEngineThrottle(),
                CommandBottomLeftMainEngineThrottle(),
                CommandBottomRightMainEngineThrottle(),
                CommandMainEnginesYaw(sensorSuite),
                CommandMainEnginesRoll(sensorSuite),
                CommandMainEnginesPitch(sensorSuite),
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

        public override bool Equals(object obj) =>
            ReferenceEquals(this, obj) ||
            obj is FlightSegmentCommander other
            && _flightSegmentConfig.Equals(other._flightSegmentConfig);

        public override int GetHashCode() => _flightSegmentConfig.GetHashCode();

        private ThrottleTopMainEngineCommand CommandTopMainEngineThrottle()
        {
            var throttlePercent =
                _flightSegmentConfig.TopMainEngineThrottlePercentOverwrite ?? 0.0F;

            return new ThrottleTopMainEngineCommand(throttlePercent.Clamp(0.0F, 1.0F));
        }

        private ThrottleBottomLeftMainEngineCommand CommandBottomLeftMainEngineThrottle()
        {
            var throttlePercent =
                _flightSegmentConfig.BottomLeftMainEngineThrottlePercentOverwrite ?? 0.0F;

            return new ThrottleBottomLeftMainEngineCommand(throttlePercent.Clamp(0.0F, 1.0F));
        }

        private ThrottleBottomRightMainEngineCommand CommandBottomRightMainEngineThrottle()
        {
            var throttlePercent =
                _flightSegmentConfig.BottomRightMainEngineThrottlePercentOverwrite ?? 0.0F;

            return new ThrottleBottomRightMainEngineCommand(throttlePercent.Clamp(0.0F, 1.0F));
        }

        private YawMainEnginesCommand CommandMainEnginesYaw(ISensorSuite sensorSuite)
        {
            float RegulateYawPercent() =>
                _yawWithMainEnginesRegulator.RegulateValue(
                    sensorSuite.AttitudeSensor.YawAngleInDegrees,
                    _flightSegmentConfig.DesiredYawAngleInDegrees);

            var yawPercent =
                _flightSegmentConfig.MainEnginesYawPercentOverwrite ?? RegulateYawPercent();

            return new YawMainEnginesCommand(yawPercent.Clamp(-1.0F, 1.0F));
        }

        private RollMainEnginesCommand CommandMainEnginesRoll(ISensorSuite sensorSuite)
        {
            float RegulateRollPercent() =>
                _rollWithMainEnginesRegulator.RegulateValue(
                    sensorSuite.AttitudeSensor.RollAngleInDegrees,
                    _flightSegmentConfig.DesiredRollAngleInDegrees);

            var rollPercent =
                _flightSegmentConfig.MainEnginesRollPercentOverwrite ?? RegulateRollPercent();

            return new RollMainEnginesCommand(rollPercent.Clamp(-1.0F, 1.0F));
        }

        private PitchMainEnginesCommand CommandMainEnginesPitch(ISensorSuite sensorSuite)
        {
            float RegulatePitchPercent() =>
                _pitchWithMainEnginesRegulator.RegulateValue(
                    sensorSuite.AttitudeSensor.PitchAngleInDegrees,
                    _flightSegmentConfig.DesiredPitchAngleInDegrees);

            var pitchPercent =
                _flightSegmentConfig.MainEnginesPitchPercentOverwrite ?? RegulatePitchPercent();

            return new PitchMainEnginesCommand(pitchPercent.Clamp(-1.0F, 1.0F));
        }
    }
}