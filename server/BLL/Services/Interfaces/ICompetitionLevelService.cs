using BLL.Models.CompetitionLevel;

namespace BLL.Services.Interfaces;

public interface ICompetitionLevelService
{
    Task<IEnumerable<CompetitionLevelModel>> GetAllAsync();
}