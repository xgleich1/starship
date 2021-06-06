namespace Starship.Telemetry
{
    public interface ITelemetryEmitter
    {
        void EmitTelemetry(TelemetryMessage telemetryMessage);

        void EmitTelemetry(ITelemetryProvider telemetryProvider);
    }
}