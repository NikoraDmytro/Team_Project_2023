using Core.Entities;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Sieve.Services;

namespace DAL.Repositories;

public class CoachRepository: GenericRepository<Coach>, ICoachRepository
{
    public CoachRepository(
        AppDbContext context,
        ISieveProcessor sieveProcessor) : base(context, sieveProcessor)
    {
    }

    public async Task<Coach?> GetByMembershipCardNumAsync(int cardNum)
    {
        return await _dbSet.FirstOrDefaultAsync(c => c.MembershipCardNum == cardNum);
    }

    public async Task<Coach?> GetByNameAsync(string firstName, string lastName)
    {
        return await _dbSet.FirstOrDefaultAsync(x =>
            x.Sportsman.User.FirstName == firstName && x.Sportsman.User.LastName == lastName);
    }
}