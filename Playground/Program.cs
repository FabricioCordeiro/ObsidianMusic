//using MediatR;
//using Microsoft.Extensions.DependencyInjection;
//using ObsidianMusic.Application.Queries.MediaInfo;
//using Microsoft.Extensions.Logging;
//using ObsidianMusic.Application;
//using ObsidianMusic.Infrastructure;

//var services = new ServiceCollection();

//// Adiciona logging (MediatR precisa disso. No program, pode ter outros como Serinlog ou algo em Fody)
//services.AddLogging(cfg => cfg.AddConsole());

//services.AddApplicationServices();
//services.AddInfrastructureServices();

//var app = services.BuildServiceProvider();

//var mediator = app.GetRequiredService<IMediator>();

//var query = new GetMediaInfoQuery("zstmOk7jUaw");
//var mediaInfo = await mediator.Send(query);

//Console.WriteLine($"Título: {mediaInfo.Title}");
//Console.WriteLine($"Autor: {mediaInfo.Author.Title}");
//Console.WriteLine($"Duração: {mediaInfo.Duration}");
//Console.WriteLine($"Url: {mediaInfo.Url}");
//Console.WriteLine($"Descrição: {mediaInfo.Description}");

//using MediatR;
//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.Hosting;
//using ObsidianMusic.Application;
//using ObsidianMusic.Application.Queries.MediaSearch;
//using ObsidianMusic.Infrastructure;
//using System.Text;

//Console.OutputEncoding = Encoding.UTF8; // Corrige acentos e caracteres especiais

//using var host = Host.CreateDefaultBuilder()
//    .ConfigureServices(services =>
//    {
//        services.AddInfrastructureServices();
//        services.AddApplicationServices();
//        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(SearchVideosQuery).Assembly));
//    })
//    .Build();

//var mediator = host.Services.GetRequiredService<IMediator>();

//Console.Write("Digite o termo de pesquisa: ");
//var termo = Console.ReadLine()!;

//Console.Write("Digite a quantidade de resultados: ");
//if (!int.TryParse(Console.ReadLine(), out int quantidade))
//    quantidade = 5;

//// envia query via MediatR
//var results = await mediator.Send(new SearchVideosQuery(termo));

//int count = 0;
//await foreach (var item in results)
//{
//    Console.WriteLine($"[{++count}] {item.Title}");
//    if (count >= quantidade) break;
//}






using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ObsidianMusic.Application;
using ObsidianMusic.Application.Queries.MediaSearch;
using ObsidianMusic.Infrastructure;
using System.Text;

Console.OutputEncoding = Encoding.UTF8; // Corrige acentos e caracteres especiais

using var host = Host.CreateDefaultBuilder()
    .ConfigureServices(services =>
    {
        services.AddInfrastructureServices();
        services.AddApplicationServices();
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(SearchVideosQuery).Assembly));
    })
    .Build();

var mediator = host.Services.GetRequiredService<IMediator>();

Console.Write("Digite o termo de pesquisa: ");
var termo = Console.ReadLine()!;

int batchSize = 10; // tamanho do lote que vamos carregar a cada vez
int shown = 0;

var ResearcFlow = await mediator.Send(new SearchVideosQuery(termo));

// iterador sobre os resultados (não consome ainda)
var enumerator = ResearcFlow.GetAsyncEnumerator();

bool continuar = true;
while (continuar)
{
    int count = 0;
    while (count < batchSize && await enumerator.MoveNextAsync())
    {
        var item = enumerator.Current;
        Console.WriteLine($"[{++shown}] {item.Title} - {item.AuthorName} ({item.Duration})");
        Console.WriteLine($"Url: {item.Url}");
        Console.WriteLine(new string('-', 40));
        count++;
    }

    if (count == 0) // acabou os resultados
    {
        Console.WriteLine("🚫 Nenhum resultado adicional encontrado.");
        break;
    }

    Console.WriteLine("Pressione ENTER para carregar mais ou digite 'q' para sair...");
    var input = Console.ReadLine();
    if (input?.Equals("q", StringComparison.OrdinalIgnoreCase) == true)
        continuar = false;
}