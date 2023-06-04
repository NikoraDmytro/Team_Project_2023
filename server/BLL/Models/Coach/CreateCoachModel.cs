using AutoMapper;
using BLL.Mappings;

namespace BLL.Models.Coach;

public class CreateCoachModel: IMapTo<Core.Entities.Coach>
{
    public int MembershipCardNum { get; set; }
    public string? InstructorCategory { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Patronymic { get; set; }
    public string? Belt { get; set; }
    public string? ClubName { get; set; }

    public void MapTo(Profile profile)
    {
        profile.CreateMap<CreateCoachModel, Core.Entities.Coach>()
            .ForMember(dest => dest.InstructorCategory, opt => opt.Ignore());
    }
}