using AutoMapper;
using BLL.Models.Coach;
using BLL.Services.Interfaces;
using Core.Entities;
using Core.Exceptions;
using DAL;
using DAL.Repositories.Interfaces;

namespace BLL.Services;

public class CoachService: ICoachService
{
    private readonly ICoachRepository _coachRepository;
    private readonly IClubRepository _clubRepository;
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public CoachService(
        ICoachRepository coachRepository, 
        IClubRepository clubRepository,
        AppDbContext context, 
        IMapper mapper)
    {
        _coachRepository = coachRepository;
        _clubRepository = clubRepository;
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<CoachModel>> GetAllAsync()
    {
        var coaches = await _coachRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<CoachModel>>(coaches);
    }

    public async Task<CoachModel> GetByMembershipCardNumAsync(int cardNum)
    {
        var coach = await _coachRepository.GetByMembershipCardNumAsync(cardNum)
                    ?? throw new NotFoundException($"Coach with membership card num {cardNum} was not found");
        
        return _mapper.Map<CoachModel>(coach);
    }

    public async Task<CoachModel> CreateAsync(CreateCoachModel createCoachModel)
    {
        var coach = _mapper.Map<Coach>(createCoachModel);

        await _coachRepository.CreateAsync(coach);
        await _context.SaveChangesAsync();

        return _mapper.Map<CoachModel>(coach);
    }

    public async Task UpdateAsync(int cardNum, UpdateCoachModel updateCoachModel)
    {
        var coach = await _coachRepository.GetByMembershipCardNumAsync(cardNum)
                    ?? throw new NotFoundException($"Coach with membership card num {cardNum} was not found");

        if (!string.IsNullOrWhiteSpace(updateCoachModel.Phone) &&
            coach.Phone != updateCoachModel.Phone)
        {
            coach.Phone = updateCoachModel.Phone;
        }

        if (!string.IsNullOrWhiteSpace(updateCoachModel.InstructorCategory) &&
            coach.InstructorCategory != updateCoachModel.InstructorCategory)
        {
            coach.InstructorCategory = updateCoachModel.InstructorCategory;
        }

        if (updateCoachModel.ClubId != null &&
            coach.ClubId != updateCoachModel.ClubId)
        {
            _ = await _clubRepository.GetByIdAsync(updateCoachModel.ClubId.Value)
                       ?? throw new NotFoundException($"Club with id {updateCoachModel.ClubId} was not found");
            
            coach.ClubId = updateCoachModel.ClubId.Value;
        }
    }

    public async Task DeleteAsync(int cardNum)
    {
        var coach = await _coachRepository.GetByMembershipCardNumAsync(cardNum)
                    ?? throw new NotFoundException($"Coach with membership card num {cardNum} was not found");

        _coachRepository.Delete(coach);
        await _context.SaveChangesAsync();
    }
}