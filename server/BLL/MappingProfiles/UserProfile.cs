using AutoMapper;
using BLL.Models.Auth;
using BLL.Models.User;
using Core.Entities;

namespace BLL.MappingProfiles;

public class UserProfile: Profile
{
    public UserProfile()
    {
        CreateMap<User, UserModel>();
        CreateMap<SignupModel, User>()
            .ForMember(dest => dest.UserName, src => src.MapFrom(opt => opt.Email));
    }
}