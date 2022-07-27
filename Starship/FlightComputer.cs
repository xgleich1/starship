using System;
using Starship.Control;
using Starship.Control.Actuation.Engine;
using Starship.Control.Actuation.Flap;
using Starship.Control.Actuation.Leg;
using Starship.Control.Throttle.Main;
using Starship.Flight;
using Starship.Flight.Segment;
using Starship.Flight.Segment.Config;
using Starship.Flight.Segment.Config.Path;
using Starship.Mission;
using Starship.Sensor;
using Starship.Sensor.Altitude;
using Starship.Sensor.Attitude;
using Starship.Sensor.Velocity;
using Starship.Telemetry;
using Starship.Utility.Timing;
using static UnityEngine.Debug;
using static Vessel.Situations;

namespace Starship
{
    public sealed class FlightComputer : PartModule
    {
        private readonly Lazy<VelocitySensor> _velocitySensor = new Lazy<VelocitySensor>();
        private readonly Lazy<AttitudeSensor> _attitudeSensor = new Lazy<AttitudeSensor>();
        private readonly Lazy<AltitudeSensor> _altitudeSensor = new Lazy<AltitudeSensor>();

        private readonly Lazy<MainEnginesThrottleControl> _mainEnginesThrottleControl =
            new Lazy<MainEnginesThrottleControl>();
        private readonly Lazy<MainEnginesGimbalControl> _mainEnginesGimbalControl =
            new Lazy<MainEnginesGimbalControl>();
        private readonly Lazy<FlapsActuationControl> _flapsActuationControl =
            new Lazy<FlapsActuationControl>();
        private readonly Lazy<LegsActuationControl> _legsActuationControl =
            new Lazy<LegsActuationControl>();

        private readonly Lazy<FlightCommander> _flightCommander =
            new Lazy<FlightCommander>(BuildFlightCommander);

        private ScreenMessage _screenMessage;

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

                _velocitySensor.Value.Update(vessel);
                _attitudeSensor.Value.Update(vessel);
                _altitudeSensor.Value.Update(vessel);

                var sensorSuite = new SensorSuite(
                    _velocitySensor.Value,
                    _attitudeSensor.Value,
                    _altitudeSensor.Value);

                _mainEnginesThrottleControl.Value.Bind(vessel);
                _mainEnginesGimbalControl.Value.Bind(vessel);
                _flapsActuationControl.Value.Bind(vessel);
                _legsActuationControl.Value.Bind(vessel);

                var controlSuite = new ControlSuite(
                    _mainEnginesThrottleControl.Value,
                    _mainEnginesGimbalControl.Value,
                    _flapsActuationControl.Value,
                    _legsActuationControl.Value);

                _flightCommander.Value.CommandFlight(
                    sensorSuite,
                    controlSuite);

                ScreenMessages.RemoveMessage(_screenMessage);
                _screenMessage = ScreenMessages.PostScreenMessage(
                    $"vertical velocity:{(int)sensorSuite.VelocitySensor.VerticalVelocityInMetrePerSecond}," +
                    $"\nvessel.srf_velocity.x:{(int)Convert.ToSingle(vessel.srf_velocity.x)}," +
                    $"\nvessel.srf_velocity.y:{(int)Convert.ToSingle(vessel.srf_velocity.y)}," + // y sieht gut aus
                    $"\nvessel.srf_velocity.z:{(int)Convert.ToSingle(vessel.srf_velocity.z)}," +
                    $"\nyaw angle:{(int)sensorSuite.AttitudeSensor.YawAngleInDegrees}," +
                    $"\nroll angle:{(int)sensorSuite.AttitudeSensor.RollAngleInDegrees}," +
                    $"\npitch angle:{(int)sensorSuite.AttitudeSensor.PitchAngleInDegrees}," +
                    $"\naltitude:{(int)sensorSuite.AltitudeSensor.AltitudeInMeters},",
                    float.MaxValue, ScreenMessageStyle.UPPER_LEFT);
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
                    new FlightSegmentCommandersLoader(
                        new FlightSegmentConfigsLoader(
                            new FlightSegmentConfigsPath())));

            return new FlightCommander(
                missionTimer,
                telemetryEmitter,
                flightSegmentCommanders);
        }
    }
}