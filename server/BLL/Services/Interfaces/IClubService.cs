using BLL.Models.Club;

namespace BLL.Services.Interfaces;

public interface IClubService
{
    Task<IEnumerable<ClubModel>> GetAllAsync();
    Task<ClubModel> GetByIdAsync(int id);
    Task<ClubModel> CreateAsync(CreateClubModel createClubModel);
    Task UpdateAsync(int id, UpdateClubModel updateClubModel);
    Task DeleteAsync(int id);
}