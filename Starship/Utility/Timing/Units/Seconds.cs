namespace Starship.Utility.Timing.Units
{
    public readonly struct Seconds
    {
        public long Quantity { get; }


        public Seconds(long quantity) => Quantity = quantity;

        public override string ToString() => $"Seconds({Quantity})";

        public static bool operator <(Seconds left, Seconds right) => CompareQuantity(left, right) < 0;

        public static bool operator <=(Seconds left, Seconds right) => CompareQuantity(left, right) <= 0;

        public static bool operator >(Seconds left, Seconds right) => CompareQuantity(left, right) > 0;

        public static bool operator >=(Seconds left, Seconds right) => CompareQuantity(left, right) >= 0;

        private static int CompareQuantity(Seconds left, Seconds right) => left.Quantity.CompareTo(right.Quantity);
    }
}