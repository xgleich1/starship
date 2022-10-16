using System;
using Starship.Control;
using Starship.Control.Actuation.Engine;
using Starship.Control.Actuation.Flap;
using Starship.Control.Actuation.Leg;
using Starship.Control.Throttle.Main;
using Starship.Flight;
using Starship.Flight.Segment;
using Starship.Flight.Segment.Config;
using Starship.Mission;
using Starship.Sensor;
using Starship.Sensor.Altitude;
using Starship.Sensor.Attitude;
using Starship.Sensor.Velocity;
using Starship.Telemetry;
using Starship.Utility.Time;
using static UnityEngine.Debug;
using static Vessel.Situations;

namespace Starship
{
    public sealed class FlightComputer : PartModule
    {
        private readonly Lazy<AttitudeSensor> _attitudeSensor = new Lazy<AttitudeSensor>();
        private readonly Lazy<AltitudeSensor> _altitudeSensor = new Lazy<AltitudeSensor>();
        private readonly Lazy<VelocitySensor> _velocitySensor = new Lazy<VelocitySensor>();

        private readonly Lazy<LegsActuationControl> _legsActuationControl =
            new Lazy<LegsActuationControl>();
        private readonly Lazy<FlapsActuationControl> _flapsActuationControl =
            new Lazy<FlapsActuationControl>();
        private readonly Lazy<MainEnginesGimbalControl> _mainEnginesGimbalControl =
            new Lazy<MainEnginesGimbalControl>();
        private readonly Lazy<MainEnginesThrottleControl> _mainEnginesThrottleControl =
            new Lazy<MainEnginesThrottleControl>();

        private readonly Lazy<FlightCommander> _flightCommander =
            new Lazy<FlightCommander>(BuildFlightCommander);


        public override void OnStart(StartState state)
        {
            if (vessel == null)
            {
                return;
            }

            vessel.OnFlyByWire += delegate
            {
                if (vessel.situation == PRELAUNCH)
                {
                    return;
                }

                _attitudeSensor.Value.Update(vessel);
                _altitudeSensor.Value.Update(vessel);
                _velocitySensor.Value.Update(vessel);

                var sensorSuite = new SensorSuite(
                    _attitudeSensor.Value,
                    _altitudeSensor.Value,
                    _velocitySensor.Value);

                _legsActuationControl.Value.Bind(vessel);
                _flapsActuationControl.Value.Bind(vessel);
                _mainEnginesGimbalControl.Value.Bind(vessel);
                _mainEnginesThrottleControl.Value.Bind(vessel);

                var controlSuite = new ControlSuite(
                    _legsActuationControl.Value,
                    _flapsActuationControl.Value,
                    _mainEnginesGimbalControl.Value,
                    _mainEnginesThrottleControl.Value);

                _flightCommander.Value.CommandFlight(
                    sensorSuite,
                    controlSuite);
            };
        }

        private static FlightCommander BuildFlightCommander()
        {
            var missionTimer =
                new MissionTimer(
                    new Stopwatch());

            var telemetryEmitter =
                new TelemetryEmitter(
                    unityLogger,
                    missionTimer);

            var flightSegmentCommanders =
                new FlightSegmentCommanders(
                    new FlightSegmentConfigsLoader(
                        new FlightSegmentConfigsPath()));

            return new FlightCommander(
                missionTimer,
                telemetryEmitter,
                flightSegmentCommanders);
        }
    }
}