using MobiPark.Domain.Interfaces;

namespace MobiPark.Domain.Test.Repository;

public class FakeHash : IHash
{
    public string Hash(string input)
    {
        return input;
    }

    public bool Verify(string input, string hash)
    {
        return input == hash;
    }
}