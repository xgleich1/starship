using System.Collections.Generic;
using System.Linq;
using Starship.Flight.Segment.Config;
using Starship.Sensor;
using Starship.Telemetry;

namespace Starship.Flight.Segment.Handover
{
    // Currently under development
    public sealed class FlightSegmentHandoverDecider : IFlightSegmentHandoverDecider
    {
        private readonly FlightSegmentConfig _flightSegmentConfig;


        public FlightSegmentHandoverDecider(FlightSegmentConfig flightSegmentConfig) =>
            _flightSegmentConfig = flightSegmentConfig;

        public bool CanHandover(ISensorSuite sensorSuite)
        {
            var currentYawAngle = sensorSuite.AttitudeSensor.YawAngleInDegrees;
            var currentRollAngle = sensorSuite.AttitudeSensor.RollAngleInDegrees;
            var currentPitchAngle = sensorSuite.AttitudeSensor.PitchAngleInDegrees;

            var currentAltitudeAboveTerrain = sensorSuite.AltitudeSensor.AltitudeAboveTerrainInMeters;

            var currentLateralVelocity = sensorSuite.VelocitySensor.LateralVelocityInMetrePerSecond;
            var currentVerticalVelocity = sensorSuite.VelocitySensor.VerticalVelocityInMetrePerSecond;
            var currentHorizontalVelocity = sensorSuite.VelocitySensor.HorizontalVelocityInMetrePerSecond;

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
                handoverConditions.Add(currentYawAngle >= handoverYawAngleEqualOrOver.Value);
            }

            if (handoverYawAngleEqualOrUnder.HasValue)
            {
                handoverConditions.Add(currentYawAngle <= handoverYawAngleEqualOrUnder.Value);
            }

            if (handoverRollAngleEqualOrOver.HasValue)
            {
                handoverConditions.Add(currentRollAngle >= handoverRollAngleEqualOrOver.Value);
            }

            if (handoverRollAngleEqualOrUnder.HasValue)
            {
                handoverConditions.Add(currentRollAngle <= handoverRollAngleEqualOrUnder.Value);
            }

            if (handoverPitchAngleEqualOrOver.HasValue)
            {
                handoverConditions.Add(currentPitchAngle >= handoverPitchAngleEqualOrOver.Value);
            }

            if (handoverPitchAngleEqualOrUnder.HasValue)
            {
                handoverConditions.Add(currentPitchAngle <= handoverPitchAngleEqualOrUnder.Value);
            }

            if (handoverAltitudeAboveTerrainEqualOrOver.HasValue)
            {
                handoverConditions.Add(currentAltitudeAboveTerrain >= handoverAltitudeAboveTerrainEqualOrOver.Value);
            }

            if (handoverAltitudeAboveTerrainEqualOrUnder.HasValue)
            {
                handoverConditions.Add(currentAltitudeAboveTerrain <= handoverAltitudeAboveTerrainEqualOrUnder.Value);
            }

            if (handoverLateralVelocityEqualOrOver.HasValue)
            {
                handoverConditions.Add(currentLateralVelocity >= handoverLateralVelocityEqualOrOver.Value);
            }

            if (handoverLateralVelocityEqualOrUnder.HasValue)
            {
                handoverConditions.Add(currentLateralVelocity <= handoverLateralVelocityEqualOrUnder.Value);
            }

            if (handoverVerticalVelocityEqualOrOver.HasValue)
            {
                handoverConditions.Add(currentVerticalVelocity >= handoverVerticalVelocityEqualOrOver.Value);
            }

            if (handoverVerticalVelocityEqualOrUnder.HasValue)
            {
                handoverConditions.Add(currentVerticalVelocity <= handoverVerticalVelocityEqualOrUnder.Value);
            }

            if (handoverHorizontalVelocityEqualOrOver.HasValue)
            {
                handoverConditions.Add(currentHorizontalVelocity >= handoverHorizontalVelocityEqualOrOver.Value);
            }

            if (handoverHorizontalVelocityEqualOrUnder.HasValue)
            {
                handoverConditions.Add(currentHorizontalVelocity <= handoverHorizontalVelocityEqualOrUnder.Value);
            }

            return handoverConditions.Count != 0 && handoverConditions
                .Aggregate((allConditions, nextCondition) => allConditions && nextCondition);
        }

        public IEnumerable<TelemetryMessage> ProvideTelemetry() => new List<TelemetryMessage>();
    }
}