using System.Collections.Generic;
using Starship.Flight.Command;
using Starship.Flight.Segment.Activation.Rcs;
using Starship.Flight.Segment.Actuation.Engine;
using Starship.Flight.Segment.Actuation.Flap;
using Starship.Flight.Segment.Actuation.Leg;
using Starship.Flight.Segment.Handover;
using Starship.Flight.Segment.Throttle.Main;
using Starship.Sensor;
using Starship.Telemetry;

namespace Starship.Flight.Segment
{
    public sealed class FlightSegmentCommander : IFlightSegmentCommander
    {
        private readonly IFlightSegmentHandoverDecider _flightSegmentHandoverDecider;
        private readonly IRcsActivationSegmentCommander _rcsActivationSegmentCommander;
        private readonly ILegsActuationSegmentCommander _legsActuationSegmentCommander;
        private readonly IFlapsActuationSegmentCommander _flapsActuationSegmentCommander;
        private readonly IMainEnginesGimbalSegmentCommander _mainEnginesGimbalSegmentCommander;
        private readonly IMainEnginesThrottleSegmentCommander _mainEnginesThrottleSegmentCommander;


        public FlightSegmentCommander(
            IFlightSegmentHandoverDecider flightSegmentHandoverDecider,
            IRcsActivationSegmentCommander rcsActivationSegmentCommander,
            ILegsActuationSegmentCommander legsActuationSegmentCommander,
            IFlapsActuationSegmentCommander flapsActuationSegmentCommander,
            IMainEnginesGimbalSegmentCommander mainEnginesGimbalSegmentCommander,
            IMainEnginesThrottleSegmentCommander mainEnginesThrottleSegmentCommander)
        {
            _flightSegmentHandoverDecider = flightSegmentHandoverDecider;
            _rcsActivationSegmentCommander = rcsActivationSegmentCommander;
            _legsActuationSegmentCommander = legsActuationSegmentCommander;
            _flapsActuationSegmentCommander = flapsActuationSegmentCommander;
            _mainEnginesGimbalSegmentCommander = mainEnginesGimbalSegmentCommander;
            _mainEnginesThrottleSegmentCommander = mainEnginesThrottleSegmentCommander;
        }

        public bool CanHandover(ISensorSuite sensorSuite) =>
            _flightSegmentHandoverDecider.CanHandover(sensorSuite);

        public ICommandSuite CommandFlight(ISensorSuite sensorSuite)
        {
            var rcsActivationSegmentCommands = _rcsActivationSegmentCommander
                .CommandRcsActivation(sensorSuite);

            var legsActuationSegmentCommand = _legsActuationSegmentCommander
                .CommandLegsActuation(sensorSuite);

            var flapsActuationSegmentCommands = _flapsActuationSegmentCommander
                .CommandFlapsActuation(sensorSuite);

            var mainEnginesGimbalSegmentCommands = _mainEnginesGimbalSegmentCommander
                .CommandMainEnginesGimbal(sensorSuite);

            var mainEnginesThrottleSegmentCommands = _mainEnginesThrottleSegmentCommander
                .CommandMainEnginesThrottle(sensorSuite);

            return new CommandSuite(
                rcsActivationSegmentCommands.TopLeftRcsActivationCommand,
                rcsActivationSegmentCommands.TopRightRcsActivationCommand,
                rcsActivationSegmentCommands.BottomLeftRcsActivationCommand,
                rcsActivationSegmentCommands.BottomRightRcsActivationCommand,
                legsActuationSegmentCommand,
                flapsActuationSegmentCommands.TopLeftFlapActuationCommand,
                flapsActuationSegmentCommands.TopRightFlapActuationCommand,
                flapsActuationSegmentCommands.BottomLeftFlapActuationCommand,
                flapsActuationSegmentCommands.BottomRightFlapActuationCommand,
                mainEnginesGimbalSegmentCommands.MainEnginesYawCommand,
                mainEnginesGimbalSegmentCommands.MainEnginesRollCommand,
                mainEnginesGimbalSegmentCommands.MainEnginesPitchCommand,
                mainEnginesThrottleSegmentCommands.TopMainEngineThrottleCommand,
                mainEnginesThrottleSegmentCommands.BottomLeftMainEngineThrottleCommand,
                mainEnginesThrottleSegmentCommands.BottomRightMainEngineThrottleCommand);
        }

        public IEnumerable<TelemetryMessage> ProvideTelemetry()
        {
            var telemetry = new List<TelemetryMessage>();

            telemetry.AddRange(_flightSegmentHandoverDecider.ProvideTelemetry());
            telemetry.AddRange(_rcsActivationSegmentCommander.ProvideTelemetry());
            telemetry.AddRange(_legsActuationSegmentCommander.ProvideTelemetry());
            telemetry.AddRange(_flapsActuationSegmentCommander.ProvideTelemetry());
            telemetry.AddRange(_mainEnginesGimbalSegmentCommander.ProvideTelemetry());
            telemetry.AddRange(_mainEnginesThrottleSegmentCommander.ProvideTelemetry());

            return telemetry;
        }

        public override bool Equals(object obj) =>
            ReferenceEquals(this, obj) || obj is FlightSegmentCommander other
            && _flightSegmentHandoverDecider.Equals(other._flightSegmentHandoverDecider)
            && _rcsActivationSegmentCommander.Equals(other._rcsActivationSegmentCommander)
            && _legsActuationSegmentCommander.Equals(other._legsActuationSegmentCommander)
            && _flapsActuationSegmentCommander.Equals(other._flapsActuationSegmentCommander)
            && _mainEnginesGimbalSegmentCommander.Equals(other._mainEnginesGimbalSegmentCommander)
            && _mainEnginesThrottleSegmentCommander.Equals(other._mainEnginesThrottleSegmentCommander);

        public override int GetHashCode()
        {
            var hashCode = _flightSegmentHandoverDecider.GetHashCode();

            hashCode = (hashCode * 397) ^ _rcsActivationSegmentCommander.GetHashCode();
            hashCode = (hashCode * 397) ^ _legsActuationSegmentCommander.GetHashCode();
            hashCode = (hashCode * 397) ^ _flapsActuationSegmentCommander.GetHashCode();
            hashCode = (hashCode * 397) ^ _mainEnginesGimbalSegmentCommander.GetHashCode();
            hashCode = (hashCode * 397) ^ _mainEnginesThrottleSegmentCommander.GetHashCode();

            return hashCode;
        }
    }
}