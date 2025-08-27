using ObsidianMusic.Domain.Aggregates.MediaSearch;
using YoutubeExplode.Search;

namespace ObsidianMusic.Infrastructure.Explode.Mappers
{
    internal static class MediaSearchExtension
    {
        public static MediaSearch MapToMediaSearch(this VideoSearchResult videoSearchResult)
        {
            return new(
                videoSearchResult.Id.Value,
                videoSearchResult.Title,
                videoSearchResult.Author.ChannelTitle,
                videoSearchResult.Duration ?? TimeSpan.Zero,
                videoSearchResult.Thumbnails.MapToThumbnails()
            );
        }
    }
}
