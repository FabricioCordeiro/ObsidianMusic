namespace ObsidianMusic.Domain.ValueObjects
{
    public readonly struct Author(string id, string title, IReadOnlyList<Thumbnail> thumbnails)
    {
        public string Id { get; } = id;
        public string Url => $"https://www.youtube.com/channel/{Id}";
        public string Title { get; } = title;
        public IReadOnlyList<Thumbnail> Thumbnails { get; } = thumbnails;
    }
}
