using BLL.Mappings;

namespace BLL.Models.Judge;

public class CreateJudgeModel: IMapTo<Core.Entities.Judge>
{
    public string Sportsman { get; set; }
    public string? JudgeCategory { get; set; }
}