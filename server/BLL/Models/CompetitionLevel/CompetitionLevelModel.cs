using BLL.Mappings;

namespace BLL.Models.CompetitionLevel;

public class CompetitionLevelModel: IMapFrom<Core.Entities.CompetitionLevel>
{
    public int Id { get; set; }
    public string? Name { get; set; }
}