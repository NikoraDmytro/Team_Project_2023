using BLL.Mappings;

namespace BLL.Models.Judge;

public class JudgeModel: IMap<Core.Entities.Judge>
{
    public int MembershipCardNum { get; set; }
    public string? JudgeCategory { get; set; }
}