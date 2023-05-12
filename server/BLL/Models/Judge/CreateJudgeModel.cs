using BLL.Mappings;

namespace BLL.Models.Judge;

public class CreateJudgeModel: IMap<Core.Entities.Judge>
{
    public string? JudgeCategory { get; set; }
}