namespace BillyAuthenticationApi.Repositories;

public interface IUserRepository
{
    string? AuthenticateUser(string email, string password);
}