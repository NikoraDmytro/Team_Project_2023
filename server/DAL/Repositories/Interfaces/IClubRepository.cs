using Core.Entities;
using Core.Shared;
using Sieve.Models;

namespace DAL.Repositories.Interfaces;

public interface IClubRepository: IGenericRepository<Club>
{
    Task<PagedList<Club>> GetAllWithFilterAsync(SieveModel sieveModel);
    Task<Club?> GetByIdAsync(int id);
}