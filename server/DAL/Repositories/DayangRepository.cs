using Core.Entities;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Sieve.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories;

public class DayangRepository: GenericRepository<Dayang>, IDayangRepository
{
    public DayangRepository(
        AppDbContext context,
        ISieveProcessor sieveProcessor) : base(context, sieveProcessor)
    {
    }

    public async Task<Dayang?> GetByDayangIdAsync(int id)
    {
        return await _dbSet.FirstOrDefaultAsync(e => e.DayangId == id);
    }
}