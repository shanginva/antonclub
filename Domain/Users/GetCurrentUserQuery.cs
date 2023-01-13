using OpenTools.Mediator.Abstrations;

namespace Domain.Users;

public class GetCurrentUserQuery: IQuery<User?> { }

public class GetCurrentUserQueryHandler
    : IQueryHandler<GetCurrentUserQuery, User?>
{
    private readonly IUserService userService;

    public GetCurrentUserQueryHandler(IUserService userService)
    {
        this.userService = userService;
    }

    public Task<User?> Handle(
        GetCurrentUserQuery query, 
        CancellationToken cancellationToken) => Task.FromResult(userService.CurrentUser);
}
