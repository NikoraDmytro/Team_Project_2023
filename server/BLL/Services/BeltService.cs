using AutoMapper;
using BLL.Services.Interfaces;
using Core.Entities;
using Core.Exceptions;
using Core.Shared;
using DAL.Repositories.Interfaces;
using DAL;
using Sieve.Models;
using BLL.Models.Belt;

namespace BLL.Services
{
    public class BeltService: IBeltService
    {
        private readonly AppDbContext _context;
        private readonly IBeltRepository _beltRepository;
        private readonly IMapper _mapper;

        public BeltService(
            AppDbContext context,
            IBeltRepository beltRepository,
            IMapper mapper)
        {
            _context = context;
            _beltRepository = beltRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BeltModel>> GetAllAsync()
        {
            var belts = await _beltRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<BeltModel>>(belts);
        }

        public async Task<PagedList<BeltModel>> GetAllWithFilterAsync(SieveModel sieveModel)
        {
            var pagedList = await _beltRepository.GetAllWithFilterAsync(sieveModel);
            var beltModels = _mapper.Map<IEnumerable<BeltModel>>(pagedList.Items);

            var updatedPagedList = PagedList<BeltModel>.Copy(pagedList, beltModels);

            return updatedPagedList;
        }

        public async Task<BeltModel> GetByIdAsync(int id)
        {
            var belt = await _beltRepository.GetByIdAsync(id)
                       ?? throw new NotFoundException($"Belt with id {id} was not found");

            return _mapper.Map<BeltModel>(belt);
        }

        public async Task<BeltModel> CreateAsync(CreateBeltModel createBeltModel)
        {
            var belt = _mapper.Map<Belt>(createBeltModel);

            await _beltRepository.CreateAsync(belt);
            await _context.SaveChangesAsync();

            return _mapper.Map<BeltModel>(belt);
        }

        public async Task UpdateAsync(int id, UpdateBeltModel updateBeltModel)
        {
            var belt = await _beltRepository.GetByIdAsync(id)
                       ?? throw new NotFoundException($"Belt with id {id} was not found");

            _beltRepository.Update(belt);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var belt = await _beltRepository.GetByIdAsync(id)
                       ?? throw new NotFoundException($"Belt with id {id} was not found");

            _beltRepository.Delete(belt);
            await _context.SaveChangesAsync();
        }
    }
}
