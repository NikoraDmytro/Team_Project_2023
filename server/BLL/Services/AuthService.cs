using System.IdentityModel.Tokens.Jwt;
using AutoMapper;
using BLL.Exceptions.Auth;
using BLL.Interfaces;
using BLL.Models.Auth;
using BLL.Models.User;
using Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace BLL.Services;

public class AuthService: IAuthService
{
    private readonly IJwtHandler _jwtHandler;
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    private readonly IMapper _mapper;

    public AuthService(
        IJwtHandler jwtHandler,
        UserManager<User> userManager,
        SignInManager<User> signInManager,
        IMapper mapper)
    {
        _jwtHandler = jwtHandler;
        _userManager = userManager;
        _signInManager = signInManager;
        _mapper = mapper;
    }
    

    public async Task<JwtTokenModel> LoginAsync(LoginModel model, CancellationToken cancellationToken = default)
    {
        var user = await _userManager.FindByEmailAsync(model.Email);

        if (user == null)
        {
            throw new InvalidLoginException();
        }

        var result = await _signInManager
            .CheckPasswordSignInAsync(user, model.Password, false);

        if (!result.Succeeded)
        {
            throw new InvalidLoginException();
        }

        var claims = await _jwtHandler.GetClaimsAsync(user);
        var signingCredentials = _jwtHandler.GetSigningCredentials();
        var token = _jwtHandler.GenerateToken(signingCredentials, claims);

        return new JwtTokenModel()
        {
            Token = new JwtSecurityTokenHandler().WriteToken(token),
        };
    }

    public async Task<UserModel> SignupAsync(SignupModel model, CancellationToken cancellationToken = default)
    {
        var user = _mapper.Map<User>(model);

        var result = await _userManager.CreateAsync(user, model.Password);

        if (!result.Succeeded)
        {
            throw new FailedSignupException(result.ToString());
        }

        // Send email confirmation
        // Add to default role if needed

        return _mapper.Map<UserModel>(user);
    }
}