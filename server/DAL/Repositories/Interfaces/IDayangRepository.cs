using Core.Entities;

namespace DAL.Repositories.Interfaces;

public interface IDayangRepository: IGenericRepository<Dayang>
{
    Task<Dayang?> GetByDayangIdAsync(int id);
}
