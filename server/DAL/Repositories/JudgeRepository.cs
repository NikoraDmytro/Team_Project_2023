using Core.Entities;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class JudgeRepository: GenericRepository<Judge>, IJudgeRepository
{
    public JudgeRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<Judge?> GetByMembershipCardNumAsync(int cardNum)
    {
        return await _dbSet.FirstOrDefaultAsync(j => j.MembershipCardNum == cardNum);
    }
}