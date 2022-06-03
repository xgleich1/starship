using System;
using System.Collections.Generic;
using Starship.Telemetry;
using UnityEngine;
using static System.DateTime;
using static UnityEngine.Mathf;

namespace Starship.Sensor.Attitude
{
    public sealed class AttitudeSensor : IAttitudeSensor
    {
        public float YawAngleInDegrees { get; private set; }
        public float RollAngleInDegrees { get; private set; }
        public float PitchAngleInDegrees { get; private set; }

        private DateTime? _previousUpdateTime;


        public void Update(Vessel vessel)
        {
            if (_previousUpdateTime == null)
            {
                _previousUpdateTime = Now;

                return;
            }

            var elapsedTimeBetweenUpdatesInSeconds =
                (Now - _previousUpdateTime)?.TotalSeconds;

            var angularChangeBetweenUpdatesInDegrees =
                GetAngularVelocityInDegreesPerSecond(vessel) *
                Convert.ToSingle(elapsedTimeBetweenUpdatesInSeconds);

            YawAngleInDegrees -= angularChangeBetweenUpdatesInDegrees.z;
            RollAngleInDegrees -= angularChangeBetweenUpdatesInDegrees.y;
            PitchAngleInDegrees -= angularChangeBetweenUpdatesInDegrees.x;

            _previousUpdateTime = Now;
        }

        public IEnumerable<TelemetryMessage> ProvideTelemetry() =>
            new List<TelemetryMessage>
            {
                new TelemetryMessage($"Yaw:{YawAngleInDegrees}"),
                new TelemetryMessage($"Roll:{RollAngleInDegrees}"),
                new TelemetryMessage($"Pitch:{PitchAngleInDegrees}")
            };

        private static Vector3 GetAngularVelocityInDegreesPerSecond(Vessel vessel) =>
            vessel.angularVelocity * Rad2Deg;
    }
}