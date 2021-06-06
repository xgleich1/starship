namespace Starship.Flight
{
    // Currently under development
    public readonly struct FlightCommand
    {
        public float MainThrottle { get; }


        public FlightCommand(float mainThrottle)
        {
            MainThrottle = mainThrottle;
        }
    }
}