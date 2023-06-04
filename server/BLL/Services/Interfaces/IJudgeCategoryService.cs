using BLL.Models.JudgeCategory;

namespace BLL.Services.Interfaces;

public interface IJudgeCategoryService
{
    Task<IEnumerable<JudgeCategoryModel>> GetAllAsync();
}