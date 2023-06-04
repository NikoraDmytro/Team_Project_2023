using Core.Entities;
using DAL.Repositories.Interfaces;
using Sieve.Services;

namespace DAL.Repositories;

public class CompetitionLevelRepository: GenericRepository<CompetitionLevel>, ICompetitionLevelRepository
{
    public CompetitionLevelRepository(AppDbContext context, ISieveProcessor sieveProcessor) : base(context, sieveProcessor)
    {
    }
}