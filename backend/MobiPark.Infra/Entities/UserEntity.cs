using MobiPark.Domain.Models;

namespace MobiPark.Infra.Entities;

public class UserEntity
{
    public int UserId { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    
    public UserEntity() {}

    public UserEntity(User user)
    {
        UserId = user.Id;
        Username = user.Username;
        Password = user.Password;
    }

    public User ToDomainModel()
    {
        return new User(UserId, Username, Password);
    }
}