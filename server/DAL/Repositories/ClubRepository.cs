using Core.Entities;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class ClubRepository: GenericRepository<Club>, IClubRepository
{
    public ClubRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<Club?> GetByIdAsync(int id)
    {
        return await _dbSet.FirstOrDefaultAsync(e => e.Id == id);
    }
}