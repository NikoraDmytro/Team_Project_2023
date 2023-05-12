using BLL.Models.Coach;
using BLL.Services.Interfaces;

namespace BLL.Services;

public class CoachService: ICoachService
{
    public Task<IEnumerable<CoachModel>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<CoachModel> GetByMembershipCardNumAsync(int cardNum)
    {
        throw new NotImplementedException();
    }

    public Task<CoachModel> CreateAsync(CreateCoachModel createClubModel)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(int cardNum, UpdateCoachModel updateClubModel)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int cardNum)
    {
        throw new NotImplementedException();
    }
}