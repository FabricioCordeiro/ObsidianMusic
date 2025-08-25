//using ObsidianMusic.Domain.Ports.Providers;
//using ObsidianMusic.Infrastructure.Explode.Adapters;

//Console.OutputEncoding = System.Text.Encoding.UTF8;

//IMediaInfoProvider provider = new MediaAdapter();

//var url = "https://www.youtube.com/watch?v=jq0pIc9qqO8";
//var media = await provider.GetMediaInfoAsync(url);

//Console.WriteLine("=== Informações da música ===");
//Console.WriteLine($"Título: {media.Title}");
//Console.WriteLine($"Canal: {media.Author.Title}");
//Console.WriteLine($"Upload: {media.UploadDate}");
//Console.WriteLine($"Duração: {media.Duration}");
//Console.WriteLine($"Descrição: {media.Description}");
//Console.WriteLine("Thumbnails:");
//foreach (var thumb in media.Thumbnails)
//{
//    Console.WriteLine($"  {thumb.Url} ({thumb.Resolution.Width}x{thumb.Resolution.Height})");
//}
//Console.WriteLine("Keywords: " + string.Join(", ", media.Keywords));

//Console.ReadLine();

using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ObsidianMusic.Application.Handlers.Media;
using ObsidianMusic.Application.Queries.Media;
using ObsidianMusic.Domain.Ports.Providers;
using ObsidianMusic.Infrastructure.Explode.Adapters;
using Microsoft.Extensions.Logging;

var services = new ServiceCollection();

// Adiciona logging
services.AddLogging(cfg => cfg.AddConsole());

services.AddMediatR(cfg =>
{
    // Não é critico, é para uso do MediatR. Mas convém usar keyvault ou outra coisa do genero
    
    cfg.RegisterServicesFromAssembly(typeof(GetMediaInfoQuery).Assembly);
});

// Registrar adapter da Infra
services.AddSingleton<IMediaInfoProvider, MediaInfoAdapter>();

var provider = services.BuildServiceProvider();

// Obter MediatR
var mediator = provider.GetRequiredService<IMediator>();

// Teste com um vídeo
var query = new ObsidianMusic.Application.Queries.Media.GetMediaInfoQuery("https://youtube.com/watch?v=u_yIGGhubZs");
var mediaInfo = await mediator.Send(query);

Console.WriteLine($"Título: {mediaInfo.Title}");
Console.WriteLine($"Autor: {mediaInfo.Author.Title}");
Console.WriteLine($"Duração: {mediaInfo.Duration}");
Console.WriteLine($"Url: {mediaInfo.Url}");
