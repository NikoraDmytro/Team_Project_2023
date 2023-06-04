using AutoMapper;
using BLL.Mappings;
using Core.Entities;

namespace BLL.Models.Coach;

public class CoachModel: IMapFrom<Core.Entities.Coach>
{
    public int MembershipCardNum { get; set; }
    public string? InstructorCategory { get; set; }
    public string? Phone { get; set; }
    public string? Sex { get; set; }
    public string? ClubName { get; set; }
    public DateTime BirthDate { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Patronymic { get; set; }
    public string? Belt { get; set; }


    public void MapFrom(Profile profile)
    {
        profile.CreateMap<Core.Entities.Coach, CoachModel>()
            .ForMember(dest => dest.ClubName, src => src.MapFrom(otp => otp.Club!.Name))
            .ForMember(dest => dest.Belt, src => src.MapFrom(opt => opt.Sportsman.Belt.Rank))
            .ForMember(dest => dest.FirstName, src => src.MapFrom(opt => opt.Sportsman.User.FirstName))
            .ForMember(dest => dest.LastName, src => src.MapFrom(opt => opt.Sportsman.User.LastName))
            .ForMember(dest => dest.Patronymic, src => src.MapFrom(opt => opt.Sportsman.User.Patronymic))
            .ForMember(dest => dest.Sex, src => src.MapFrom(opt => opt.Sportsman.Sex == Core.Entities.Sex.M ? "Ч" : "Ж"))
            .ForMember(dest => dest.BirthDate, src => src.MapFrom(opt => opt.Sportsman.BirthDate))
            .ForMember(dest => dest.InstructorCategory, src => src.MapFrom(opt => opt.InstructorCategory.Name));
    }
}