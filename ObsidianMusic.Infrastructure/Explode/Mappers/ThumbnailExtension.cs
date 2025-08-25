using ObsidianMusic.Domain.ValueObjects;

namespace ObsidianMusic.Infrastructure.Explode.Mappers
{
    internal static class ThumbnailExtension
    {
        public static Thumbnail MapToThumbnail(this YoutubeExplode.Common.Thumbnail thumbnail)
        {
            return new(
                thumbnail.Url,
                thumbnail.Resolution.MapToResolution()
            );
        }

        public static IReadOnlyList<Thumbnail> MapToThumbnails(this IReadOnlyList<YoutubeExplode.Common.Thumbnail> thumbnails)
        {
            return [.. thumbnails.Select(t => t.MapToThumbnail())];
        }
    }
}
