using System;
using Starship.Control;
using Starship.Control.Actuation.Engine;
using Starship.Control.Actuation.Flap;
using Starship.Control.Throttle.Main;
using Starship.Flight;
using Starship.Flight.Segment;
using Starship.Flight.Segment.Config;
using Starship.Flight.Segment.Config.Path;
using Starship.Mission;
using Starship.Sensor;
using Starship.Sensor.Attitude;
using Starship.Telemetry;
using Starship.Utility.Timing;
using static UnityEngine.Debug;
using static Vessel.Situations;

namespace Starship
{
    public sealed class FlightComputer : PartModule
    {
        private readonly Lazy<AttitudeSensor> _attitudeSensor = new Lazy<AttitudeSensor>();

        private readonly Lazy<MainEnginesThrottleControl> _mainEnginesThrottleControl =
            new Lazy<MainEnginesThrottleControl>();
        private readonly Lazy<MainEnginesGimbalControl> _mainEnginesGimbalControl =
            new Lazy<MainEnginesGimbalControl>();
        private readonly Lazy<FlapsActuationControl> _flapsActuationControl =
            new Lazy<FlapsActuationControl>();

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

                var sensorSuite = new SensorSuite(
                    _attitudeSensor.Value);

                _mainEnginesThrottleControl.Value.Bind(vessel);
                _mainEnginesGimbalControl.Value.Bind(vessel);
                _flapsActuationControl.Value.Bind(vessel);

                var controlSuite = new ControlSuite(
                    _mainEnginesThrottleControl.Value,
                    _mainEnginesGimbalControl.Value,
                    _flapsActuationControl.Value);

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
                    missionTimer,
                    new FlightSegmentConfigsLoader(
                        new FlightSegmentConfigsPath()));

            return new FlightCommander(
                missionTimer,
                telemetryEmitter,
                flightSegmentCommanders);
        }
    }
}