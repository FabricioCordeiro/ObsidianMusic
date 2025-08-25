using ObsidianMusic.Domain.Entity;

namespace ObsidianMusic.Infrastructure.Explode.Mappers
{
    internal static class YoutubeMediaToDomainMapper
    {
        public static MediaInfo Map(YoutubeExplode.Videos.Video video, YoutubeExplode.Channels.Channel channel) =>
            new(
                video.Id.Value,
                video.Title,
                new Domain.ValueObjects.Author(
                    video.Author.ChannelId,
                    video.Author.ChannelTitle,
                    ConvertThumbs(channel.Thumbnails)
                ),
                video.UploadDate,
                video.Description,
                video.Duration ?? TimeSpan.Zero,
                ConvertThumbs(video.Thumbnails),
                video.Keywords
            );
        

        private static IReadOnlyList<Domain.ValueObjects.Thumbnail> ConvertThumbs(
            IReadOnlyList<YoutubeExplode.Common.Thumbnail> explodeThumbs) =>
            [.. explodeThumbs
                .Select(item => new Domain.ValueObjects.Thumbnail(
                    item.Url,
                    new Domain.ValueObjects.Resolution(
                        item.Resolution.Width,
                        item.Resolution.Height
                    )
                ))
            ];
    }
}
