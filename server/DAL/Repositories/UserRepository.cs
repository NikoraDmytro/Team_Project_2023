using Core.Entities;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Sieve.Services;

namespace DAL.Repositories;

public class UserRepository: GenericRepository<User>, IUserRepository
{
    
    public UserRepository(
        AppDbContext context,
        ISieveProcessor sieveProcessor): base(context, sieveProcessor)
    {
    }

    public async Task<User?> GetByNameAsync(string firstName, string lastName)
    {
        return await _context.Users
            .FirstOrDefaultAsync(x => x.FirstName == firstName && x.LastName == lastName);
    }
}