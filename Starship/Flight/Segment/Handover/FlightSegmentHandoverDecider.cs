using System.Collections.Generic;
using System.Linq;
using Starship.Flight.Segment.Config;
using Starship.Sensor;
using Starship.Telemetry;

namespace Starship.Flight.Segment.Handover
{
    public sealed class FlightSegmentHandoverDecider : IFlightSegmentHandoverDecider
    {
        private readonly FlightSegmentConfig _flightSegmentConfig;


        public FlightSegmentHandoverDecider(FlightSegmentConfig flightSegmentConfig) =>
            _flightSegmentConfig = flightSegmentConfig;

        public bool CanHandover(ISensorSuite sensorSuite)
        {
            var handoverYawAngleEqualOrOver =
                _flightSegmentConfig.HandoverYawAngleInDegreesEqualOrOver;
            var handoverYawAngleEqualOrUnder =
                _flightSegmentConfig.HandoverYawAngleInDegreesEqualOrUnder;

            var handoverRollAngleEqualOrOver =
                _flightSegmentConfig.HandoverRollAngleInDegreesEqualOrOver;
            var handoverRollAngleEqualOrUnder =
                _flightSegmentConfig.HandoverRollAngleInDegreesEqualOrUnder;

            var handoverPitchAngleEqualOrOver =
                _flightSegmentConfig.HandoverPitchAngleInDegreesEqualOrOver;
            var handoverPitchAngleEqualOrUnder =
                _flightSegmentConfig.HandoverPitchAngleInDegreesEqualOrUnder;

            var handoverAltitudeAboveTerrainEqualOrOver =
                _flightSegmentConfig.HandoverAltitudeAboveTerrainInMetersEqualOrOver;
            var handoverAltitudeAboveTerrainEqualOrUnder =
                _flightSegmentConfig.HandoverAltitudeAboveTerrainInMetersEqualOrUnder;

            var handoverLateralVelocityEqualOrOver =
                _flightSegmentConfig.HandoverLateralVelocityInMetrePerSecondEqualOrOver;
            var handoverLateralVelocityEqualOrUnder =
                _flightSegmentConfig.HandoverLateralVelocityInMetrePerSecondEqualOrUnder;

            var handoverVerticalVelocityEqualOrOver =
                _flightSegmentConfig.HandoverVerticalVelocityInMetrePerSecondEqualOrOver;
            var handoverVerticalVelocityEqualOrUnder =
                _flightSegmentConfig.HandoverVerticalVelocityInMetrePerSecondEqualOrUnder;

            var handoverHorizontalVelocityEqualOrOver =
                _flightSegmentConfig.HandoverHorizontalVelocityInMetrePerSecondEqualOrOver;
            var handoverHorizontalVelocityEqualOrUnder =
                _flightSegmentConfig.HandoverHorizontalVelocityInMetrePerSecondEqualOrUnder;

            var handoverConditions = new List<bool>();

            if (handoverYawAngleEqualOrOver.HasValue)
            {
                handoverConditions.Add(
                    sensorSuite.AttitudeSensor.YawAngleInDegrees >= handoverYawAngleEqualOrOver.Value);
            }

            if (handoverYawAngleEqualOrUnder.HasValue)
            {
                handoverConditions.Add(
                    sensorSuite.AttitudeSensor.YawAngleInDegrees <= handoverYawAngleEqualOrUnder.Value);
            }

            if (handoverRollAngleEqualOrOver.HasValue)
            {
                handoverConditions.Add(
                    sensorSuite.AttitudeSensor.RollAngleInDegrees >= handoverRollAngleEqualOrOver.Value);
            }

            if (handoverRollAngleEqualOrUnder.HasValue)
            {
                handoverConditions.Add(
                    sensorSuite.AttitudeSensor.RollAngleInDegrees <= handoverRollAngleEqualOrUnder.Value);
            }

            if (handoverPitchAngleEqualOrOver.HasValue)
            {
                handoverConditions.Add(
                    sensorSuite.AttitudeSensor.PitchAngleInDegrees >= handoverPitchAngleEqualOrOver.Value);
            }

            if (handoverPitchAngleEqualOrUnder.HasValue)
            {
                handoverConditions.Add(
                    sensorSuite.AttitudeSensor.PitchAngleInDegrees <= handoverPitchAngleEqualOrUnder.Value);
            }

            if (handoverAltitudeAboveTerrainEqualOrOver.HasValue)
            {
                handoverConditions.Add(
                    sensorSuite.AltitudeSensor.AltitudeAboveTerrainInMeters >= handoverAltitudeAboveTerrainEqualOrOver.Value);
            }

            if (handoverAltitudeAboveTerrainEqualOrUnder.HasValue)
            {
                handoverConditions.Add(
                    sensorSuite.AltitudeSensor.AltitudeAboveTerrainInMeters <= handoverAltitudeAboveTerrainEqualOrUnder.Value);
            }

            if (handoverLateralVelocityEqualOrOver.HasValue)
            {
                handoverConditions.Add(
                    sensorSuite.VelocitySensor.LateralVelocityInMetrePerSecond >= handoverLateralVelocityEqualOrOver.Value);
            }

            if (handoverLateralVelocityEqualOrUnder.HasValue)
            {
                handoverConditions.Add(
                    sensorSuite.VelocitySensor.LateralVelocityInMetrePerSecond <= handoverLateralVelocityEqualOrUnder.Value);
            }

            if (handoverVerticalVelocityEqualOrOver.HasValue)
            {
                handoverConditions.Add(
                    sensorSuite.VelocitySensor.VerticalVelocityInMetrePerSecond >= handoverVerticalVelocityEqualOrOver.Value);
            }

            if (handoverVerticalVelocityEqualOrUnder.HasValue)
            {
                handoverConditions.Add(
                    sensorSuite.VelocitySensor.VerticalVelocityInMetrePerSecond <= handoverVerticalVelocityEqualOrUnder.Value);
            }

            if (handoverHorizontalVelocityEqualOrOver.HasValue)
            {
                handoverConditions.Add(
                    sensorSuite.VelocitySensor.HorizontalVelocityInMetrePerSecond >= handoverHorizontalVelocityEqualOrOver.Value);
            }

            if (handoverHorizontalVelocityEqualOrUnder.HasValue)
            {
                handoverConditions.Add(
                    sensorSuite.VelocitySensor.HorizontalVelocityInMetrePerSecond <= handoverHorizontalVelocityEqualOrUnder.Value);
            }

            return handoverConditions.Count != 0 && handoverConditions.Aggregate((allConditions, nextCondition) => allConditions && nextCondition);
        }

