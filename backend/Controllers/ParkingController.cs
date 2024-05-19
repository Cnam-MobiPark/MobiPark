using Microsoft.AspNetCore.Mvc;
using MobiPark.Services.Interfaces;

namespace MobiPark.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ParkingController : ControllerBase
    {
        private readonly IParkingService _parkingService;

        public ParkingController(IParkingService parkingService)
        {
            _parkingService = parkingService;
        }

        [HttpGet("spaces")]
        public IActionResult GetSpaces()
        {
            var spaces = _parkingService.GetSpaces();
            return Ok(spaces);
        }
    }
}
