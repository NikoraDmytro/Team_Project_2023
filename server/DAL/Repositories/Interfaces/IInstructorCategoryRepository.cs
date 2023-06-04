using Core.Entities;

namespace DAL.Repositories.Interfaces;

public interface IInstructorCategoryRepository: IGenericRepository<InstructorCategory>
{
    Task<InstructorCategory?> GetByNameAsync(string name);
}