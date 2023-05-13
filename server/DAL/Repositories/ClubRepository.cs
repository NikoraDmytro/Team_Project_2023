using Core.Entities;
using Core.Shared;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Sieve.Models;
using Sieve.Services;

namespace DAL.Repositories;

public class ClubRepository: GenericRepository<Club>, IClubRepository
{
    private readonly ISieveProcessor _sieveProcessor;
    
    public ClubRepository(
        AppDbContext context, 
        ISieveProcessor sieveProcessor) : base(context)
    {
        _sieveProcessor = sieveProcessor;
    }

    public async Task<PagedList<Club>> GetAllWithFilterAsync(SieveModel sieveModel)
    {
        var clubs = _sieveProcessor
            .Apply(sieveModel, _dbSet.AsQueryable(), applyPagination: false);

        return await PagedList<Club>.ToPagedListAsync(clubs, sieveModel);
    }

    public async Task<Club?> GetByIdAsync(int id)
    {
        return await _dbSet.FirstOrDefaultAsync(e => e.Id == id);
    }
}