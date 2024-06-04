using MobiPark.Domain.Interfaces;
using MobiPark.Domain.Models;

namespace MobiPark.Domain.Test.Repository;

public class FakeUserRepository : IUserRepository
{
    private readonly List<User> _users;

    public FakeUserRepository(List<User> users)
    {
        _users = users;
    }

    public User? FindByUsername(string username)
    {
        return _users.FirstOrDefault(u => u.Username == username);
    }
}