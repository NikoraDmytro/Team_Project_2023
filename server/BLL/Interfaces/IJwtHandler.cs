using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using BLL.Models;
using BLL.Models.User;
using Microsoft.IdentityModel.Tokens;

namespace BLL.Interfaces
{
    public interface IJwtHandler
    {
        SigningCredentials GetSigningCredentials();
        Task<List<Claim>> GetClaimsAsync(UserModel user);
        JwtSecurityToken GenerateToken(SigningCredentials signingCredentials, IEnumerable<Claim> claims);
    }
}