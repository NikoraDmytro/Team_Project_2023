using Core.Entities;

namespace DAL.Repositories.Interfaces;

public interface IJudgeCategoryRepository: IGenericRepository<JudgeCategory>
{
    Task<JudgeCategory?> GetByNameAsync(string name);
}