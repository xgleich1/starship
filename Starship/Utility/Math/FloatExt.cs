using UnityEngine;

namespace Starship.Utility.Math
{
    public static class FloatExt
    {
        public static float Clamp(this float value, float minimum, float maximum)
        {
            if (value < minimum)
            {
                return minimum;
            }

            if (value > maximum)
            {
                return maximum;
            }

            return value;
        }

        public static bool ApproximatelyEquals(this float value, float other, float tolerance) =>
            Mathf.Abs(value - other) <= tolerance;
    }
}