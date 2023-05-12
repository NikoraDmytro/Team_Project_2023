using BLL.Mappings;

namespace BLL.Models.Coach;

public class CoachModel: IMapFrom<Core.Entities.Coach>
{
    public int MembershipCardNum { get; set; }
    public string? InstructorCategory { get; set; }
    public string? Phone { get; set; }
    public int ClubId { get; set; }
}