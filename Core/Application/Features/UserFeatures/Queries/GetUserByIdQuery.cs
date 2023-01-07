namespace Core.Application.Features.UserFeatures.Queries;

public record GetUserByIdQuery(Guid Id) : IRequest<User>;

public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, User>
{
    private readonly IApplicationDbContext _context;

    public GetUserByIdQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<User> Handle(GetUserByIdQuery query, CancellationToken cancellationToken)
    {
        return await ContextGuards.ExistsAsync(_context.Users, query.Id, $"Could not find User with Id of {query.Id}");
    }
}