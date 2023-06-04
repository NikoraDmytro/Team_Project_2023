using Core.Entities;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Sieve.Services;

namespace DAL.Repositories;

public class CompetitorRepository : GenericRepository<Competitor>, ICompetitorRepository
{
    public CompetitorRepository(
        AppDbContext context,
        ISieveProcessor sieveProcessor) : base(context, sieveProcessor)
    {
    }

    public async Task<Competitor?> GetByApplicationNumAsync(int applicationNum)
    {
        return await _dbSet.FirstOrDefaultAsync(e => e.ApplicationNum == applicationNum);
    }
}
