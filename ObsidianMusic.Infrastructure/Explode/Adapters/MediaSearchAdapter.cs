using ObsidianMusic.Domain.Aggregates.MediaSearch;
using ObsidianMusic.Domain.Ports.Providers;
using ObsidianMusic.Infrastructure.Explode.Mappers;
using YoutubeExplode;
using YoutubeExplode.Search;

namespace ObsidianMusic.Infrastructure.Explode.Adapters
{
    public class MediaSearchAdapter(YoutubeClient youtubeClient) : IMediaSearchProvider
    {
        public async IAsyncEnumerable<IMediaSearch> SearchVideosAsync(string searchQuery)
        {
            await foreach (var batch in youtubeClient.Search.GetResultBatchesAsync(searchQuery, SearchFilter.Video))
            {
                foreach (var result in batch.Items)
                {
                        yield return ((VideoSearchResult)result).MapToMediaSearch();
                }
            }
        }
    }
}
