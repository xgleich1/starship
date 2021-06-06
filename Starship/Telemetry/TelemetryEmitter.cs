using Starship.Mission;
using UnityEngine;

namespace Starship.Telemetry
{
    public sealed class TelemetryEmitter : ITelemetryEmitter
    {
        private readonly ILogger _unityLogger;
        private readonly IMissionClock _missionClock;


        public TelemetryEmitter(
            ILogger unityLogger,
            IMissionClock missionClock)
        {
            _unityLogger = unityLogger;
            _missionClock = missionClock;
        }

        public void EmitTelemetry(TelemetryMessage telemetryMessage) =>
            _unityLogger.Log(LogType.Log, CreateLogMessage(telemetryMessage));

        public void EmitTelemetry(ITelemetryProvider telemetryProvider)
        {
            foreach (var telemetryMessage in telemetryProvider.ProvideTelemetry())
            {
                EmitTelemetry(telemetryMessage);
            }
        }

        private string CreateLogMessage(TelemetryMessage telemetryMessage) =>
            $"{_missionClock.GetElapsedSecondsInMission().Quantity}:{telemetryMessage.Message}";
    }
}