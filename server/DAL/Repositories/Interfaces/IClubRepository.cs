using Core.Entities;

namespace DAL.Repositories.Interfaces;

public interface IClubRepository: IGenericRepository<Club>
{
    Task<Club?> GetByIdAsync(int id);
}