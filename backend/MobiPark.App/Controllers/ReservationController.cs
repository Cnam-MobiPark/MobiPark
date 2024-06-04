using Microsoft.AspNetCore.Mvc;
using MobiPark.App.Presenters;
using MobiPark.Infra.Repositories;

namespace MobiPark.App.Controllers;


[ApiController]
[Route("api/[controller]")]
public class ReservationController : ControllerBase
{
    private readonly ReservationRepository _reservationRepository;
    
    public ReservationController(ReservationRepository reservationRepository)
    {
        _reservationRepository = reservationRepository;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetReservations()
    {
        var reservations = await _reservationRepository.GetReservations();
        var reservationPresenters = reservations.ConvertAll(r => new ReservationPresenter(r));
        return Ok(reservationPresenters);
    }
    
    [HttpGet("{plate}")]
    public async Task<IActionResult> GetReservation(string plate)
    {
        var reservation = await _reservationRepository.FindByPlate(plate);
        return Ok(new ReservationPresenter(reservation));
    }
}