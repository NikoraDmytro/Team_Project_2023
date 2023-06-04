using BLL.Models.CompetitionStatus;

namespace BLL.Services.Interfaces;

public interface ICompetitionStatusService
{
    Task<IEnumerable<CompetitionStatusModel>> GetAllAsync();
}