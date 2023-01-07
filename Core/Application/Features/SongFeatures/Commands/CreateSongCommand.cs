namespace Core.Application.Features.SongFeatures.Commands;

public record CreateSongCommand(string Name, double Length, string Lyrics) : IRequest<Song>;

public class CreateSongCommandHandler : IRequestHandler<CreateSongCommand, Song>
{
    private readonly IApplicationDbContext _context;

    public CreateSongCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<Song> Handle(CreateSongCommand command, CancellationToken cancellationToken)
    {
        var song = new Song(command.Name, command.Length, command.Lyrics);

        _context.Songs.Add(song);
        await _context.SaveChangesAsync();
        return song;
    }
}