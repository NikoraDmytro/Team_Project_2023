using Core.Entities;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Sieve.Services;

namespace DAL.Repositories;

public class BeltRepository: GenericRepository<Belt>, IBeltRepository
{
    public BeltRepository(
        AppDbContext context,
        ISieveProcessor sieveProcessor): base(context, sieveProcessor)
    {
    }

    public async Task<Belt?> GetByNameAsync(string name)
    {
        return await _dbSet.FirstOrDefaultAsync(x => x.Rank == name);
    }
    
    public async Task<Belt?> GetByIdAsync(int id)
    {
        return await _dbSet.FirstOrDefaultAsync(e => e.Id == id);
    }
}

