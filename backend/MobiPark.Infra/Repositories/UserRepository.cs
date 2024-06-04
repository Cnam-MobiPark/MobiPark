using MobiPark.Domain.Interfaces;
using MobiPark.Domain.Models;

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
}