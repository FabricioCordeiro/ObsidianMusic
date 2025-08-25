using ObsidianMusic.Domain.Interfaces.Providers;
using ObsidianMusic.Infrastructure.Explode.Adapters;

Console.OutputEncoding = System.Text.Encoding.UTF8;

IMediaInfoProvider provider = new YoutubeMediaAdapter();

var url = "https://www.youtube.com/watch?v=jq0pIc9qqO8";
var media = await provider.GetMediaInfoAsync(url);

Console.WriteLine("=== Informações da música ===");
Console.WriteLine($"Título: {media.Title}");
Console.WriteLine($"Canal: {media.Author.Title}");
Console.WriteLine($"Upload: {media.UploadDate}");
Console.WriteLine($"Duração: {media.Duration}");
Console.WriteLine($"Descrição: {media.Description}");
Console.WriteLine("Thumbnails:");
foreach (var thumb in media.Thumbnails)
{
    Console.WriteLine($"  {thumb.Url} ({thumb.Resolution.Width}x{thumb.Resolution.Height})");
}
Console.WriteLine("Keywords: " + string.Join(", ", media.Keywords));

Console.ReadLine();