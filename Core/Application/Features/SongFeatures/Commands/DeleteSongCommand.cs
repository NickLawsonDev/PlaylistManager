namespace Core.Application.Features.SongFeatures.Commands;

public record DeleteSongCommand(Guid Id) : IRequest<int>;

public class DeleteSongCommandHandler : IRequestHandler<DeleteSongCommand, int>
{
    private readonly IApplicationDbContext _context;

    public DeleteSongCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(DeleteSongCommand command, CancellationToken cancellationToken)
    {
        var song = ContextGuards.Exists(_context.Songs, command.Id, $"Could not find Song with Id of {command.Id}");

        _context.Songs.Add(song);
        return await _context.SaveChangesAsync();
    }
}