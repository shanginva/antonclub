using Domain.Users;
using Microsoft.AspNetCore.Identity;

namespace AntonClub;

public class UserService : IUserService
{
    private readonly SignInManager<IdentityUser> signInManager;
    private readonly IHttpContextAccessor httpContextAccessor;

    public UserService(SignInManager<IdentityUser> signInManager, IHttpContextAccessor httpContextAccessor)
    {
        this.signInManager = signInManager;
        this.httpContextAccessor = httpContextAccessor;
    }

    public User? CurrentUser => httpContextAccessor.HttpContext?.User?.Identity?.Name switch
    {
        { } name => new User(name),
        null => null
    };

    public bool IsLoggedIn() => httpContextAccessor.HttpContext?.User != null 
        && signInManager.IsSignedIn(httpContextAccessor.HttpContext.User);

    public Task LogOut() => signInManager.SignOutAsync();
}
