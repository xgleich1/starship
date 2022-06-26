using System;
using Starship.Utility.Math;

namespace Starship.Flight.Regulator
{
    // Currently under development
    public abstract class PidRegulator
    {
        protected abstract float MinimumOutput { get; }
        protected abstract float MaximumOutput { get; }

        private readonly float _desiredValue;
        private readonly float _proportionalGain;
        private readonly float _integralGain;
        private readonly float _derivativeGain;

        private DateTime? _currentRegulateTime;
        private DateTime? _previousRegulateTime;

        private float _currentProcessValue;
        private float _previousProcessValue;

        private float _proportionalTerm;
        private float _integralTerm;
        private float _derivativeTerm;


        protected PidRegulator(
            float desiredValue,
            float proportionalGain,
            float integralGain,
            float derivativeGain)
        {
            _desiredValue = desiredValue;
            _proportionalGain = proportionalGain;
            _integralGain = integralGain;
            _derivativeGain = derivativeGain;
        }

        public float RegulateValue(float processValue)
        {
            _currentRegulateTime = DateTime.Now;
            _currentProcessValue = processValue;

            _proportionalTerm = CalculateProportionalTerm();
            _integralTerm = CalculateIntegralTerm();
            _derivativeTerm = CalculateDerivativeTerm();

            var outputToReduceError =
                _proportionalTerm
                + _integralTerm
                - _derivativeTerm;

            _previousRegulateTime = _currentRegulateTime;
            _previousProcessValue = _currentProcessValue;

            return outputToReduceError
                .Clamp(MinimumOutput, MaximumOutput);
        }

        private float CalculateProportionalTerm()
        {
            var processValueError = _desiredValue - _currentProcessValue;

            return _proportionalGain * processValueError;
        }

        private float CalculateIntegralTerm()
        {
            if (_previousRegulateTime == null) return 0.0F;

            var processValueError = _desiredValue - _currentProcessValue;

            var regulateTimeDelta = CalculateTimeBetweenRegulatesInSeconds();

            return _integralTerm + _integralGain * processValueError * regulateTimeDelta;
        }

        private float CalculateDerivativeTerm()
        {
            if (_previousRegulateTime == null) return 0.0F;

            var processValueDelta = _currentProcessValue - _previousProcessValue;

            var regulateTimeDelta = CalculateTimeBetweenRegulatesInSeconds();

            return _derivativeGain * (processValueDelta / regulateTimeDelta);
        }

        private float CalculateTimeBetweenRegulatesInSeconds() => Convert.ToSingle(
            (_currentRegulateTime - _previousRegulateTime)?.TotalSeconds);
    }
}