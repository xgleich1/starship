namespace Starship.Telemetry
{
    public readonly struct TelemetryMessage
    {
        public string Message { get; }


        public TelemetryMessage(string message)
        {
            Message = message;
        }
    }
}