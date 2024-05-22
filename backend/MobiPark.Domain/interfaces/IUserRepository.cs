using MobiPark.Domain.Models;

namespace MobiPark.Domain.Interfaces;

public interface IUserRepository
{
    public User? FindUserByUsername(string username);
}