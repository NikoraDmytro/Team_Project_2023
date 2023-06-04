using Core.Entities;

namespace DAL.Repositories.Interfaces;

public interface IUserRepository: IGenericRepository<User>
{
    Task<User?> GetByNameAsync(string firstName, string lastName);
}