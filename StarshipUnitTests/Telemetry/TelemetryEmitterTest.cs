using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using Starship.Mission;
using Starship.Telemetry;
using Starship.Utility.Time.Units;
using UnityEngine;

namespace StarshipUnitTests.Telemetry
{
    public sealed class TelemetryEmitterTest
    {
        private Mock<ILogger> _unityLogger;
        private Mock<IMissionTimer> _missionTimer;
        private TelemetryEmitter _telemetryEmitter;

        private Mock<ITelemetryProvider> _telemetryProvider;


        [SetUp]
        public void Setup()
        {
            _unityLogger = new Mock<ILogger>();
            _missionTimer = new Mock<IMissionTimer>();
            _telemetryEmitter = new TelemetryEmitter(
                _unityLogger.Object,
                _missionTimer.Object);

            _telemetryProvider = new Mock<ITelemetryProvider>();
        }

        [Test]
        public void Should_emit_the_provided_telemetry_messages()
        {
            // GIVEN
            _missionTimer.SetupSequence(mock => mock.GetElapsedSeconds())
                .Returns(new Seconds(1));

            _telemetryProvider.Setup(mock => mock.ProvideTelemetry())
                .Returns(new List<TelemetryMessage>
                {
                    new TelemetryMessage("Yaw:0"),
                    new TelemetryMessage("Roll:0"),
                    new TelemetryMessage("Pitch:0")
                });

            // WHEN
            _telemetryEmitter.EmitTelemetry(_telemetryProvider.Object);

            // THEN
            _unityLogger.Verify(mock => mock.Log(LogType.Log, "1:Yaw:0"));
            _unityLogger.Verify(mock => mock.Log(LogType.Log, "1:Roll:0"));
            _unityLogger.Verify(mock => mock.Log(LogType.Log, "1:Pitch:0"));
        }
    }
}