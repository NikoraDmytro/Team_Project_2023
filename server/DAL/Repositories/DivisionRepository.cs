using Core.Entities;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Sieve.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class DivisionRepository: GenericRepository<Division>, IDivisionRepository
{
    public DivisionRepository(
        AppDbContext context,
        ISieveProcessor sieveProcessor) : base(context, sieveProcessor)
    {
    }

    public async Task<Division?> GetByDivisionIdAsync(int id)
    {
        return await _dbSet.FirstOrDefaultAsync(e => e.DivisionId == id);
    }
}
}
