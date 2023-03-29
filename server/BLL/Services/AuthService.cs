using BLL.Interfaces;
using BLL.Models.Auth;
using BLL.Models.User;

namespace BLL.Services;

public class AuthService: IAuthService
{
    private readonly IJwtHandler _jwtHandler;

    public AuthService(IJwtHandler jwtHandler)
    {
        _jwtHandler = jwtHandler;
    }

    public Task<JwtTokenModel> LoginAsync(LoginModel model, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<UserModel> SignupAsync(SignupModel model, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}