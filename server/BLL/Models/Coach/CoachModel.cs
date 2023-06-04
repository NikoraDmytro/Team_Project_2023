using AutoMapper;
using BLL.Mappings;
using Core.Entities;

namespace BLL.Models.Coach;

public class CoachModel: IMapFrom<Core.Entities.Coach>
{
    public int MembershipCardNum { get; set; }
    public string? InstructorCategory { get; set; }
    public string? Phone { get; set; }
    public int ClubId { get; set; }
    public string? ClubName { get; set; }
    public Core.Entities.Sportsman? Sportsman { get; set; }
    public DateTime BirthDate { get; set; }
    public Core.Entities.Belt? Belt { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Patronymic { get; set; }


    public void MapTo(Profile profile)
    {
        profile.CreateMap<Core.Entities.Coach, CoachModel>()
            .ForMember(dest => dest.ClubName, src => src.MapFrom(otp => otp.Club!.Name));
        /*profile.CreateMap<Core.Entities.Coach, CoachModel>()
            .ForMember(dest => dest.Sportsman!.BirthDate, src => src.MapFrom(otp => otp.Sportsman!.BirthDate));
        profile.CreateMap<Core.Entities.Coach, CoachModel>()
            .ForMember(dest => dest.Sportsman!.Belt, src => src.MapFrom(otp => otp.Sportsman!.Belt));
        profile.CreateMap<Core.Entities.Coach, CoachModel>()
            .ForMember(dest => dest.Sportsman!.User!.FirstName, src => src.MapFrom(otp => otp.Sportsman!.User!.FirstName));
        profile.CreateMap<Core.Entities.Coach, CoachModel>()
            .ForMember(dest => dest.Sportsman!.User!.LastName, src => src.MapFrom(otp => otp.Sportsman!.User!.LastName));
        profile.CreateMap<Core.Entities.Coach, CoachModel>()
            .ForMember(dest => dest.Sportsman!.User!.Patronymic, src => src.MapFrom(otp => otp.Sportsman!.User!.Patronymic));
    */
    }
}