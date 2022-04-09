namespace Starship.Telemetry
{
    public readonly struct TelemetryMessage
    {
        public string Message { get; }


        public TelemetryMessage(string message) => Message = message;

        public override string ToString() => $"TelemetryMessage({Message})";
    }
}