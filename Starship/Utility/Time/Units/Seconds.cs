namespace Starship.Utility.Time.Units
{
    public readonly struct Seconds
    {
        public long Quantity { get; }


        public Seconds(long quantity) => Quantity = quantity;

        public static bool operator <(Seconds left, Seconds right) => left.Quantity < right.Quantity;

        public static bool operator <=(Seconds left, Seconds right) => left.Quantity <= right.Quantity;

        public static bool operator >(Seconds left, Seconds right) => left.Quantity > right.Quantity;

        public static bool operator >=(Seconds left, Seconds right) => left.Quantity >= right.Quantity;
    }
}