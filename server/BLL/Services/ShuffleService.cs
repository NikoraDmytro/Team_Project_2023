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
using BLL.Models.Shuffle;

namespace BLL.Services
{
    public class ShuffleService: IShuffleService
    {
        private readonly AppDbContext _context;
        private readonly IShuffleRepository _shuffleRepository;
        private readonly IMapper _mapper;

        public ShuffleService(
            AppDbContext context,
            IShuffleRepository shuffleRepository,
            IMapper mapper)
        {
            _context = context;
            _shuffleRepository = shuffleRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ShuffleModel>> GetAllAsync()
        {
            var shuffles = await _shuffleRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ShuffleModel>>(shuffles);
        }

        public async Task<PagedList<ShuffleModel>> GetAllWithFilterAsync(SieveModel sieveModel)
        {
            var pagedList = await _shuffleRepository.GetAllWithFilterAsync(sieveModel);
            var shuffleModels = _mapper.Map<IEnumerable<ShuffleModel>>(pagedList.Items);

            var updatedPagedList = PagedList<ShuffleModel>.Copy(pagedList, shuffleModels);

            return updatedPagedList;
        }

        public async Task<ShuffleModel> GetByShuffleIdAsync(int id)
        {
            var shuffle = await _shuffleRepository.GetByShuffleIdAsync(id)
                       ?? throw new NotFoundException($"Shuffle with id {id} was not found");

            return _mapper.Map<ShuffleModel>(shuffle);
        }

        public async Task<ShuffleModel> CreateAsync(CreateShuffleModel createShuffleModel)
        {
            var shuffle = _mapper.Map<Shuffle>(createShuffleModel);

            await _shuffleRepository.CreateAsync(shuffle);
            await _context.SaveChangesAsync();

            return _mapper.Map<ShuffleModel>(shuffle);
        }

        public async Task UpdateAsync(int id, UpdateShuffleModel updateShuffleModel)
        {
            var shuffle = await _shuffleRepository.GetByShuffleIdAsync(id)
                       ?? throw new NotFoundException($"Shuffle with id {id} was not found");

            _shuffleRepository.Update(shuffle);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var club = await _shuffleRepository.GetByShuffleIdAsync(id)
                       ?? throw new NotFoundException($"Shuffle with id {id} was not found");

            _shuffleRepository.Delete(club);
            await _context.SaveChangesAsync();
        }
    }
}
