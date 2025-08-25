using ObsidianMusic.Domain.ValueObjects;

namespace ObsidianMusic.Domain.Interfaces.Types
{
    public interface IMediaInfo
    {
        public string Id { get; }

        public string Url { get; }

        public string Title { get; }

        public Author Author { get; }

        public DateTimeOffset UploadDate { get; }

        public string Description { get; }

        public TimeSpan? Duration { get; }

        public IReadOnlyList<Thumbnail> Thumbnails { get; }

        public IReadOnlyList<string> Keywords { get; }
    }
}
