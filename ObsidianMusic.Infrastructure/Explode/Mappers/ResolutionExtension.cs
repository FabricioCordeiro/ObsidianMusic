using ObsidianMusic.Domain.ValueObjects;

namespace ObsidianMusic.Infrastructure.Explode.Mappers
{
    internal static class ResolutionExtension
    {
        public static Resolution MapToResolution(this YoutubeExplode.Common.Resolution resolution)
        {
            return new(
                resolution.Width,
                resolution.Height
            );
        }
    }
}
