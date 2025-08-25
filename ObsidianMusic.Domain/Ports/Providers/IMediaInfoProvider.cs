using ObsidianMusic.Domain.Aggregates.MediaInfo;

namespace ObsidianMusic.Domain.Ports.Providers
{
    public interface IMediaInfoProvider
    {
        Task<IMediaInfo> GetMediaInfoAsync(string urlOrId);
    }
}
