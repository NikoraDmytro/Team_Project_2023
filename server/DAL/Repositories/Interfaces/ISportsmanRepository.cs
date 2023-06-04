using Core.Entities;

namespace DAL.Repositories.Interfaces
{
    public interface ISportsmanRepository: IGenericRepository<Sportsman>
    {
        Task<Sportsman?> GetByMembershipCardNumAsync(int id);
    }
}
