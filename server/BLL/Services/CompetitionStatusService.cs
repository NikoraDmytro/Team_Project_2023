using AutoMapper;
using BLL.Models.CompetitionStatus;
using BLL.Services.Interfaces;
using DAL.Repositories.Interfaces;

namespace BLL.Services;

public class CompetitionStatusService: ICompetitionStatusService
{
    private readonly ICompetitionStatusRepository _competitionStatusRepository;
    private readonly IMapper _mapper;

    public CompetitionStatusService(
        ICompetitionStatusRepository competitionStatusRepository, 
        IMapper mapper)
    {
        _competitionStatusRepository = competitionStatusRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<CompetitionStatusModel>> GetAllAsync()
    {
        var statuses = await _competitionStatusRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<CompetitionStatusModel>>(statuses);
    }
}