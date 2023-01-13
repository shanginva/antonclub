namespace Domain.Users;

public interface IUserService
{
    bool IsLoggedIn();

    Task LogOut();

    User? CurrentUser { get; }
}
