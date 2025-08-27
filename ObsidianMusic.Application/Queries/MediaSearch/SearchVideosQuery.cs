using MediatR;
using ObsidianMusic.Domain.Aggregates.MediaSearch;

namespace ObsidianMusic.Application.Queries.MediaSearch
{
    public record SearchVideosQuery(string SearchTerm) : IRequest<IAsyncEnumerable<IMediaSearch>>;
}