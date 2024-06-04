using MobiPark.Domain.Interfaces;
using MobiPark.Domain.Models;
using MobiPark.Infra.Entities;

namespace MobiPark.Infra.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _context;

    public UserRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public User? FindByUsername(string username)
    {
        var userEntity = _context.Users.FirstOrDefault(u => u.Username == username);
        return userEntity?.ToDomainModel();
    }

    public User? Find(int userId)
    {
        var userEntity = _context.Users.FirstOrDefault(u => u.UserId == userId);
        return userEntity?.ToDomainModel();
    }

    public User Save(User user)
    {
        var userEntity = new UserEntity(user);
        _context.Users.Add(userEntity);
        _context.SaveChanges();
        return userEntity.ToDomainModel();
    }
}