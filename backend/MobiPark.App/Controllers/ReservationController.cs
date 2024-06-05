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
    public IActionResult GetReservations()
    {
        var reservations = _reservationRepository.GetReservations();
        var reservationPresenters = reservations.ConvertAll(r => new ReservationPresenter(r));
        return Ok(reservationPresenters);
    }
    
    [HttpGet("{plate}")]
    public IActionResult GetReservation(string plate)
    {
        var reservation = _reservationRepository.FindByPlate(plate);
        return Ok(new ReservationPresenter(reservation));
    }
}