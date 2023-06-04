using BLL.Models.Sportsman;
using Core.Shared;
using Sieve.Models;

namespace BLL.Services.Interfaces
{
    public interface ISportsmanService
    {
        Task<IEnumerable<SportsmanModel>> GetAllAsync();
        Task<PagedList<SportsmanModel>> GetAllWithFilterAsync(SieveModel sieveModel);
        Task<SportsmanModel> GetByMembershipCardNumAsync(int cardNum);
        Task<SportsmanModel> CreateAsync(CreateSportsmanModel createSportsmanModel);
        Task UpdateAsync(int cardNum, UpdateSportsmanModel updateSportsmanModel);
        Task DeleteAsync(int cardNum);
    }
}
