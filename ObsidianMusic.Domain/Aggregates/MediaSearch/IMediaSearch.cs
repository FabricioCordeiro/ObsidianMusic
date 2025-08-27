namespace ObsidianMusic.Domain.Aggregates.MediaSearch
{
    public interface IMediaSearch
    {
        public string Id { get; }

        public string Url { get; }

        public string Title { get; }

        public string AuthorName { get; }

        public TimeSpan? Duration { get; }

        public IReadOnlyList<Thumbnail> Thumbnails { get; }
    }
}
