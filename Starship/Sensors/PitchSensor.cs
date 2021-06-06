using System;
using System.Collections.Generic;
using Starship.Telemetry;
using UnityEngine;

namespace Starship.Sensors
{
    public sealed class PitchSensor : ITelemetryProvider
    {
        public int PitchAngle { get; }


        public PitchSensor(int pitchAngle)
        {
            PitchAngle = pitchAngle;
        }

        public PitchSensor(Vessel vessel) : this(CalculatePitchAngle(vessel))
        {
            // Clarification
            // vessel.up = CoM - mainBody.position
            // vessel.upAxis = vesselTransform.position - mainBody.position
            //
            // Other options:
            // var rotationToSurface = Quaternion.Inverse(
            //     Quaternion.Euler(90, 0, 0) *
            //     Quaternion.Inverse(vessel.ReferenceTransform.rotation) *
            //     Quaternion.LookRotation(vessel.north, vessel.up));
            //
            // var rotationToSurface = Quaternion.Inverse(
            //     Quaternion.Euler(90, 0, 0) *
            //     Quaternion.Inverse(vessel.ReferenceTransform.rotation) * Quaternion.identity);
            // 
            // return Convert.ToInt32(Vector3.SignedAngle(rotationToSurface * Vector3d.forward, vessel.up, Vector3.right));
            //
            // return Convert.ToInt32(Vector3d.Angle(vessel.vesselTransform.rotation * Vector3.forward, vessel.up))
            //
            // return Convert.ToInt32(Vector3d.Angle(vessel.ReferenceTransform.rotation * Vector3.forward, vessel.up));
            // 
            // return Convert.ToInt32(Vector3d.Angle(vessel.ReferenceTransform.rotation * Vector3.forward, vessel.upAxis));
        }

        public IEnumerable<TelemetryMessage> ProvideTelemetry() =>
            new List<TelemetryMessage> {new TelemetryMessage($"Pitch:{PitchAngle}")};

        // Starts with 90, which is straight up.
        // Get's more with +pitch(w) and less with -pitch(s).
        // Get's less after 180 is reached and more after reaching 0. 
        private static int CalculatePitchAngle(Vessel vessel) =>
            Convert.ToInt32(Vector3.Angle(vessel.vesselTransform.rotation * Vector3.forward, vessel.upAxis));
    }
}