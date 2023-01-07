namespace Core.Application.Features.PlaylistFeatures.Queries;

public record GetPlaylistByIdQuery(Guid Id) : IRequest<Playlist>;

public class GetPlaylistByIdQueryHandler : IRequestHandler<GetPlaylistByIdQuery, Playlist>
{
    private readonly IApplicationDbContext _context;

    public GetPlaylistByIdQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Playlist> Handle(GetPlaylistByIdQuery query, CancellationToken cancellationToken)
    {
        return await ContextGuards.ExistsAsync(_context.Playlists, query.Id, $"Could not find Playlist with Id of {query.Id}");
    }
}