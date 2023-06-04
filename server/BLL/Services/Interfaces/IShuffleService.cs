using BLL.Models.Club;
using BLL.Models.Shuffle;
using Core.Shared;
using Sieve.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Interfaces
{
    public interface IShuffleService
    {
        Task<IEnumerable<ShuffleModel>> GetAllAsync();
        Task<PagedList<ShuffleModel>> GetAllWithFilterAsync(SieveModel sieveModel);
        Task<ShuffleModel> GetByShuffleIdAsync(int id);
        Task<ShuffleModel> CreateAsync(CreateShuffleModel createShuffleModel);
        Task UpdateAsync(int id, UpdateShuffleModel updateShuffleModel);
        Task DeleteAsync(int id);
    }
}
