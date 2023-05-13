using BLL.Models.Club;
using Core.Shared;
using Sieve.Models;

namespace BLL.Services.Interfaces;

public interface IClubService
{
    Task<IEnumerable<ClubModel>> GetAllAsync();
    Task<PagedList<ClubModel>> GetAllWithFilterAsync(SieveModel sieveModel);
    Task<ClubModel> GetByIdAsync(int id);
    Task<ClubModel> CreateAsync(CreateClubModel createClubModel);
    Task UpdateAsync(int id, UpdateClubModel updateClubModel);
    Task DeleteAsync(int id);
}