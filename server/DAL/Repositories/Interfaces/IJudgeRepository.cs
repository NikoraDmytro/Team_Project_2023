using Core.Entities;

namespace DAL.Repositories.Interfaces;

public interface IJudgeRepository: IGenericRepository<Judge>
{
    Task<Judge?> GetByMembershipCardNumAsync(int cardNum);
}