using Core.Entities;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Sieve.Services;

namespace DAL.Repositories;

public class SportsmanRepository : GenericRepository<Sportsman>, ISportsmanRepository
{
    public SportsmanRepository(
        AppDbContext context,
        ISieveProcessor sieveProcessor) : base(context, sieveProcessor)
    { 
    }
    public async Task<Sportsman?> GetByMembershipCardNumAsync(int cardNum)
    {
        return await _dbSet.FirstOrDefaultAsync(c => c.MembershipCardNum == cardNum);
    }

    public async Task<Sportsman?> GetByNameAsync(string firstName, string lastName)
    {
        return await _dbSet.FirstOrDefaultAsync(x => x.User.FirstName == firstName && x.User.LastName == lastName);
    }
}