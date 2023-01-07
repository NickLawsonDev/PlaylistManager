namespace Core.Application.Features.UserFeatures.Commands;

public record DeleteUserCommand(Guid Id) : IRequest<int>;

public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, int>
{
    private readonly IApplicationDbContext _context;

    public DeleteUserCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(DeleteUserCommand command, CancellationToken cancellationToken)
    {
        var user = ContextGuards.Exists(_context.Users, command.Id, $"Could not find User with Id of {command.Id}");

        _context.Users.Add(user);
        return await _context.SaveChangesAsync();
    }
}