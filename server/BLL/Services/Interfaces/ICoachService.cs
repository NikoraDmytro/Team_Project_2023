using BLL.Models.Club;
using BLL.Models.Coach;
using Core.Shared;
using Sieve.Models;

namespace BLL.Services.Interfaces;

public interface ICoachService
{
    Task<IEnumerable<CoachModel>> GetAllAsync();
    Task<PagedList<ClubModel>> GetAllWithFilterAsync(SieveModel sieveModel);
    Task<CoachModel> GetByMembershipCardNumAsync(int cardNum);
    Task<CoachModel> CreateAsync(CreateCoachModel createCoachModel);
    Task UpdateAsync(int cardNum, UpdateCoachModel updateCoachModel);
    Task DeleteAsync(int cardNum);
}