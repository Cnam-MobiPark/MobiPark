using MobiPark.Domain.Interfaces;

namespace MobiPark.Domain.Services
{
    public class GreetingService : IGreetingService
    {
        public string Greet(string name)
        {
            return $"Hello, {name}!";
        }
    }
}