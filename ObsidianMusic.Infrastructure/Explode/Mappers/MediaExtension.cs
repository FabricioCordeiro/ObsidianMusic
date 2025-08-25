using ObsidianMusic.Domain.Aggregates.MediaInfo;

namespace ObsidianMusic.Infrastructure.Explode.Mappers
{
    internal static class MediaExtension
    {
        public static MediaInfo MapToMediaInfo(this YoutubeExplode.Videos.Video video, 
            IReadOnlyList<YoutubeExplode.Common.Thumbnail> authorThumbnails)
        {
            return new(
                video.Id.Value,
                video.Title,
                video.Author.MapToAuthor(authorThumbnails.MapToThumbnails()),
                video.UploadDate,
                video.Description,
                video.Duration ?? TimeSpan.Zero,
                video.Thumbnails.MapToThumbnails(),
                video.Keywords
            );
        }
    }
}
