using BLL.Models.Judge;

namespace BLL.Services.Interfaces;

public interface IJudgeService
{
    Task<IEnumerable<JudgeModel>> GetAllAsync();
    Task<JudgeModel> GetByMembershipCardNumAsync(int cardNum);
    Task<JudgeModel> CreateAsync(CreateJudgeModel createClubModel);
    Task UpdateAsync(int cardNum, UpdateJudgeModel updateClubModel);
    Task DeleteAsync(int cardNum);
}