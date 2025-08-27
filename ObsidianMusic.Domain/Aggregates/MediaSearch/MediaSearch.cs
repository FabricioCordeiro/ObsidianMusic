namespace ObsidianMusic.Domain.Aggregates.MediaSearch
{
    public class MediaSearch(
        string id,
        string title,
        string author,
        TimeSpan? duration,
        IReadOnlyList<Thumbnail> thumbnails
    ) : IMediaSearch
    {
        public string Id { get; } = id;
        public string Url => $"https://www.youtube.com/watch?v={Id}";
        public string Title { get; } = title;
        public string AuthorName { get; } = author;
        public TimeSpan? Duration { get; } = duration;
        public IReadOnlyList<Thumbnail> Thumbnails { get; } = thumbnails;
    }
}
