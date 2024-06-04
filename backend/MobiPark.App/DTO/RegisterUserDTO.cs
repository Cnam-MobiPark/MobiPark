using System.ComponentModel.DataAnnotations;

namespace MobiPark.App.DTO;

public class RegisterUserDTO
{
    [Required] public string Username { get; set; }

    [Required] public string Password { get; set; }
}