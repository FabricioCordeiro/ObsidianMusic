using ObsidianMusic.Domain.Aggregates.Media;

namespace ObsidianMusic.Domain.Ports.Providers
{
    public interface IMediaInfoProvider
    {
        Task<IMediaInfo> GetMediaInfoAsync(string urlOrId);
    }
}
