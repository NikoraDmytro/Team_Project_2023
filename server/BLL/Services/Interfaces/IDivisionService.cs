using BLL.Models.Belt;
using BLL.Models.Division;
using Core.Shared;
using Sieve.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Interfaces
{
    public interface IDivisionService
    {
        Task<IEnumerable<DivisionModel>> GetAllAsync();
        Task<PagedList<DivisionModel>> GetAllWithFilterAsync(SieveModel sieveModel);
        Task<DivisionModel> GetByDivisionIdAsync(int id);
        Task<DivisionModel> CreateAsync(CreateDivisionModel createDivisionModel);
        Task UpdateAsync(int id, UpdateDivisionModel updateDivisionModel);
        Task DeleteAsync(int id);
    }
}
