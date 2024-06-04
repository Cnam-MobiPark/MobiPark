using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MobiPark.App.DTO;
using MobiPark.App.Helpers;
using MobiPark.App.Models;
using MobiPark.App.Presenters;
using MobiPark.Domain.Interfaces;
using MobiPark.Domain.UseCases;
using MobiPark.Infra;
using MobiPark.Infra.Repositories;

namespace MobiPark.App.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly AppSettings _appSettings;
    private readonly IClock _clock;
    private readonly IHash _hash;
    private readonly IUserRepository _userRepository;

    public AuthController(
        IOptions<AppSettings> appSettings,
        IHash hash,
        IUserRepository userRepository,
        IClock clock
    )
    {
        _hash = hash;
        _userRepository = userRepository;
        _clock = clock;
        _appSettings = appSettings.Value;
    }

    [HttpPost("")]
    public IActionResult Authenticate([FromBody] LoginUserDTO loginUserDto)
    {
        // Authenticate user
        var loginUseCase = new LoginUserUseCase(_hash, _userRepository);
        var user = loginUseCase.Execute(loginUserDto.Username, loginUserDto.Password);

        var session = new JWTSession(_appSettings, _clock, user);
        session.SaveHeader(Response);
        return Ok(new UserPresenter(user));
    }
}