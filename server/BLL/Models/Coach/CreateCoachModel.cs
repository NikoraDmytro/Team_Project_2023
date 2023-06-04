using AutoMapper;
using BLL.Mappings;

namespace BLL.Models.Coach;

public class CreateCoachModel: IMapTo<Core.Entities.Coach>
{
    public string? Phone { get; set; }
    public string? Sportsman { get; set; }
    public string? InstructorCategory { get; set; }
    public string? Club { get; set; }

    public void MapTo(Profile profile)
    {
        profile.CreateMap<CreateCoachModel, Core.Entities.Coach>()
            .ForMember(dest => dest.InstructorCategory, opt => opt.Ignore());
    }
}