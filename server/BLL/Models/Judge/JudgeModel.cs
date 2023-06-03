using AutoMapper;
using BLL.Mappings;
using BLL.Models.Coach;
using Core.Entities;

namespace BLL.Models.Judge;

public class JudgeModel: IMapFrom<Core.Entities.Judge>
{
    public int MembershipCardNum { get; set; }
    public string? JudgeCategory { get; set; }
    public Sportsman? Sportsman { get; set; }
    public DateTime BirthDate { get; set; }
    public Belt? Belt { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Patronymic { get; set; }

    public void MapTo(Profile profile)
    {
        profile.CreateMap<Core.Entities.Judge, JudgeModel>()
            .ForMember(dest => dest.JudgeCategory, src => src.MapFrom(otp => otp.JudgeCategory));
        profile.CreateMap<Core.Entities.Judge, JudgeModel>()
            .ForMember(dest => dest.Sportsman!.BirthDate, src => src.MapFrom(otp => otp.Sportsman!.BirthDate));
        profile.CreateMap<Core.Entities.Judge, JudgeModel>()
            .ForMember(dest => dest.Sportsman!.Belt, src => src.MapFrom(otp => otp.Sportsman!.Belt));
        profile.CreateMap<Core.Entities.Judge, JudgeModel>()
            .ForMember(dest => dest.Sportsman!.User!.FirstName, src => src.MapFrom(otp => otp.Sportsman!.User!.FirstName));
        profile.CreateMap<Core.Entities.Judge, JudgeModel>()
            .ForMember(dest => dest.Sportsman!.User!.LastName, src => src.MapFrom(otp => otp.Sportsman!.User!.LastName));
        profile.CreateMap<Core.Entities.Judge, JudgeModel>()
            .ForMember(dest => dest.Sportsman!.User!.Patronymic, src => src.MapFrom(otp => otp.Sportsman!.User!.Patronymic));
    }
}