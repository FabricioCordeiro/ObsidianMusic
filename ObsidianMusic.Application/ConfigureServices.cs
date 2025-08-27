using Microsoft.Extensions.DependencyInjection;

namespace ObsidianMusic.Application
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(cfg =>
            {
                cfg.LicenseKey = string.Empty; // Adicione sua chave de licença MediatR aqui
                cfg.RegisterServicesFromAssembly(typeof(ConfigureServices).Assembly);
            });

            return services;
        }
    }
}