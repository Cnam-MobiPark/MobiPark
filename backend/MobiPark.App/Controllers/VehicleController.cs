using Microsoft.AspNetCore.Mvc;
using MobiPark.App.Presenters;
using MobiPark.Domain.Interfaces;

namespace MobiPark.App.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleService _vehicleService;

        public VehicleController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        [HttpGet]
        public IActionResult GetVehicles()
        {
            var vehicles = _vehicleService.GetVehicles();
            var vehiclePresenters = vehicles.Result.ConvertAll(v => new VehiclePresenter(v));
            return Ok(vehiclePresenters);
        }
    }
}