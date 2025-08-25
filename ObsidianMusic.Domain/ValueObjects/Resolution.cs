namespace ObsidianMusic.Domain.ValueObjects
{
    public readonly struct Resolution(int width, int height)
    {
        public int Width { get; } = width;
        public int Height { get; } = height;
        public int Area => Width * Height;
    }
}
