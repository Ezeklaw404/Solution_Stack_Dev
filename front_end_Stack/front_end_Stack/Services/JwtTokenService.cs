using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace front_end_Stack.Services;

public class JwtTokenService(IConfiguration configuration)
{
    public string CreateToken(ClaimsPrincipal user)
    {
        var key = configuration["Jwt:Key"]
            ?? throw new InvalidOperationException("Jwt:Key is not configured.");
        var issuer = configuration["Jwt:Issuer"]
            ?? throw new InvalidOperationException("Jwt:Issuer is not configured.");
        var audience = configuration["Jwt:Audience"]
            ?? throw new InvalidOperationException("Jwt:Audience is not configured.");

        var claims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, user.FindFirstValue(ClaimTypes.NameIdentifier) ?? user.FindFirstValue(ClaimTypes.Name) ?? ""),
            new(ClaimTypes.Name, user.Identity?.Name ?? ""),
            new(ClaimTypes.Email, user.FindFirstValue(ClaimTypes.Email) ?? user.Identity?.Name ?? "")
        };

        foreach (var role in user.FindAll(ClaimTypes.Role))
        {
            claims.Add(new Claim(ClaimTypes.Role, role.Value));
        }

        var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
        var credentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: issuer,
            audience: audience,
            claims: claims,
            expires: DateTime.UtcNow.AddHours(1),
            signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
