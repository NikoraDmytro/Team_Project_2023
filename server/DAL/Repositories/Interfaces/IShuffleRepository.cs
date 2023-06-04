using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Interfaces;

public interface IShuffleRepository : IGenericRepository<Shuffle>
{
    Task<Shuffle?> GetByShuffleIdAsync(int id);
}