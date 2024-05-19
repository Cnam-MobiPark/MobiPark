using MobiPark.Dom.Services.Interfaces;

namespace MobiPark.Dom.Services
{
    public class GreetingService : IGreetingService
    {
        public string Greet(string name)
        {
            return $"Hello, {name}!";
        }
    }
}