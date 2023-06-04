using AutoMapper;
using BLL.Models.Club;
using BLL.Services.Interfaces;
using Core.Entities;
using Core.Exceptions;
using Core.Shared;
using DAL.Repositories.Interfaces;
using DAL;
using Sieve.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Models.Division;

namespace BLL.Services
{
    public class DivisionService: IDivisionService
    {
        private readonly AppDbContext _context;
        private readonly IDivisionRepository _divisionRepository;
        private readonly IMapper _mapper;

        public DivisionService(
            AppDbContext context,
            IDivisionRepository divisionRepository,
            IMapper mapper)
        {
            _context = context;
            _divisionRepository = divisionRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DivisionModel>> GetAllAsync()
        {
            var divisions = await _divisionRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<DivisionModel>>(divisions);
        }

        public async Task<PagedList<DivisionModel>> GetAllWithFilterAsync(SieveModel sieveModel)
        {
            var pagedList = await _divisionRepository.GetAllWithFilterAsync(sieveModel);
            var divisionModels = _mapper.Map<IEnumerable<DivisionModel>>(pagedList.Items);

            var updatedPagedList = PagedList<DivisionModel>.Copy(pagedList, divisionModels);

            return updatedPagedList;
        }

        public async Task<DivisionModel> GetByDivisionIdAsync(int id)
        {
            var division = await _divisionRepository.GetByDivisionIdAsync(id)
                       ?? throw new NotFoundException($"Division with id {id} was not found");

            return _mapper.Map<DivisionModel>(division);
        }

        public async Task<DivisionModel> CreateAsync(CreateDivisionModel createDivisionModel)
        {
            var division = _mapper.Map<Division>(createDivisionModel);

            await _divisionRepository.CreateAsync(division);
            await _context.SaveChangesAsync();

            return _mapper.Map<DivisionModel>(division);
        }

        public async Task UpdateAsync(int id, UpdateDivisionModel updateDivisionModel)
        {
            var club = await _divisionRepository.GetByDivisionIdAsync(id)
                       ?? throw new NotFoundException($"Club with id {id} was not found");

            _divisionRepository.Update(club);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var club = await _divisionRepository.GetByDivisionIdAsync(id)
                       ?? throw new NotFoundException($"Division with id {id} was not found");

            _divisionRepository.Delete(club);
            await _context.SaveChangesAsync();
        }
    }
}
