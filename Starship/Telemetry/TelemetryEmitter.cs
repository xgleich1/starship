using Starship.Mission;
using UnityEngine;

namespace Starship.Telemetry
{
    public sealed class TelemetryEmitter : ITelemetryEmitter
    {
        private readonly ILogger _unityLogger;
        private readonly IMissionTimer _missionTimer;


        public TelemetryEmitter(ILogger unityLogger, IMissionTimer missionTimer)
        {
            _unityLogger = unityLogger;
            _missionTimer = missionTimer;
        }

        public void EmitTelemetry(ITelemetryProvider telemetryProvider)
        {
            var elapsedSecondsInMission = _missionTimer.GetElapsedSeconds();

            foreach (var telemetryMessage in telemetryProvider.ProvideTelemetry())
            {
                _unityLogger.Log(LogType.Log,
                    $"{elapsedSecondsInMission.Quantity}:{telemetryMessage.Message}");
            }
        }
    }
}