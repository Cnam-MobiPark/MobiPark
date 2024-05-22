using MobiPark.Domain.Interfaces;
using MobiPark.Domain.Models;

namespace MobiPark.Domain.Test.Repository;

public class UserRepository(User[] users) : IUserRepository
{
    public User? FindUserByUsername(string username)
    {
        return users.FirstOrDefault(u => u.Username == username);
    }
}