using BLL.Mappings;

namespace BLL.Models.JudgeCategory;

public class JudgeCategoryModel: IMapFrom<Core.Entities.JudgeCategory>
{
    public int Id { get; set; }
    public string? Name { get; set; }
}