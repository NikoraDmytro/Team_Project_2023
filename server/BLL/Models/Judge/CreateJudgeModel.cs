using BLL.Mappings;

namespace BLL.Models.Judge;

public class CreateJudgeModel: IMapFrom<Core.Entities.Judge>
{
    public string? JudgeCategory { get; set; }
}