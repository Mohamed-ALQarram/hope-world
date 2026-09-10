using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Academy.Application.Abstractions.Authentication;
using Academy.Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Academy.Infrastructure.Authentication;

public class JwtTokenGenerator : IJwtTokenGenerator
{
    private readonly IConfiguration _configuration;

    public JwtTokenGenerator(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string GenerateToken(Student student, string className)
    {
        var secretKey = _configuration["JwtSettings:SecretKey"] ?? "SuperSecretKeyForHopeWorldAcademyApp2026!";
        var issuer = _configuration["JwtSettings:Issuer"] ?? "HopeWorldAcademy";
        var audience = _configuration["JwtSettings:Audience"] ?? "HopeWorldAcademyUsers";
        var expiryMinutesString = _configuration["JwtSettings:ExpiryMinutes"];
        var expiryMinutes = double.TryParse(expiryMinutesString, out var parsedMinutes) ? parsedMinutes : 10080;

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, student.StudentId.ToString()),
            new Claim(ClaimTypes.NameIdentifier, student.StudentId.ToString()),
            new Claim(ClaimTypes.Name, student.StudentName),
            new Claim("ClassId", student.ClassId.ToString()),
            new Claim("ClassName", className),
            new Claim(ClaimTypes.Role, "Student")
        };

        var token = new JwtSecurityToken(
            issuer: issuer,
            audience: audience,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(expiryMinutes),
            signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
