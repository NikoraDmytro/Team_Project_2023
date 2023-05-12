using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BLL.Models.Settings;
using BLL.Models.User;
using BLL.Services.Interfaces;
using Core.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace BLL.Services;

public class JwtHandler : IJwtHandler
{
    private readonly JwtSettings _jwtSettings;

    public JwtHandler(
        IOptions<JwtSettings> jwtSettings)
    {
        _jwtSettings = jwtSettings.Value;
    }

    public SigningCredentials GetSigningCredentials()
    {
        var key = Encoding.UTF8.GetBytes(_jwtSettings.Key);
        var secret = new SymmetricSecurityKey(key);

        return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
    }

    public async Task<List<Claim>> GetClaimsAsync(User user)
    {
        var claims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.Sub, user.Id.ToString())
        };

        // Add roles of the user to the claims 

        return claims;
    }

    public Task<List<Claim>> GetClaimsAsync(string name)
    {
        return Task.FromResult(new List<Claim>
        {
            new(JwtRegisteredClaimNames.Name, name),
           // Add a "Guest" role if necessarry
        });
    }

    public JwtSecurityToken GenerateToken(SigningCredentials signingCredentials,
        IEnumerable<Claim> claims)
    {
        var token = new JwtSecurityToken(
            issuer: _jwtSettings.Issuer,
            audience: _jwtSettings.Audience,
            claims: claims,
            expires: DateTime.Now.AddDays(1),
            signingCredentials: signingCredentials);

        return token;
    }
}