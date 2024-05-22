using Microsoft.AspNetCore.Mvc;
using MobiPark.App.Api.Presenters;
using MobiPark.Domain.Interfaces;

namespace MobiPark.App.Api.Controllers;

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
        var vehiclePresenters = vehicles.Select(vehicle => new VehiclePresenter(vehicle)).ToList();
        return Ok(vehiclePresenters);
    }
}