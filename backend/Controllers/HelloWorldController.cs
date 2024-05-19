using Microsoft.AspNetCore.Mvc;
using MobiPark.Services.Interfaces;

namespace MobiPark.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HelloWorldController : ControllerBase
    {
        private readonly IGreetingService _greetingService;

        public HelloWorldController(IGreetingService greetingService)
        {
            _greetingService = greetingService;
        }

        [HttpGet("sayhello/{name}")]
        public IActionResult SayHello(string name)
        {
            var greeting = _greetingService.Greet(name);
            return Ok(greeting);
        }
    }
}
