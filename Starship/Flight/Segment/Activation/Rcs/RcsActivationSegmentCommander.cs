using System;
using System.Collections.Generic;
using Starship.Flight.Command.Activation.Rcs;
using Starship.Flight.Segment.Config;
using Starship.Sensor;
using Starship.Telemetry;
using Starship.Utility.Math;

namespace Starship.Flight.Segment.Activation.Rcs
{
    public sealed class RcsActivationSegmentCommander : IRcsActivationSegmentCommander
    {
        private readonly FlightSegmentConfig _flightSegmentConfig;

        private readonly PidRegulator _rcsRollPidRegulator;

        private const int RcsRollDirectionAgainstClock = -1;
        private const int RcsRollDirectionWithClock = +1;


        public RcsActivationSegmentCommander(FlightSegmentConfig flightSegmentConfig)
        {
            _flightSegmentConfig = flightSegmentConfig;

            _rcsRollPidRegulator = CreateRcsActivationPidRegulator();
        }

        public RcsActivationSegmentCommands CommandRcsActivation(ISensorSuite sensorSuite)
        {
            var regulatedRcsRollDirection = RegulateRcsRollDirection(sensorSuite);

            var topLeftRcsActivated = _flightSegmentConfig.TopLeftRcsActivatedStateOverwrite ??
                                      regulatedRcsRollDirection == RcsRollDirectionAgainstClock;

            var topRightRcsActivated = _flightSegmentConfig.TopRightRcsActivatedStateOverwrite ??
                                       regulatedRcsRollDirection == RcsRollDirectionWithClock;

            var bottomLeftRcsActivated = _flightSegmentConfig.BottomLeftRcsActivatedStateOverwrite ??
                                         regulatedRcsRollDirection == RcsRollDirectionAgainstClock;

            var bottomRightRcsActivated = _flightSegmentConfig.BottomRightRcsActivatedStateOverwrite ??
                                          regulatedRcsRollDirection == RcsRollDirectionWithClock;

            return new RcsActivationSegmentCommands(
                new TopLeftRcsActivationCommand(topLeftRcsActivated),
                new TopRightRcsActivationCommand(topRightRcsActivated),
                new BottomLeftRcsActivationCommand(bottomLeftRcsActivated),
                new BottomRightRcsActivationCommand(bottomRightRcsActivated));
        }

        public IEnumerable<TelemetryMessage> ProvideTelemetry() => new List<TelemetryMessage>
        {
            new TelemetryMessage(
                "--- Rcs Activation Segment Commander Config ---"),
            new TelemetryMessage(
                $"DesiredRollAngleInDegrees:{_flightSegmentConfig.DesiredRollAngleInDegrees}"),
            new TelemetryMessage(
                $"TopLeftRcsActivatedStateOverwrite:{_flightSegmentConfig.TopLeftRcsActivatedStateOverwrite}"),
            new TelemetryMessage(
                $"TopRightRcsActivatedStateOverwrite:{_flightSegmentConfig.TopRightRcsActivatedStateOverwrite}"),
            new TelemetryMessage(
                $"BottomLeftRcsActivatedStateOverwrite:{_flightSegmentConfig.BottomLeftRcsActivatedStateOverwrite}"),
            new TelemetryMessage(
                $"BottomRightRcsActivatedStateOverwrite:{_flightSegmentConfig.BottomRightRcsActivatedStateOverwrite}"),
            new TelemetryMessage(
                $"RcsActivationPidRegulatorProportionalGain:{_flightSegmentConfig.RcsActivationPidRegulatorProportionalGain}"),
            new TelemetryMessage(
                $"RcsActivationPidRegulatorIntegralGain:{_flightSegmentConfig.RcsActivationPidRegulatorIntegralGain}"),
            new TelemetryMessage(
                $"RcsActivationPidRegulatorDerivativeGain:{_flightSegmentConfig.RcsActivationPidRegulatorDerivativeGain}"),
            new TelemetryMessage(
                "-----------------------------------------------")
        };

        public override bool Equals(object obj) =>
            ReferenceEquals(this, obj) || obj is RcsActivationSegmentCommander other
            && _flightSegmentConfig.Equals(other._flightSegmentConfig);

        public override int GetHashCode() => _flightSegmentConfig.GetHashCode();

        private PidRegulator CreateRcsActivationPidRegulator() => new PidRegulator(
            minimumOutput: Convert.ToSingle(RcsRollDirectionAgainstClock),
            maximumOutput: Convert.ToSingle(RcsRollDirectionWithClock),
            _flightSegmentConfig.RcsActivationPidRegulatorProportionalGain ?? 0.0F,
            _flightSegmentConfig.RcsActivationPidRegulatorIntegralGain ?? 0.0F,
            _flightSegmentConfig.RcsActivationPidRegulatorDerivativeGain ?? 0.0F);

        private int RegulateRcsRollDirection(ISensorSuite sensorSuite) =>
            Convert.ToInt32(_rcsRollPidRegulator.RegulateValue(
                _flightSegmentConfig.DesiredRollAngleInDegrees,
                sensorSuite.AttitudeSensor.RollAngleInDegrees));
    }
}