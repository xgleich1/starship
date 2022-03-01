using System.Collections.Generic;
using Starship.Sensor.Attitude;
using Starship.Telemetry;

namespace Starship.Sensor
{
    public sealed class SensorSuite : ISensorSuite
    {
        public IAttitudeSensor AttitudeSensor { get; }


        public SensorSuite(IAttitudeSensor attitudeSensor) =>
            AttitudeSensor = attitudeSensor;

        public IEnumerable<TelemetryMessage> ProvideTelemetry()
        {
            var telemetry = new List<TelemetryMessage>();

            telemetry.AddRange(AttitudeSensor.ProvideTelemetry());

            return telemetry;
        }
    }
}