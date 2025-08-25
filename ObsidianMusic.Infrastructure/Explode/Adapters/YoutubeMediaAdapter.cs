using ObsidianMusic.Domain.Interfaces.Providers;
using ObsidianMusic.Domain.Interfaces.Types;
using ObsidianMusic.Infrastructure.Explode.Mappers;
using YoutubeExplode;

namespace ObsidianMusic.Infrastructure.Explode.Adapters
{
    public class YoutubeMediaAdapter : IMediaInfoProvider
    {
        private readonly YoutubeClient _youtube;

        public YoutubeMediaAdapter()
        {
            _youtube = new YoutubeClient();
        }

        public async Task<IMediaInfo> GetMediaInfoAsync(string urlOrId)
        {
            var media = await _youtube.Videos.GetAsync(urlOrId);
            var channel = await _youtube.Channels.GetAsync(media.Author.ChannelUrl);

            return YoutubeMediaToDomainMapper.Map(media, channel);
        }
    }
}