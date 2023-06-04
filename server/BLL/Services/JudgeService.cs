using AutoMapper;
using BLL.Models.Judge;
using BLL.Services.Interfaces;
using Core.Entities;
using Core.Exceptions;
using DAL;
using DAL.Repositories.Interfaces;

namespace BLL.Services;

public class JudgeService: IJudgeService
{
    private readonly IJudgeRepository _judgeRepository;
    private readonly ISportsmanRepository _sportsmanRepository;
    private readonly IJudgeCategoryRepository _judgeCategoryRepository;
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public JudgeService(
        IJudgeRepository judgeRepository, 
        ISportsmanRepository sportsmanRepository,
        IJudgeCategoryRepository judgeCategoryRepository,
        AppDbContext context, 
        IMapper mapper)
    {
        _judgeRepository = judgeRepository;
        _sportsmanRepository = sportsmanRepository;
        _judgeCategoryRepository = judgeCategoryRepository;
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<JudgeModel>> GetAllAsync()
    {
        var judges = await _judgeRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<JudgeModel>>(judges);
    }

    public async Task<JudgeModel> GetByMembershipCardNumAsync(int cardNum)
    {
        var judge = await _judgeRepository.GetByMembershipCardNumAsync(cardNum)
                    ?? throw new NotFoundException($"Judge with membership card num {cardNum} was not found");

        return _mapper.Map<JudgeModel>(judge);
    }

    public async Task<JudgeModel> CreateAsync(CreateJudgeModel createJudgeModel)
    {
        var judge = new Judge();
        
        var sportsmanName = createJudgeModel.Sportsman.Split(' ');
        var firstName = sportsmanName[0];
        var lastName = sportsmanName[1];
        
        var sportsman =
            await _sportsmanRepository.GetByNameAsync(firstName, lastName)
            ?? throw new NotFoundException("Sportsman was not found");

        judge.Sportsman = sportsman;

        var judgeCategory = await _judgeCategoryRepository.GetByNameAsync(createJudgeModel.JudgeCategory)
                            ?? throw new NotFoundException("Judge category was not found");

        judge.JudgeCategory = judgeCategory;

        await _judgeRepository.CreateAsync(judge);
        await _context.SaveChangesAsync();

        return _mapper.Map<JudgeModel>(judge);
    }

    public async Task UpdateAsync(int cardNum, UpdateJudgeModel updateJudgeModel)
    {
        var judge = await _judgeRepository.GetByMembershipCardNumAsync(cardNum)
                    ?? throw new NotFoundException($"Judge with membership card num {cardNum} was not found");

        var sportsmanName = updateJudgeModel.Sportsman.Split(' ');
        var firstName = sportsmanName[0];
        var lastName = sportsmanName[1];
        
        var sportsman =
            await _sportsmanRepository.GetByNameAsync(firstName, lastName)
            ?? throw new NotFoundException("Sportsman was not found");

        judge.Sportsman = sportsman;

        var judgeCategory = await _judgeCategoryRepository.GetByNameAsync(updateJudgeModel.JudgeCategory)
                            ?? throw new NotFoundException("Judge category was not found");

        judge.JudgeCategory = judgeCategory;
        
        _judgeRepository.Update(judge);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int cardNum)
    {
        var judge = await _judgeRepository.GetByMembershipCardNumAsync(cardNum)
                    ?? throw new NotFoundException($"Judge with membership card num {cardNum} was not found");

        _judgeRepository.Delete(judge);
        await _context.SaveChangesAsync();
    }
}