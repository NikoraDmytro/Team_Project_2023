using BLL.Models.Competition;
using Core.Shared;
using Sieve.Models;

namespace BLL.Services.Interfaces;

public interface ICompetitionService
{
    Task<IEnumerable<CompetitionModel>> GetAllAsync();
    Task<PagedList<CompetitionModel>> GetAllWithFilterAsync(SieveModel sieveModel);
    Task<CompetitionModel> CreateAsync(CreateCompetitionModel createCompetitionModel);
    Task UpdateAsync(int id, UpdateCompetitionModel updateCompetitionModel);
    Task DeleteAsync(int id);
}