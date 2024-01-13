
namespace BillyAuthenticationApi.Models;

public class UserResponse
{
    public UserResponse(string? id, string firstName, string lastName, string email, string password)
    {
        this.Id = id;
        this.Email = email;
        this.FirstName = firstName;
        this.LastName = lastName;
        this.password = password;
    }
    public string? Id { get; }
    public string FirstName { get; }
    public string LastName { get; }
    public string Email { get; }
    public string password { get; }
}