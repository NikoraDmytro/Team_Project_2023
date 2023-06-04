using Core.Entities;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Sieve.Services;

namespace DAL.Repositories;

public class InstructorCategoryRepository: GenericRepository<InstructorCategory>, IInstructorCategoryRepository
{
    public InstructorCategoryRepository(AppDbContext context, ISieveProcessor sieveProcessor) : base(context, sieveProcessor)
    {
    }

    public async Task<InstructorCategory?> GetByNameAsync(string name)
    {
        return await _dbSet.FirstOrDefaultAsync(x => x.Name == name);
    }
}