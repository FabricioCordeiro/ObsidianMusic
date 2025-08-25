using ObsidianMusic.Domain.Interfaces.Types;

namespace ObsidianMusic.Domain.Interfaces.Providers
{
    public interface IMediaInfoProvider
    {
        Task<IMediaInfo> GetMediaInfoAsync(string urlOrId);
    }
}
