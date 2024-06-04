using Microsoft.AspNetCore.Mvc;
using MobiPark.App.Presenters;
using MobiPark.Domain.Interfaces;
using MobiPark.Domain.Models.Vehicle;
using System.Linq;
using System.Threading.Tasks;

namespace MobiPark.App.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ParkingController : ControllerBase
    {
        private readonly IParkingService _parkingService;
        private readonly IVehicleRepository _vehicleRepository;

        public ParkingController(IParkingService parkingService, IVehicleRepository vehicleRepository)
        {
            _parkingService = parkingService;
            _vehicleRepository = vehicleRepository;
        }

        [HttpGet("spaces")]
        public async Task<IActionResult> GetSpaces()
        {
            var spaces = await _parkingService.GetSpaces();
            var spacePresenters = spaces.Select(space => new ParkingSpacePresenter(space)).ToList();
            return Ok(spacePresenters);
        }

        [HttpGet("spaces/available")]
        public async Task<IActionResult> GetAvailableSpaces()
        {
            var spaces = await _parkingService.GetAvailableSpaces();
            var spacePresenters = spaces.Select(space => new ParkingSpacePresenter(space)).ToList();
            return Ok(spacePresenters);
        }

        [HttpGet("spaces/availableFor/{licensePlate}")]
        public async Task<IActionResult> GetAvailableSpacesFor(string licensePlate)
        {
            var vehicle = await _vehicleRepository.FindByPlate(licensePlate);
            if (vehicle == null)
            {
                return NotFound($"Vehicle with license plate {licensePlate} not found.");
            }

            var spaces = await _parkingService.GetAvailableSpacesFor(vehicle);
            var spacePresenters = spaces.Select(space => new ParkingSpacePresenter(space)).ToList();
            return Ok(spacePresenters);
        }

        [HttpPut("spaces/park")]
        public async Task<IActionResult> ParkCar(string licensePlate)
        {
            var result = await _parkingService.ParkVehicle(licensePlate);
            return Ok(new ParkingSpacePresenter(result));
        }
    }
}
