using AutoMapper;
using BLL.Mappings;
using Core.Entities;

namespace BLL.Models.Sportsman;

public class SportsmanModel: IMapFrom<Core.Entities.Sportsman>
{
    public int MembershipCardNum { get; set; }
    public DateTime BirthDate { get; set; }
    public string Sex { get; set; }
    public string ClubName { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Belt { get; set; }

    public void MapFrom(Profile profile)
    {
        profile.CreateMap<Core.Entities.Sportsman, SportsmanModel>()
            .ForMember(dest => dest.Sex, src => src.MapFrom(opt => opt.Sex == Core.Entities.Sex.M ? "Ч" : "Ж"))
            .ForMember(dest => dest.FirstName, src => src.MapFrom(opt => opt.User.FirstName))
            .ForMember(dest => dest.LastName, src => src.MapFrom(opt => opt.User.LastName))
            .ForMember(dest => dest.Belt, src => src.MapFrom(opt => opt.Belt.Rank));
    }
}