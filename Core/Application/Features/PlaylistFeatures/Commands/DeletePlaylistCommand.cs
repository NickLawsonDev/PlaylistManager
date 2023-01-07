namespace Core.Application.Features.PlaylistFeatures.Commands;

public record DeletePlaylistCommand(Guid Id) : IRequest<int>;

public class DeletePlaylistCommandHandler : IRequestHandler<DeletePlaylistCommand, int>
{
    private readonly IApplicationDbContext _context;

    public DeletePlaylistCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(DeletePlaylistCommand command, CancellationToken cancellationToken)
    {
        var playlist = ContextGuards.Exists(_context.Playlists, command.Id, $"Could not find Playlist with Id of {command.Id}");

        _context.Playlists.Add(playlist);
        return await _context.SaveChangesAsync();
    }
}