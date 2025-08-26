using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ObsidianMusic.Application.Queries.Media;
using Microsoft.Extensions.Logging;
using ObsidianMusic.Application;
using ObsidianMusic.Infrastructure;

var services = new ServiceCollection();

// Adiciona logging (MediatR precisa disso. No program, pode ter outros como Serinlog ou algo em Fody)
services.AddLogging(cfg => cfg.AddConsole());

services.AddApplicationServices();
services.AddInfrastructureServices();

var app = services.BuildServiceProvider();

var mediator = app.GetRequiredService<IMediator>();

var query = new GetMediaInfoQuery("zstmOk7jUaw");
var mediaInfo = await mediator.Send(query);

Console.WriteLine($"Título: {mediaInfo.Title}");
Console.WriteLine($"Autor: {mediaInfo.Author.Title}");
Console.WriteLine($"Duração: {mediaInfo.Duration}");
Console.WriteLine($"Url: {mediaInfo.Url}");
