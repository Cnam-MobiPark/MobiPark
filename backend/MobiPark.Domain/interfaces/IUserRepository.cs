using MobiPark.Domain.Models;

namespace MobiPark.Domain.Interfaces;

public interface IUserRepository
{
    public User? FindByUsername(string username);
    public User? Find(int userId);
}