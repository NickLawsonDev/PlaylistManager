namespace Core.Application.Features.PlaylistFeatures.Commands;

public record UpdatePlaylistCommand(Guid Id, string Name, IEnumerable<Song> Songs, User User) : IRequest<Playlist>;

public class UpdatePlaylistCommandHandler : IRequestHandler<UpdatePlaylistCommand, Playlist>
{
    private readonly IApplicationDbContext _context;

    public UpdatePlaylistCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<Playlist> Handle(UpdatePlaylistCommand command, CancellationToken cancellationToken)
    {
        var playlist = ContextGuards.Exists(_context.Playlists, command.Id, $"Could not find Playlist with Id of {command.Id}");

        _context.Playlists.Add(playlist);
        await _context.SaveChangesAsync();
        return playlist;
    }
}