using System;

namespace Starship.Utility.Math
{
    // Currently under development
    public sealed class PidRegulator
    {
        private readonly float _minimumOutput;
        private readonly float _maximumOutput;
        private readonly float _proportionalGain;
        private readonly float _integralGain;
        private readonly float _derivativeGain;

        private DateTime? _currentRegulateTime;
        private DateTime? _previousRegulateTime;

        private float _currentDesiredValue;

        private float _currentProcessValue;
        private float _previousProcessValue;

        private float _proportionalTerm;
        private float _integralTerm;
        private float _derivativeTerm;


        public PidRegulator(
            float minimumOutput,
            float maximumOutput,
            float proportionalGain,
            float integralGain,
            float derivativeGain)
        {
            _minimumOutput = minimumOutput;
            _maximumOutput = maximumOutput;
            _proportionalGain = proportionalGain;
            _integralGain = integralGain;
            _derivativeGain = derivativeGain;
        }

        public float RegulateValue(float desiredValue, float processValue)
        {
            _currentRegulateTime = DateTime.Now;
            _currentDesiredValue = desiredValue;
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
                .Clamp(_minimumOutput, _maximumOutput);
        }

        private float CalculateProportionalTerm()
        {
            var processValueError = _currentDesiredValue - _currentProcessValue;

            return _proportionalGain * processValueError;
        }

        private float CalculateIntegralTerm()
        {
            if (_previousRegulateTime == null) return 0.0F;

            var processValueError = _currentDesiredValue - _currentProcessValue;

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