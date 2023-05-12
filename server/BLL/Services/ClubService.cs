using AutoMapper;
using BLL.Models.Club;
using BLL.Services.Interfaces;
using Core.Entities;
using Core.Exceptions;
using DAL;
using DAL.Repositories.Interfaces;

namespace BLL.Services;

public class ClubService: IClubService
{
    private readonly AppDbContext _context;
    private readonly IClubRepository _clubRepository;
    private readonly IMapper _mapper;

    public ClubService(
        AppDbContext context, 
        IClubRepository clubRepository, 
        IMapper mapper)
    {
        _context = context;
        _clubRepository = clubRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ClubModel>> GetAllAsync()
    {
        var clubs = await _clubRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<ClubModel>>(clubs);
    }

    public async Task<ClubModel> GetByIdAsync(int id)
    {
        var club = await _clubRepository.GetByIdAsync(id)
                   ?? throw new NotFoundException($"Club with id {id} was not found");

        return _mapper.Map<ClubModel>(club);
    }

    public async Task<ClubModel> CreateAsync(CreateClubModel createClubModel)
    {
        var club = _mapper.Map<Club>(createClubModel);

        await _clubRepository.CreateAsync(club);
        await _context.SaveChangesAsync();

        return _mapper.Map<ClubModel>(club);
    }

    public async Task UpdateAsync(int id, UpdateClubModel updateClubModel)
    {
        var club = await _clubRepository.GetByIdAsync(id)
                   ?? throw new NotFoundException($"Club with id {id} was not found");

        if (!string.IsNullOrWhiteSpace(updateClubModel.Name))
        {
            club.Name = updateClubModel.Name;
        }

        if (!string.IsNullOrWhiteSpace(updateClubModel.Address))
        {
            club.Address = updateClubModel.Address;
        }

        if (!string.IsNullOrWhiteSpace(updateClubModel.City))
        {
            club.City = updateClubModel.City;
        }

        _clubRepository.Update(club);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var club = await _clubRepository.GetByIdAsync(id)
                   ?? throw new NotFoundException($"Club with id {id} was not found");

        _clubRepository.Delete(club);
        await _context.SaveChangesAsync();
    }
}