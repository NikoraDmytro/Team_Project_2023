using Core.Entities;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Sieve.Services;

namespace DAL.Repositories;

public class CompetitionRepository: GenericRepository<Competition>, ICompetitionRepository
{
    public CompetitionRepository(AppDbContext context, ISieveProcessor sieveProcessor) : base(context, sieveProcessor)
    {
    }

    public async Task<Competition?> GetByIdAsync(int id)
    {
        return await _dbSet.FirstOrDefaultAsync(x => x.CompetitionId == id);
    }
}