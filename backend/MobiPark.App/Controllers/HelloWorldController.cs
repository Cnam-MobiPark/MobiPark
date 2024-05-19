using Microsoft.AspNetCore.Mvc;
using MobiPark.Dom.Services.Interfaces;

namespace MobiPark.App.Controllers
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