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

    public User? Find(int userId)
    {
        return _users.FirstOrDefault(u => u.Id == userId);
    }

    public User Save(User user)
    {
        user.Id = _users.Count == 0
            ? 1
            : _users.Max(user => user.Id) + 1;
        _users.Add(user);
        return user;
    }
}