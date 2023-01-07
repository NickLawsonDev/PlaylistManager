using Microsoft.EntityFrameworkCore;

namespace Core.Application.Features.PlaylistFeatures.Queries;

public record GetAllPlaylistsByUserQuery(User User) : IRequest<IEnumerable<Playlist>>;

public class GetAllPlaylistsByUserQueryHandler : IRequestHandler<GetAllPlaylistsByUserQuery, IEnumerable<Playlist>>
{
    private readonly IApplicationDbContext _context;
    
    public GetAllPlaylistsByUserQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Playlist>> Handle(GetAllPlaylistsByUserQuery query, CancellationToken cancellationToken)
    {
        var playlists = await _context.Playlists.Where(x => x.User.Id == query.User.Id).ToListAsync(cancellationToken);
        if (playlists == null)
        {
            return new List<Playlist>();
        }

        return playlists.AsReadOnly();
    }
}