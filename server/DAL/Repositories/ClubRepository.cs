using Core.Entities;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Sieve.Services;

namespace DAL.Repositories;

public class ClubRepository: GenericRepository<Club>, IClubRepository
{
    public ClubRepository(
        AppDbContext context, 
        ISieveProcessor sieveProcessor) : base(context, sieveProcessor)
    {
    }

    public async Task<Club?> GetByIdAsync(int id)
    {
        return await _dbSet.FirstOrDefaultAsync(e => e.Id == id);
    }
}