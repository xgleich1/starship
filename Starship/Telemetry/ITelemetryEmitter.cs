namespace Starship.Telemetry
{
    public interface ITelemetryEmitter
    {
        void EmitTelemetry(ITelemetryProvider telemetryProvider);
    }
}