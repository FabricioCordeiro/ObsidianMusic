using MediatR;
using ObsidianMusic.Application.Queries.MediaInfo;
using ObsidianMusic.Domain.Aggregates.MediaInfo;
using ObsidianMusic.Domain.Ports.Providers;

namespace ObsidianMusic.Application.Handlers.Media
{
    public class GetMediaInfoHandler(IMediaInfoProvider mediaInfoProvider) 
        : IRequestHandler<GetMediaInfoQuery, IMediaInfo>
    {
        private readonly IMediaInfoProvider _mediaInfoProvider = mediaInfoProvider;

        public async Task<IMediaInfo> Handle(GetMediaInfoQuery request, CancellationToken cancellationToken)
        {
            return await _mediaInfoProvider.GetMediaInfoAsync(request.UrlOrId);
        }
    }
}
