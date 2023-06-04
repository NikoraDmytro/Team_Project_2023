using Core.Entities;

namespace DAL.Repositories.Interfaces
{
    public interface IBeltRepository: IGenericRepository<Belt>
    {
        Task<Belt?> GetByIdAsync(int id);
        Task<Belt?> GetByNameAsync(string name);
    }
}