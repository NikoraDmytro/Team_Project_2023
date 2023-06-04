using Core.Entities;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Sieve.Services;

namespace DAL.Repositories;

public class JudgeCategoryRepository: GenericRepository<JudgeCategory>, IJudgeCategoryRepository
{
    public JudgeCategoryRepository(AppDbContext context, ISieveProcessor sieveProcessor) : base(context, sieveProcessor)
    {
    }

    public async Task<JudgeCategory?> GetByNameAsync(string name)
    {
        return await _dbSet.FirstOrDefaultAsync(x => x.Name == name);
    }
}