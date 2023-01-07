namespace Core.Application.Features.UserFeatures.Commands;

public record CreateUserCommand(string FirstName, string LastName, string Email, string Password, IEnumerable<Playlist> Playlists) : IRequest<User>;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, User>
{
    private readonly IApplicationDbContext _context;

    public CreateUserCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<User> Handle(CreateUserCommand command, CancellationToken cancellationToken)
    {
        var user = new User(command.FirstName, command.LastName, command.Email, command.Password, command.Playlists);

        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return user;
    }
}