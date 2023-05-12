using BLL.Models.Coach;

namespace BLL.Services.Interfaces;

public interface ICoachService
{
    Task<IEnumerable<CoachModel>> GetAllAsync();
    Task<CoachModel> GetByMembershipCardNumAsync(int cardNum);
    Task<CoachModel> CreateAsync(CreateCoachModel createClubModel);
    Task UpdateAsync(int cardNum, UpdateCoachModel updateClubModel);
    Task DeleteAsync(int cardNum);
}