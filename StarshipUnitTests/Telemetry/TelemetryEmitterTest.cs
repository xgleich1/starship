using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using Starship.Mission;
using Starship.Telemetry;
using Starship.Utility.Timing.Units;
using UnityEngine;

namespace StarshipUnitTests.Telemetry
{
    public sealed class TelemetryEmitterTest
    {
        private Mock<ILogger> _unityLogger;
        private Mock<IMissionClock> _missionClock;
        private Mock<ITelemetryProvider> _telemetryProvider;

        private TelemetryEmitter _telemetryEmitter;


        [SetUp]
        public void Setup()
        {
            _unityLogger = new Mock<ILogger>();
            _missionClock = new Mock<IMissionClock>();
            _telemetryProvider = new Mock<ITelemetryProvider>();

            _telemetryEmitter = new TelemetryEmitter(
                _unityLogger.Object,
                _missionClock.Object);
        }

        [Test]
        public void Should_emit_a_single_telemetry_message()
        {
            // GIVEN
            _missionClock.Setup(mock => mock.GetElapsedSecondsInMission())
                .Returns(new Seconds(1));

            // WHEN
            _telemetryEmitter.EmitTelemetry(new TelemetryMessage("Yaw:10"));

            // THEN
            _unityLogger.Verify(mock => mock.Log(LogType.Log, "1:Yaw:10"));
        }

        [Test]
        public void Should_emit_the_provided_telemetry_messages()
        {
            // GIVEN
            _missionClock.SetupSequence(mock => mock.GetElapsedSecondsInMission())
                .Returns(new Seconds(1))
                .Returns(new Seconds(2))
                .Returns(new Seconds(3));

            _telemetryProvider.Setup(mock => mock.ProvideTelemetry())
                .Returns(new List<TelemetryMessage>
                {
                    new TelemetryMessage("Yaw:10"),
                    new TelemetryMessage("Roll:15"),
                    new TelemetryMessage("Pitch:20")
                });

            // WHEN
            _telemetryEmitter.EmitTelemetry(_telemetryProvider.Object);

            // THEN
            _unityLogger.Verify(mock => mock.Log(LogType.Log, "1:Yaw:10"));
            _unityLogger.Verify(mock => mock.Log(LogType.Log, "2:Roll:15"));
            _unityLogger.Verify(mock => mock.Log(LogType.Log, "3:Pitch:20"));
        }
    }
}