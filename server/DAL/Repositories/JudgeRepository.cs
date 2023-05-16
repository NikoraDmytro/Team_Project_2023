using Core.Entities;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Sieve.Services;

namespace DAL.Repositories;

public class JudgeRepository: GenericRepository<Judge>, IJudgeRepository
{
    public JudgeRepository(
        AppDbContext context,
        ISieveProcessor sieveProcessor) : base(context, sieveProcessor)
    {
    }

    public async Task<Judge?> GetByMembershipCardNumAsync(int cardNum)
    {
        return await _dbSet.FirstOrDefaultAsync(j => j.MembershipCardNum == cardNum);
    }
}