using MediatR;
using ObsidianMusic.Application.Queries.MediaSearch;
using ObsidianMusic.Domain.Aggregates.MediaSearch;
using ObsidianMusic.Domain.Ports.Providers;

namespace ObsidianMusic.Application.Handlers.MediaSearch
{
    public class SearchVideosHandler(IMediaSearchProvider searchProvider) : IRequestHandler<SearchVideosQuery, IAsyncEnumerable<IMediaSearch>>
    {
        private readonly IMediaSearchProvider _searchProvider = searchProvider;

        public Task<IAsyncEnumerable<IMediaSearch>> Handle(SearchVideosQuery request, CancellationToken cancellationToken)
        {
            // Só repassa o IAsyncEnumerable, sem materializar ainda
            var results = _searchProvider.SearchVideosAsync(request.SearchTerm);

            return Task.FromResult(results);
        }
    }
}