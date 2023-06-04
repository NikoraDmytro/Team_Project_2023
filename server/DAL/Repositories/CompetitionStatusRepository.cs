using Core.Entities;
using DAL.Repositories.Interfaces;
using Sieve.Services;

namespace DAL.Repositories;

public class CompetitionStatusRepository: GenericRepository<CompetitionStatus>, ICompetitionStatusRepository
{
    public CompetitionStatusRepository(AppDbContext context, ISieveProcessor sieveProcessor) : base(context, sieveProcessor)
    {
    }
}