using Starship.Mission;
using Starship.Telemetry;
using Starship.Utility.Timing;
using UnityEngine;

namespace Starship.Flight
{
    public sealed class FlightDependencies
    {
        public IMissionClock MissionClock { get; }
        public ITelemetryEmitter TelemetryEmitter { get; }


        public FlightDependencies()
        {
            var stopwatch = new Stopwatch(
                new System.Diagnostics.Stopwatch());

            MissionClock = new MissionClock(stopwatch);
            TelemetryEmitter = new TelemetryEmitter(Debug.unityLogger, MissionClock);
        }
    }
}