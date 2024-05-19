using MobiPark.Services.Interfaces;

namespace MobiPark.Services
{
    public class GreetingService : IGreetingService
    {
        public string Greet(string name)
        {
            return $"Hello, {name}!";
        }
    }
}