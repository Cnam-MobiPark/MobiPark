using Microsoft.AspNetCore.Mvc;
using MobiPark.App.Presenters;
using MobiPark.Domain.Interfaces;
using MobiPark.Domain.UseCases;

namespace MobiPark.App.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ParkingController : ControllerBase
{
    private readonly IParkingRepository _parkingRepository;
    private readonly IVehicleRepository _vehicleRepository;

    public ParkingController(IParkingRepository parkingRepository, IVehicleRepository vehicleRepository)
    {
        _parkingRepository = parkingRepository;
        _vehicleRepository = vehicleRepository;
    }

    [HttpGet("spaces")]
    public IActionResult GetSpaces()
    {
        var spaces = _parkingRepository.GetSpaces();
        var spacePresenters = spaces.Select(space => new ParkingSpacePresenter(space)).ToList();
        return Ok(spacePresenters);
    }

    [HttpPut("spaces/park")]
    public void ParkCar(string licensePlate)
    {
        var ParkVehicleUseCase = new ParkVehicleUseCase(_vehicleRepository, _parkingRepository);
        ParkVehicleUseCase.Execute(licensePlate);
    }
}