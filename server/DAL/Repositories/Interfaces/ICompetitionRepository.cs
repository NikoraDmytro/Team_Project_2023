using Core.Entities;

namespace DAL.Repositories.Interfaces;

public interface ICompetitionRepository: IGenericRepository<Competition>
{
    Task<Competition?> GetByIdAsync(int id);
}