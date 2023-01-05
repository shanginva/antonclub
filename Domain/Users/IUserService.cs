namespace Domain.Users;

public interface IUserService
{
    bool IsLoggedIn();

    string UserName { get; }
}
