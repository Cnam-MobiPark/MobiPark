using Microsoft.AspNetCore.Mvc;
using MobiPark.App.DTO;
using MobiPark.App.Presenters;
using MobiPark.Domain.Interfaces;
using MobiPark.Domain.Models.Vehicle.Engine;

namespace MobiPark.App.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VehicleController : ControllerBase
{
    private readonly IVehicleRepository _vehicleRepository;

    public VehicleController(IVehicleRepository vehicleRepository)
    {
        _vehicleRepository = vehicleRepository;
    }

    [HttpGet]
    public IActionResult GetVehicles()
    {
        var vehicles = _vehicleRepository.GetVehicles();
        var vehiclePresenters = vehicles.ConvertAll(v => new VehiclePresenter(v));
        return Ok(vehiclePresenters);
    }

    [HttpGet("{licensePlate}")]
    public IActionResult GetVehicle(string licensePlate)
    {
        var vehicle = _vehicleRepository.FindByPlate(licensePlate);
        return Ok(new VehiclePresenter(vehicle));
    }

    [HttpPost]
    public IActionResult AddVehicle([FromBody] CreateVehicleDTO request)
    {
        var licensePlate = request.LicensePlate.ToDomainModel();

        Engine engine;

        switch (request.Engine.EngineType)
        {
            case "ElectricalEngine":
                var batteryCapacity = request.Engine.BatteryCapacity ??
                                      throw new ArgumentException("Battery capacity is required");
                var currentBatteryCapacity = request.Engine.CurrentBatteryCapacity ??
                                             throw new ArgumentException("Current battery capacity is required");
                engine = new ElectricalEngine(batteryCapacity, currentBatteryCapacity);
                break;
            case "ThermalEngine":
                engine = new ThermalEngine();
                break;
            default:
                throw new ArgumentException("Invalid engine type");
        }

        var vehicle = _vehicleRepository.CreateVehicle(request.Type, request.Maker, licensePlate, engine);
        return Ok(new VehiclePresenter(vehicle));
    }
}