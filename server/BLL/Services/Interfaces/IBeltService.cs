using BLL.Models.Belt;
using BLL.Models.Club;
using Core.Shared;
using Sieve.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
