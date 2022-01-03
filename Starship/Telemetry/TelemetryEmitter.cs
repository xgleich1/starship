using Starship.Mission;
using UnityEngine;

namespace Starship.Telemetry
{
    public sealed class TelemetryEmitter : ITelemetryEmitter
    {
        private readonly ILogger _unityLogger;
        private readonly IMissionTimer _missionTimer;


        public TelemetryEmitter(
            ILogger unityLogger,
            IMissionTimer missionTimer)
        {
            _unityLogger = unityLogger;
            _missionTimer = missionTimer;
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
            $"{_missionTimer.GetElapsedSeconds().Quantity}:{telemetryMessage.Message}";
    }
}