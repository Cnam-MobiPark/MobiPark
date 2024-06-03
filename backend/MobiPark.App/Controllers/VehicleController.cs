using Microsoft.AspNetCore.Mvc;
using MobiPark.App.DTO;
using MobiPark.App.Presenters;
using MobiPark.Domain.Interfaces;
using MobiPark.Domain.Models.Vehicle.Engine;
using MobiPark.Domain.Models.Vehicle.LicensePlate;

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
        
        [HttpGet("{licensePlate}")]
        public IActionResult GetVehicle(string licensePlate)
        {
            var vehicle = _vehicleService.GetVehicle(licensePlate);
            return Ok(new VehiclePresenter(vehicle.Result));
        }
        
        [HttpPost]
        public IActionResult AddVehicle([FromBody] CreateVehicleDTO request)
        {
            AbstractLicensePlate licensePlate;

            switch (request.LicensePlate.Type)
            {
                case "FR":
                    licensePlate = new FrLicensePlate(request.LicensePlate.Value);
                    break;
                case "DE":
                    licensePlate = new DeLicensePlate(request.LicensePlate.Value);
                    break;
                default:
                    throw new ArgumentException("Invalid license plate type");
            }

            Engine engine;
            
            switch (request.Engine.EngineType)
            {
                case "ElectricalEngine":
                    var batteryCapacity = request.Engine.BatteryCapacity ?? throw new ArgumentException("Battery capacity is required");
                    var currentBatteryCapacity = request.Engine.CurrentBatteryCapacity ?? throw new ArgumentException("Current battery capacity is required");
                    engine = new ElectricalEngine(batteryCapacity, currentBatteryCapacity);
                    break;
                case "ThermalEngine":
                    engine = new ThermalEngine();
                    break;
                default:
                    throw new ArgumentException("Invalid engine type");
            }

            var vehicle = _vehicleService.CreateVehicle(request.Type, request.Maker, licensePlate, engine);
            return Ok(new VehiclePresenter(vehicle.Result));
        }

    }
}