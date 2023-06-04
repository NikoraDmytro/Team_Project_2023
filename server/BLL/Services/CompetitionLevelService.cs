using AutoMapper;
using BLL.Models.CompetitionLevel;
using BLL.Services.Interfaces;
using DAL.Repositories.Interfaces;

namespace BLL.Services;

public class CompetitionLevelService: ICompetitionLevelService
{
    private readonly ICompetitionLevelRepository _competitionLevelRepository;
    private readonly IMapper _mapper;

    public CompetitionLevelService(
        ICompetitionLevelRepository competitionLevelRepository, 
        IMapper mapper)
    {
        _competitionLevelRepository = competitionLevelRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<CompetitionLevelModel>> GetAllAsync()
    {
        var levels = await _competitionLevelRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<CompetitionLevelModel>>(levels);
    }
}