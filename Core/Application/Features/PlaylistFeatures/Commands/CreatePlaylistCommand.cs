namespace Core.Application.Features.PlaylistFeatures.Commands;

public record CreatePlaylistCommand(string Name, IEnumerable<Song> Songs, User User) : IRequest<Playlist>;

public class CreatePlaylistCommandHandler : IRequestHandler<CreatePlaylistCommand, Playlist>
{
    private readonly IApplicationDbContext _context;

    public CreatePlaylistCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<Playlist> Handle(CreatePlaylistCommand command, CancellationToken cancellationToken)
    {
        var playlist = new Playlist(command.Name, command.User, command.Songs);

        _context.Playlists.Add(playlist);
        await _context.SaveChangesAsync();
        return playlist;
    }
}