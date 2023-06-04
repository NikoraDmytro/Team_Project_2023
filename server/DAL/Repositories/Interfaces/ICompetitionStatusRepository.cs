using Core.Entities;

namespace DAL.Repositories.Interfaces;

public interface ICompetitionStatusRepository: IGenericRepository<CompetitionStatus>
{
    Task<CompetitionStatus?> GetByNameAsync(string name);
}