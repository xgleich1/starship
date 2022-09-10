using System.Collections.Generic;
using Starship.Flight.Command.Actuation.Leg;
using Starship.Flight.Segment.Config;
using Starship.Sensor;
using Starship.Telemetry;

namespace Starship.Flight.Segment.Actuation.Leg
{
    // Currently under development
    public sealed class LegsActuationSegmentCommander : ILegsActuationSegmentCommander
    {
        private readonly FlightSegmentConfig _flightSegmentConfig;


        public LegsActuationSegmentCommander(FlightSegmentConfig flightSegmentConfig) =>
            _flightSegmentConfig = flightSegmentConfig;

        public LegsActuationCommand CommandLegsActuation(ISensorSuite sensorSuite) =>
            new LegsActuationCommand(_flightSegmentConfig.DesiredLegsExtendedState);

        public IEnumerable<TelemetryMessage> ProvideTelemetry() => new List<TelemetryMessage>();
    }
}