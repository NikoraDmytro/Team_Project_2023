using Core.Entities;

namespace DAL.Repositories.Interfaces;

public interface ICompetitionLevelRepository: IGenericRepository<CompetitionLevel>
{
    Task<CompetitionLevel?> GetByNameAsync(string name);
}