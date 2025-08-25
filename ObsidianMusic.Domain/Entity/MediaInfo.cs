using ObsidianMusic.Domain.Interfaces.Types;
using ObsidianMusic.Domain.ValueObjects;

namespace ObsidianMusic.Domain.Entity
{
    public class MediaInfo(
        string id,
        string title,
        Author author,
        DateTimeOffset uploadDate,
        string description,
        TimeSpan? duration,
        IReadOnlyList<Thumbnail> thumbnails,
        IReadOnlyList<string> keywords
    ) : IMediaInfo
    {
        public string Id { get; } = id;
        public string Url => $"https://www.youtube.com/watch?v={Id}";
        public string Title { get; } = title;
        public Author Author { get; } = author;
        public DateTimeOffset UploadDate { get; } = uploadDate;
        public string Description { get; } = description;
        public TimeSpan? Duration { get; } = duration;
        public IReadOnlyList<Thumbnail> Thumbnails { get; } = thumbnails;
        public IReadOnlyList<string> Keywords { get; } = keywords;
    }
}