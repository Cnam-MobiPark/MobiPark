using Microsoft.AspNetCore.Mvc;
using MobiPark.App.Presenters;
using MobiPark.Domain.Interfaces;

namespace MobiPark.App.Controllers
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
            var spacePresenters = spaces.Select(space => new ParkingSpacePresenter(space)).ToList();
            return Ok(spacePresenters);
        }
        
        [HttpPut("spaces/park")]
        public IActionResult ParkCar([FromBody] ParkVehicleRequest request)
        {
            var space = _parkingService.ParkVehicle(request.Vehicle);
            return Ok(new ParkingSpacePresenter(space));
        }
    }
}