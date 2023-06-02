using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using BLL.Models.Auth;
using Core.Entities;
using Google.Apis.Auth;
using Microsoft.IdentityModel.Tokens;

namespace BLL.Services.Interfaces
{
    public interface IJwtService
    {
        SigningCredentials GetSigningCredentials();
        Task<List<Claim>> GetClaimsAsync(User user);
        JwtSecurityToken GenerateToken(SigningCredentials signingCredentials, IEnumerable<Claim> claims);
        Task<GoogleJsonWebSignature.Payload?> VerifyGoogleToken(ExternalAuthModel externalAuth);
    }
}