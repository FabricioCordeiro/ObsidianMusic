using MediatR;
using ObsidianMusic.Domain.Aggregates.MediaInfo;

namespace ObsidianMusic.Application.Queries.MediaInfo
{
    public record GetMediaInfoQuery(string UrlOrId) : IRequest<IMediaInfo>;
}