        public IEnumerable<TelemetryMessage> ProvideTelemetry() => new List<TelemetryMessage>
        {
            new TelemetryMessage(
                "--- Flight Segment Handover Decider Config ---"),
            new TelemetryMessage(
                $"HandoverYawAngleInDegreesEqualOrOver:{_flightSegmentConfig.HandoverYawAngleInDegreesEqualOrOver}"),
            new TelemetryMessage(
                $"HandoverYawAngleInDegreesEqualOrUnder:{_flightSegmentConfig.HandoverYawAngleInDegreesEqualOrUnder}"),
            new TelemetryMessage(
                $"HandoverRollAngleInDegreesEqualOrOver:{_flightSegmentConfig.HandoverRollAngleInDegreesEqualOrOver}"),
            new TelemetryMessage(
                $"HandoverRollAngleInDegreesEqualOrUnder:{_flightSegmentConfig.HandoverRollAngleInDegreesEqualOrUnder}"),
            new TelemetryMessage(
                $"HandoverPitchAngleInDegreesEqualOrOver:{_flightSegmentConfig.HandoverPitchAngleInDegreesEqualOrOver}"),
            new TelemetryMessage(
                $"HandoverPitchAngleInDegreesEqualOrUnder:{_flightSegmentConfig.HandoverPitchAngleInDegreesEqualOrUnder}"),
            new TelemetryMessage(
                $"HandoverAltitudeAboveTerrainInMetersEqualOrOver:{_flightSegmentConfig.HandoverAltitudeAboveTerrainInMetersEqualOrOver}"),
            new TelemetryMessage(
                $"HandoverAltitudeAboveTerrainInMetersEqualOrUnder:{_flightSegmentConfig.HandoverAltitudeAboveTerrainInMetersEqualOrUnder}"),
            new TelemetryMessage(
                $"HandoverLateralVelocityInMetrePerSecondEqualOrOver:{_flightSegmentConfig.HandoverLateralVelocityInMetrePerSecondEqualOrOver}"),
            new TelemetryMessage(
                $"HandoverLateralVelocityInMetrePerSecondEqualOrUnder:{_flightSegmentConfig.HandoverLateralVelocityInMetrePerSecondEqualOrUnder}"),
            new TelemetryMessage(
                $"HandoverVerticalVelocityInMetrePerSecondEqualOrOver:{_flightSegmentConfig.HandoverVerticalVelocityInMetrePerSecondEqualOrOver}"),
            new TelemetryMessage(
                $"HandoverVerticalVelocityInMetrePerSecondEqualOrUnder:{_flightSegmentConfig.HandoverVerticalVelocityInMetrePerSecondEqualOrUnder}"),
            new TelemetryMessage(
                $"HandoverHorizontalVelocityInMetrePerSecondEqualOrOver:{_flightSegmentConfig.HandoverHorizontalVelocityInMetrePerSecondEqualOrOver}"),
            new TelemetryMessage(
                $"HandoverHorizontalVelocityInMetrePerSecondEqualOrUnder:{_flightSegmentConfig.HandoverHorizontalVelocityInMetrePerSecondEqualOrUnder}"),
            new TelemetryMessage(
                "----------------------------------------------")
        };

        public override bool Equals(object obj) =>
            ReferenceEquals(this, obj) || obj is FlightSegmentHandoverDecider other
            && _flightSegmentConfig.Equals(other._flightSegmentConfig);

        public override int GetHashCode() => _flightSegmentConfig.GetHashCode();
    }
}