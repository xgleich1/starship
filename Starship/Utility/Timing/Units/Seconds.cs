namespace Starship.Utility.Timing.Units
{
    public readonly struct Seconds
    {
        public long Quantity { get; }


        public Seconds(long quantity) =>
            Quantity = quantity;
    }
}