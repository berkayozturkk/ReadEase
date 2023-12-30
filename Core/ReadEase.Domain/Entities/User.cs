using ReadEase.Domain.Abstraction;

namespace ReadEase.Domain.Entities;

public class User :  Entity
{
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public DateTime? RegistrationDate { get; set; }
    public string? RefreshToken { get; set; }
    public DateTime? RefreshTokenExpries { get; set; }

    public User(){}
}
