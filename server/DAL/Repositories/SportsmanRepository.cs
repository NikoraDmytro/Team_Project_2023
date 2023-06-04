using Core.Entities;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Sieve.Services;

namespace DAL.Repositories;

public class SportsmanRepository: GenericRepository<Sportsman>, ISportsmanRepository
{
    public SportsmanRepository(
        AppDbContext context,
        ISieveProcessor sieveProcessor): base(context, sieveProcessor)
    {
    }

    public async Task<Sportsman?> GetByIdAsync(int id)
    {
        return await _dbSet.FirstOrDefaultAsync(x => x.MembershipCardNum == id);
    }
}