using System.Security.Cryptography;
using MobiPark.Domain.Interfaces;

namespace MobiPark.Infra.Repositories;

public class ArgonHash : IHash
{
    private Argon2PasswordHasher _hasher;
    
    public ArgonHash()
    {
        _hasher = new Argon2PasswordHasher();
    }
    
    public string Hash(string input)
    {
        return _hasher.Hash(input);
    }

    public bool Verify(string input, string hash)
    {
        return _hasher.Verify(input, hash);
    }
}