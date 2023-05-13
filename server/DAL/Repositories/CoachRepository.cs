using Core.Entities;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class CoachRepository: GenericRepository<Coach>, ICoachRepository
{
    protected CoachRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<Coach?> GetByMembershipCardNumAsync(int cardNum)
    {
        return await _dbSet.FirstOrDefaultAsync(c => c.MembershipCardNum == cardNum);
    }
}