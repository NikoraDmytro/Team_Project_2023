using BLL.Models.Judge;

namespace BLL.Services.Interfaces;

public interface IJudgeService
{
    Task<IEnumerable<JudgeModel>> GetAllAsync();
    Task<JudgeModel> GetByMembershipCardNumAsync(int cardNum);
    Task<JudgeModel> CreateAsync(CreateJudgeModel createJudgeModel);
    Task UpdateAsync(int cardNum, UpdateJudgeModel updateJudgeModel);
    Task DeleteAsync(int cardNum);
}