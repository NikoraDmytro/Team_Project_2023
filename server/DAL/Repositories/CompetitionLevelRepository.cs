using Core.Entities;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Sieve.Services;

namespace DAL.Repositories;

public class CompetitionLevelRepository: GenericRepository<CompetitionLevel>, ICompetitionLevelRepository
{
    public CompetitionLevelRepository(AppDbContext context, ISieveProcessor sieveProcessor) : base(context, sieveProcessor)
    {
    }

    public async Task<CompetitionLevel?> GetByNameAsync(string name)
    {
        return await _dbSet.FirstOrDefaultAsync(x => x.Name == name);
    }
}