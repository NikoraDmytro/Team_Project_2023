using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using BLL.Models;
using BLL.Models.User;
using Core.Entities;
using Microsoft.IdentityModel.Tokens;

namespace BLL.Interfaces
{
    public interface IJwtHandler
    {
        SigningCredentials GetSigningCredentials();
        Task<List<Claim>> GetClaimsAsync(User user);
        JwtSecurityToken GenerateToken(SigningCredentials signingCredentials, IEnumerable<Claim> claims);
    }
}