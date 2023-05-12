using BLL.Models.Coach;

namespace BLL.Services.Interfaces;

public interface ICoachService
{
    Task<IEnumerable<CoachModel>> GetAllAsync();
    Task<CoachModel> GetByMembershipCardNumAsync(int cardNum);
    Task<CoachModel> CreateAsync(CreateCoachModel createCoachModel);
    Task UpdateAsync(int cardNum, UpdateCoachModel updateCoachModel);
    Task DeleteAsync(int cardNum);
}