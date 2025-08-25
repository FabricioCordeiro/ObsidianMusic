namespace ObsidianMusic.Domain.ValueObjects
{
    public readonly struct Thumbnail(string url, Resolution resolution)
    {
        public string Url { get; } = url;
        public Resolution Resolution { get; } = resolution;
    }
}
