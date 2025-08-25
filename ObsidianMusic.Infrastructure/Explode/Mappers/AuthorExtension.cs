using ObsidianMusic.Domain.ValueObjects;

namespace ObsidianMusic.Infrastructure.Explode.Mappers
{
    internal static class AuthorExtension
    {
        public static Author MapToAuthor(this YoutubeExplode.Common.Author author, IReadOnlyList<Thumbnail> authorThumbnails)
        {
            return new(
                author.ChannelId,
                author.ChannelTitle,
                authorThumbnails
            );
        }
    }
}
