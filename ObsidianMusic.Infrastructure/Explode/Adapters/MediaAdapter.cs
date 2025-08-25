using ObsidianMusic.Domain.Aggregates.Media;
using ObsidianMusic.Domain.Ports.Providers;
using ObsidianMusic.Infrastructure.Explode.Mappers;
using YoutubeExplode;

namespace ObsidianMusic.Infrastructure.Explode.Adapters
{
    public class MediaAdapter : IMediaInfoProvider
    {
        private readonly YoutubeClient _youtube;

        public MediaAdapter()
        {
            _youtube = new YoutubeClient();
        }

        public async Task<IMediaInfo> GetMediaInfoAsync(string urlOrId)
        {
            var media = await _youtube.Videos.GetAsync(urlOrId);
            var channel = await _youtube.Channels.GetAsync(media.Author.ChannelUrl);

            return media.MapToMediaInfo(channel.Thumbnails);
        }
    }
}