using AutoMapper;
using BLL.Models.Competition;
using BLL.Services.Interfaces;
using Core.Entities;
using Core.Exceptions;
using Core.Shared;
using DAL;
using DAL.Repositories.Interfaces;
using Sieve.Models;

namespace BLL.Services;

public class CompetitionService: ICompetitionService
{
    private readonly ICompetitionRepository _competitionRepository;
    private readonly ICompetitionStatusRepository _competitionStatusRepository;
    private readonly ICompetitionLevelRepository _competitionLevelRepository;
    private readonly IMapper _mapper;
    private readonly AppDbContext _context;

    public CompetitionService(
        ICompetitionRepository competitionRepository, 
        ICompetitionStatusRepository competitionStatusRepository,
        ICompetitionLevelRepository competitionLevelRepository,
        IMapper mapper,
        AppDbContext context)
    {
        _competitionRepository = competitionRepository;
        _competitionStatusRepository = competitionStatusRepository;
        _competitionLevelRepository = competitionLevelRepository;
        _mapper = mapper;
        _context = context;
    }

    public async Task<IEnumerable<CompetitionModel>> GetAllAsync()
    {
        var competitions = await _competitionRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<CompetitionModel>>(competitions);
    }

    public Task<PagedList<CompetitionModel>> GetAllWithFilterAsync(SieveModel sieveModel)
    {
        throw new NotImplementedException();
    }

    public async Task<CompetitionModel> CreateAsync(CreateCompetitionModel createCompetitionModel)
    {
        var competition = _mapper.Map<Competition>(createCompetitionModel);

        var competitionStatus = await _competitionStatusRepository.GetByNameAsync(createCompetitionModel.Status)
                                ?? throw new NotFoundException("Competition status was not found");

        competition.CompetitionStatus = competitionStatus;

        var competitionLevel = await _competitionLevelRepository.GetByNameAsync(createCompetitionModel.Level)
                               ?? throw new NotFoundException("Competition level was not found");

        competition.CompetitionLevel = competitionLevel;

        await _competitionRepository.CreateAsync(competition);
        await _context.SaveChangesAsync();

        return _mapper.Map<CompetitionModel>(competition);
    }

    public async Task UpdateAsync(int id, UpdateCompetitionModel updateCompetitionModel)
    {
        var competition = await _competitionRepository.GetByIdAsync(updateCompetitionModel.Id)
                          ?? throw new NotFoundException("Competition was not found");

        var competitionStatus = await _competitionStatusRepository.GetByNameAsync(updateCompetitionModel.Status)
                                ?? throw new NotFoundException("Competition status was not found");

        competition.CompetitionStatus = competitionStatus;

        var competitionLevel = await _competitionLevelRepository.GetByNameAsync(updateCompetitionModel.Level)
                               ?? throw new NotFoundException("Competition level was not found");

        competition.CompetitionLevel = competitionLevel;

        competition.Name = updateCompetitionModel.Name;
        competition.City = updateCompetitionModel.City;
        competition.WeightingDate = updateCompetitionModel.WeightingDate;
        competition.StartDate = updateCompetitionModel.StartDate;
        competition.EndDate = updateCompetitionModel.EndDate;

        _competitionRepository.Update(competition);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var competition = await _competitionRepository.GetByIdAsync(id)
                          ?? throw new NotFoundException("Competition was not found");

        _competitionRepository.Delete(competition);
        await _context.SaveChangesAsync();
    }
}