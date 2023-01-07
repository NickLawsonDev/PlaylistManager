namespace Core.Application.Features.SongFeatures.Queries;

public record GetSongByIdQuery(Guid Id) : IRequest<Song>;

public class GetSongByIdQueryHandler : IRequestHandler<GetSongByIdQuery, Song>
{
    private readonly IApplicationDbContext _context;

    public GetSongByIdQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Song> Handle(GetSongByIdQuery query, CancellationToken cancellationToken)
    {
        return await ContextGuards.ExistsAsync(_context.Songs, query.Id, $"Could not find Song with Id of {query.Id}");
    }
}