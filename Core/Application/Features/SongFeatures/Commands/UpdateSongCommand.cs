namespace Core.Application.Features.SongFeatures.Commands;

public record UpdateSongCommand(Guid Id, string Name, double Length, string Lyrics) : IRequest<Song>;

public class UpdateSongCommandHandler : IRequestHandler<UpdateSongCommand, Song>
{
    private readonly IApplicationDbContext _context;

    public UpdateSongCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<Song> Handle(UpdateSongCommand command, CancellationToken cancellationToken)
    {
        var song = ContextGuards.Exists<Song>(_context.Songs, command.Id, $"Could not find Song with Id of {command.Id}");

        song.Name = command.Name;
        song.Length = command.Length;
        song.Lyrics = command.Lyrics;

        _context.Songs.Add(song);
        await _context.SaveChangesAsync();
        return song;
    }
}