using AutoMapper;
using BLL.Mappings;
using BLL.Models.Coach;
using Core.Entities;

namespace BLL.Models.Judge;

public class JudgeModel: IMapFrom<Core.Entities.Judge>
{
    public int MembershipCardNum { get; set; }
    public string? JudgeCategory { get; set; }
    public DateTime BirthDate { get; set; }
    public string Belt { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Patronymic { get; set; }
    public string? Sex { get; set; }

    public void MapFrom(Profile profile)
    {
        profile.CreateMap<Core.Entities.Judge, JudgeModel>()
            .ForMember(dest => dest.JudgeCategory, src => src.MapFrom(opt => opt.JudgeCategory.Name))
            .ForMember(dest => dest.Belt, src => src.MapFrom(opt => opt.Sportsman.Belt.Rank))
            .ForMember(dest => dest.Sex,
                src => src.MapFrom(opt => opt.Sportsman.Sex == Core.Entities.Sex.M ? "Ч" : "Ж"))
            .ForMember(dest => dest.FirstName, src => src.MapFrom(opt => opt.Sportsman.User.FirstName))
            .ForMember(dest => dest.LastName, src => src.MapFrom(opt => opt.Sportsman.User.LastName))
            .ForMember(dest => dest.Patronymic, src => src.MapFrom(opt => opt.Sportsman.User.Patronymic));
    }
}