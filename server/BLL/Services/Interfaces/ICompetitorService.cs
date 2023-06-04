using BLL.Models.Club;
using BLL.Models.Competitor;
using Core.Shared;
using Sieve.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Interfaces
{
    public interface ICompetitorService
    {
        Task<IEnumerable<CompetitorModel>> GetAllAsync();
        Task<PagedList<CompetitorModel>> GetAllWithFilterAsync(SieveModel sieveModel);
        Task<CompetitorModel> GetByApplicationNumAsync(int applicationNum);
        Task<CompetitorModel> CreateAsync(CreateCompetitorModel createCompetitorModel);
        Task UpdateAsync(int applicationNum, UpdateCompetitorModel updateCompetitorModel);
        Task DeleteAsync(int applicationNum);
    }
}
