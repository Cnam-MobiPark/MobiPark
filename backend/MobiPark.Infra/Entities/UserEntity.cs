using MobiPark.Domain.Models;

namespace MobiPark.Infra.Entities;

public class UserEntity
{
    public int UserId { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }

    public User ToDomainModel()
    {
        return new User(UserId, Username, Password);
    }
}