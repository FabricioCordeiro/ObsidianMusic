using ObsidianMusic.Domain.Aggregates.MediaInfo;
using ObsidianMusic.Domain.Ports.Providers;
using ObsidianMusic.Infrastructure.Explode.Mappers;
using YoutubeExplode;

namespace ObsidianMusic.Infrastructure.Explode.Adapters
{
    public class MediaInfoAdapter(YoutubeClient youtubeClient) : IMediaInfoProvider
    {
        public async Task<IMediaInfo> GetMediaInfoAsync(string urlOrId)
        {
            var media = await youtubeClient.Videos.GetAsync(urlOrId);
            var channel = await youtubeClient.Channels.GetAsync(media.Author.ChannelUrl);

            return media.MapToMediaInfo(channel.Thumbnails);
        }
    }
}