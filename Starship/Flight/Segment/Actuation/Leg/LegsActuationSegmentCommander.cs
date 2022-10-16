using System.Collections.Generic;
using Starship.Flight.Command.Actuation.Leg;
using Starship.Flight.Segment.Config;
using Starship.Sensor;
using Starship.Telemetry;

namespace Starship.Flight.Segment.Actuation.Leg
{
    public sealed class LegsActuationSegmentCommander : ILegsActuationSegmentCommander
    {
        private readonly FlightSegmentConfig _flightSegmentConfig;


        public LegsActuationSegmentCommander(FlightSegmentConfig flightSegmentConfig) =>
            _flightSegmentConfig = flightSegmentConfig;

        public LegsActuationCommand CommandLegsActuation(ISensorSuite sensorSuite) =>
            new LegsActuationCommand(_flightSegmentConfig.DesiredLegsExtendedState);

        public IEnumerable<TelemetryMessage> ProvideTelemetry() => new List<TelemetryMessage>
        {
            new TelemetryMessage(
                "--- Legs Actuation Segment Commander Config ---"),
            new TelemetryMessage(
                $"DesiredLegsExtendedState:{_flightSegmentConfig.DesiredLegsExtendedState}"),
            new TelemetryMessage(
                "-----------------------------------------------")
        };

        public override bool Equals(object obj) =>
            ReferenceEquals(this, obj) || obj is LegsActuationSegmentCommander other
            && _flightSegmentConfig.Equals(other._flightSegmentConfig);

        public override int GetHashCode() => _flightSegmentConfig.GetHashCode();
    }
}