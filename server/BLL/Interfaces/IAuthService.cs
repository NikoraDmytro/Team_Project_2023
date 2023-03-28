using BLL.Models.Auth;
using BLL.Models.User;

namespace BLL.Interfaces;

public interface IAuthService
{
    Task<JwtTokenModel> LoginAsync(LoginModel model, CancellationToken cancellationToken = default);
    Task<UserModel> SignupAsync(SignupModel model, CancellationToken cancellationToken = default);
}