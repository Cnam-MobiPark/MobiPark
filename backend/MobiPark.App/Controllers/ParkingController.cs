using Microsoft.AspNetCore.Mvc;
using MobiPark.App.Presenters;
using MobiPark.Domain.Interfaces;

namespace MobiPark.App.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ParkingController : ControllerBase
{
    private readonly IParkingRepository _parkingRepository;
    private readonly IVehicleRepository _vehicleRepository;

    public ParkingController(IParkingRepository parkingRepository)
    {
        _parkingRepository = parkingRepository;
    }

    [HttpGet("spaces")]
    public IActionResult GetSpaces()
    {
        var spaces = _parkingRepository.GetSpaces();
        var spacePresenters = spaces.Result.Select(space => new ParkingSpacePresenter(space)).ToList();
        return Ok(spacePresenters);
    }

    [HttpPut("spaces/park")]
    public async Task<IActionResult> ParkCar(string licensePlate)
    {
        var vehicle =  await _vehicleRepository.FindByPlate(licensePlate) ?? throw new InvalidOperationException("Vehicle not found.");
        var firstAvailableSpace = _parkingRepository.GetAvailableSpaces(vehicle).Result.FirstOrDefault() ?? throw new InvalidOperationException("No available parking spaces.");
        _parkingRepository.ParkVehicle(vehicle, firstAvailableSpace);
        return Ok(new ParkingSpacePresenter(firstAvailableSpace));
    }
}