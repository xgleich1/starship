using System.Collections.Generic;
using System.Linq;
using Starship.Flight;
using Starship.Sensors;
using static Vessel.Situations;

namespace Starship
{
    // Currently under development
    public sealed class FlightComputer : PartModule
    {
        private readonly FlightCommander _flightCommander =
            new FlightCommander(new FlightDependencies());


        public override void OnStart(StartState state)
        {
            if (vessel == null)
            {
                return;
            }

            vessel.OnFlyByWire += flightControlState =>
            {
                if (vessel.situation == PRELAUNCH)
                {
                    return;
                }

                // What sensors can I access in a real rocket?
                // Position Sensor?
                // Acceleration Sensor?
                // Speed Sensor?
                // Throttle Sensor?
                // Center Of MassSensor?
                // Center Of Lift Sensor?
                // Thrust Sensor?
                // Gimbal Sensor?
                // Mass Sensor?
                // Thrust To Weight?
                var sensorSuite = new SensorSuite(
                    new YawSensor(vessel),
                    new RollSensor(vessel),
                    new PitchSensor(vessel),
                    new HeightSensor(vessel));

                // What can I manipulate in a real rocket?
                // Individual engines throttle?
                // Individual engines gimbal?
                // Individual rcs thruster?
                var flightCommand = _flightCommander.CommandFlight(sensorSuite);


                // TODO: Find out how to throttle individual engines
                var engines = FindPartModules<ModuleEnginesFX>(vessel);

                // Backward engine
                var engineOne = engines[0];
                engineOne.useEngineResponseTime = true;
                engineOne.currentThrottle = 0.75f;


                // TODO: Find out how to gimbal individual engines
                // var gimbalModules = FindPartModules<ModuleGimbal>(vessel);

                // TODO: Find out how to enable individual rcs
                // var rcsModules = FindPartModules<ModuleRCS>(vessel);
            };
        }

        private static List<T> FindPartModules<T>(Vessel vessel) where T : PartModule =>
            vessel.parts.Select(vesselPart => vesselPart.FindModuleImplementing<T>())
                .Where(partModule => partModule != null).ToList();
    }
}