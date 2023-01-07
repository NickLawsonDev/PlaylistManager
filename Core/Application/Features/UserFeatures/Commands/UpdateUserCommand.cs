namespace Core.Application.Features.UserFeatures.Commands;

public record UpdateUserCommand(Guid Id, string FirstName, string LastName, string Email, string Password, IEnumerable<Playlist> Playlists) : IRequest<User>;

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, User>
{
    private readonly IApplicationDbContext _context;

    public UpdateUserCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<User> Handle(UpdateUserCommand command, CancellationToken cancellationToken)
    {
        var user = ContextGuards.Exists<User>(_context.Users, command.Id, $"Could not find User with Id of {command.Id}");

        user.FirstName = command.FirstName;
        user.LastName = command.LastName;
        user.Email = command.Email;
        user.Password = command.Password;
        user.Playlists = command.Playlists;

        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return user;
    }
}