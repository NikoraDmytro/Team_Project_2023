using Core.Entities;

namespace DAL.Repositories.Interfaces;

public interface ICoachRepository: IGenericRepository<Coach>
{
    Task<Coach?> GetByMembershipCardNumAsync(int cardNum);
}