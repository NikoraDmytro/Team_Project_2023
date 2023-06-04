using BLL.Models.Belt;
using Core.Shared;
using Sieve.Models;

namespace BLL.Services.Interfaces
{
    public interface IBeltService
    {
        Task<IEnumerable<BeltModel>> GetAllAsync();
        Task<PagedList<BeltModel>> GetAllWithFilterAsync(SieveModel sieveModel);
        Task<BeltModel> GetByIdAsync(int id);
        Task<BeltModel> CreateAsync(CreateBeltModel createBeltModel);
        Task UpdateAsync(int id, UpdateBeltModel updateBeltModel);
        Task DeleteAsync(int id);
    }
}
