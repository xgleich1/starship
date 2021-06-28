namespace Starship.Flight.Command
{
    // Currently under development
    public abstract class ThrottleCommand
    {
        public float ThrottlePercent { get; }


        // Clamp value between 0.0 and 1.0 or throw exception?
        private ThrottleCommand(float throttlePercent)
        {
            ThrottlePercent = throttlePercent;
        }

        public sealed class TopLeftRcsEngineThrottle : ThrottleCommand
        {
            public TopLeftRcsEngineThrottle(float throttlePercent) : base(throttlePercent)
            {
            }
        }

        public sealed class TopRightRcsEngineThrottle : ThrottleCommand
        {
            public TopRightRcsEngineThrottle(float throttlePercent) : base(throttlePercent)
            {
            }
        }

        public sealed class BottomLeftRcsEngineThrottle : ThrottleCommand
        {
            public BottomLeftRcsEngineThrottle(float throttlePercent) : base(throttlePercent)
            {
            }
        }

        public sealed class BottomRightRcsEngineThrottle : ThrottleCommand
        {
            public BottomRightRcsEngineThrottle(float throttlePercent) : base(throttlePercent)
            {
            }
        }

        public sealed class TopMainEngineThrottle : ThrottleCommand
        {
            public TopMainEngineThrottle(float throttlePercent) : base(throttlePercent)
            {
            }
        }

        public sealed class BottomLeftMainEngineThrottle : ThrottleCommand
        {
            public BottomLeftMainEngineThrottle(float throttlePercent) : base(throttlePercent)
            {
            }
        }

        public sealed class BottomRightMainEngineThrottle : ThrottleCommand
        {
            public BottomRightMainEngineThrottle(float throttlePercent) : base(throttlePercent)
            {
            }
        }
    }
}