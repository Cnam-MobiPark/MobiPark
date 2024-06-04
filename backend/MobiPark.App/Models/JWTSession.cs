using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using MobiPark.App.Helpers;
using MobiPark.Domain.Interfaces;
using MobiPark.Domain.Models;

namespace MobiPark.App.Models;

public class JWTSession
{
    private readonly string _token;

    public JWTSession(AppSettings settings, IClock clock, User user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(settings.Secret);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
            Expires = clock.Now().AddDays(7),
            SigningCredentials =
                new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        _token = tokenHandler.WriteToken(token);
    }

    public void SaveHeader(HttpResponse response)
    {
        response.Headers.Authorization = $"Bearer {_token}";
    }
}