using MediatR;
using ObsidianMusic.Domain.Aggregates.MediaInfo;

namespace ObsidianMusic.Application.Queries.Media
{
    public record GetMediaInfoQuery(string UrlOrId) : IRequest<IMediaInfo>;
}
