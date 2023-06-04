using BLL.Mappings;

namespace BLL.Models.InstructorCategory;

public class InstructorCategoryModel: IMapFrom<Core.Entities.InstructorCategory>
{
    public int Id { get; set; }
    public string? Name { get; set; }
}