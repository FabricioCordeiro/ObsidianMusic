using Microsoft.Extensions.DependencyInjection;
using ObsidianMusic.Domain.Ports.Providers;
using ObsidianMusic.Infrastructure.Explode.Adapters;
using YoutubeExplode;

namespace ObsidianMusic.Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddSingleton(new YoutubeClient());
            services.AddSingleton<IMediaInfoProvider, MediaInfoAdapter>();
            services.AddSingleton<IMediaSearchProvider, MediaSearchAdapter>();

            return services;
        }
    }
}
