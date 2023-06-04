using AutoMapper;
using BLL.Mappings;

namespace BLL.Models.Competition;

public class CompetitionModel: IMapFrom<Core.Entities.Competition>
{
    public int CompetitionId { get; set; }
    public string? Name { get; set; }
    public DateTime? WeightingDate { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public string? City { get; set; }
    public string? Status { get; set; }
    public string? Level { get; set; }

    public void MapFrom(Profile profile)
    {
        profile.CreateMap<Core.Entities.Competition, CompetitionModel>()
            .ForMember(dest => dest.Status, src => src.MapFrom(opt => opt.CompetitionStatus.Name))
            .ForMember(dest => dest.Level, src => src.MapFrom(opt => opt.CompetitionLevel));
    }
}