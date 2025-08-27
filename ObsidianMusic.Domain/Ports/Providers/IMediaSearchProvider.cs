using ObsidianMusic.Domain.Aggregates.MediaSearch;

namespace ObsidianMusic.Domain.Ports.Providers
{
    public interface IMediaSearchProvider
    {
        IAsyncEnumerable<IMediaSearch> SearchVideosAsync(string searchQuery);
    }
}