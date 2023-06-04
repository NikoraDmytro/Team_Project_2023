using BLL.Mappings;

namespace BLL.Models.CompetitionStatus;

public class CompetitionStatusModel: IMapFrom<Core.Entities.CompetitionStatus>
{
    public int Id { get; set; }
    public string? Name { get; set; }
}