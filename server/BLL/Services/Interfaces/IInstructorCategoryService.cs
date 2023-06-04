using BLL.Models.InstructorCategory;

namespace BLL.Services.Interfaces;

public interface IInstructorCategoryService
{
    Task<IEnumerable<InstructorCategoryModel>> GetAllAsync();
}