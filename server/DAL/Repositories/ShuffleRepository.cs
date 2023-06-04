using Core.Entities;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Sieve.Services;

namespace DAL.Repositories;

public class ShuffleRepository:GenericRepository<Shuffle>, IShuffleRepository
{
    public ShuffleRepository(
        AppDbContext context,
        ISieveProcessor sieveProcessor) : base(context, sieveProcessor)
    {
    }

    public async Task<Shuffle?> GetByShuffleIdAsync(int id)
    {
        return await _dbSet.FirstOrDefaultAsync(e => e.ShuffleId == id);
    }
}