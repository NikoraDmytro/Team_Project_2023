using BLL.Mappings;

namespace BLL.Models.Coach;

public class CreateCoachModel: IMapTo<Core.Entities.Coach>
{
    public string? Phone { get; set; }
    public int ClubId { get; set; }
}