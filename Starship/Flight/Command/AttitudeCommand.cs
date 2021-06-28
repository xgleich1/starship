namespace Starship.Flight.Command
{
    // Currently under development
    public abstract class AttitudeCommand
    {
        public float AttitudeInput { get; }


        // Clamp value between -1.0 and +1.0 or throw exception?
        private AttitudeCommand(float attitudeInput)
        {
            AttitudeInput = attitudeInput;
        }

        public sealed class MainEngineAttitudeYaw : AttitudeCommand
        {
            public MainEngineAttitudeYaw(float attitudeInput) : base(attitudeInput)
            {
            }
        }

        public sealed class MainEngineAttitudeRoll : AttitudeCommand
        {
            public MainEngineAttitudeRoll(float attitudeInput) : base(attitudeInput)
            {
            }
        }

        public sealed class MainEngineAttitudePitch : AttitudeCommand
        {
            public MainEngineAttitudePitch(float attitudeInput) : base(attitudeInput)
            {
            }
        }
    }
}