using BLL.Models.Club;
using BLL.Models.Sportsman;
using Core.Shared;
using Sieve.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
