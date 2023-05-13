using AutoMapper;
using BLL.Mappings;

namespace BLL.Models.Auth;

public class SignupModel: IMapTo<Core.Entities.User>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? Patronymic { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

    public void MapTo(Profile profile)
    {
        profile.CreateMap<SignupModel, Core.Entities.User>()
            .ForMember(dest => dest.UserName, src => src.MapFrom(opt => opt.Email));
    }
}