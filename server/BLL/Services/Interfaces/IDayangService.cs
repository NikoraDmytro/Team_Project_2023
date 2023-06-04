using BLL.Models.Dayang;
using Core.Shared;
using Sieve.Models;

namespace BLL.Services.Interfaces
{
    public interface IDayangService
    {
        Task<IEnumerable<DayangModel>> GetAllAsync();
        Task<PagedList<DayangModel>> GetAllWithFilterAsync(SieveModel sieveModel);
        Task<DayangModel> GetByDayangIdAsync(int id);
        Task<DayangModel> CreateAsync(CreateDayangModel createDayangModel);
        Task UpdateAsync(int id, UpdateDayangModel updateDayangModel);
        Task DeleteAsync(int id);
    }
}
