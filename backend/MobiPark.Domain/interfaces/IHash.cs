namespace MobiPark.Domain.Interfaces;

public interface IHash
{
    public string Hash(string input);

    public bool Verify(string input, string hash);
}