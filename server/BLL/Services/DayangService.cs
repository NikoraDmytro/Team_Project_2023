using AutoMapper;
using BLL.Models.Club;
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
using BLL.Services.Interfaces;
using BLL.Models.Dayang;

namespace BLL.Services
{
    public class DayangService: IDayangService
    {
        private readonly AppDbContext _context;
        private readonly IDayangRepository _dayangRepository;
        private readonly IMapper _mapper;

        public DayangService(
            AppDbContext context,
            IDayangRepository dayangRepository,
            IMapper mapper)
        {
            _context = context;
            _dayangRepository = dayangRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DayangModel>> GetAllAsync()
        {
            var dayangs = await _dayangRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<DayangModel>>(dayangs);
        }

        public async Task<PagedList<DayangModel>> GetAllWithFilterAsync(SieveModel sieveModel)
        {
            var pagedList = await _dayangRepository.GetAllWithFilterAsync(sieveModel);
            var dayangModels = _mapper.Map<IEnumerable<DayangModel>>(pagedList.Items);

            var updatedPagedList = PagedList<DayangModel>.Copy(pagedList, dayangModels);

            return updatedPagedList;
        }

        public async Task<DayangModel> GetByDayangIdAsync(int id)
        {
            var dayang = await _dayangRepository.GetByDayangIdAsync(id)
                       ?? throw new NotFoundException($"Dayang with id {id} was not found");

            return _mapper.Map<DayangModel>(dayang);
        }

        public async Task<DayangModel> CreateAsync(CreateDayangModel createDayangModel)
        {
            var dayang = _mapper.Map<Dayang>(createDayangModel);

            await _dayangRepository.CreateAsync(dayang);
            await _context.SaveChangesAsync();

            return _mapper.Map<DayangModel>(dayang);
        }

        public async Task UpdateAsync(int id, UpdateDayangModel updateDayangModel)
        {
            var dayang = await _dayangRepository.GetByDayangIdAsync(id)
                       ?? throw new NotFoundException($"Dayang with id {id} was not found");

            _dayangRepository.Update(dayang);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var dayang = await _dayangRepository.GetByDayangIdAsync(id)
                       ?? throw new NotFoundException($"Dayang with id {id} was not found");
           
            _dayangRepository.Delete(dayang);
            await _context.SaveChangesAsync();
        }
    }
}
