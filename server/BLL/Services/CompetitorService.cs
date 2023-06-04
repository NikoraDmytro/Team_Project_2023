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
using BLL.Models.Competitor;
using BLL.Services.Interfaces;

namespace BLL.Services
{
    public class CompetitorService: ICompetitorService
    {
        private readonly AppDbContext _context;
        private readonly ICompetitorRepository _competitorRepository;
        private readonly IMapper _mapper;

        public CompetitorService(
            AppDbContext context,
            ICompetitorRepository competitorRepository,
            IMapper mapper)
        {
            _context = context;
            _competitorRepository = competitorRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CompetitorModel>> GetAllAsync()
        {
            var competitors = await _competitorRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<CompetitorModel>>(competitors);
        }

        public async Task<PagedList<CompetitorModel>> GetAllWithFilterAsync(SieveModel sieveModel)
        {
            var pagedList = await _competitorRepository.GetAllWithFilterAsync(sieveModel);
            var competitorModels = _mapper.Map<IEnumerable<CompetitorModel>>(pagedList.Items);

            var updatedPagedList = PagedList<CompetitorModel>.Copy(pagedList, competitorModels);

            return updatedPagedList;
        }

        public async Task<CompetitorModel> GetByApplicationNumAsync(int applicationNum)
        {
            var competitor = await _competitorRepository.GetByApplicationNumAsync(applicationNum)
                       ?? throw new NotFoundException($"Competitor with applicationNumAsync {applicationNum} was not found");

            return _mapper.Map<CompetitorModel>(competitor);
        }

        public async Task<CompetitorModel> CreateAsync(CreateCompetitorModel createCompetitorModel)
        {
            var competitor = _mapper.Map<Competitor>(createCompetitorModel);

            await _competitorRepository.CreateAsync(competitor);
            await _context.SaveChangesAsync();

            return _mapper.Map<CompetitorModel>(competitor);
        }

        public async Task UpdateAsync(int applicationNum, UpdateCompetitorModel updateCompetitorModel)
        {
            var club = await _competitorRepository.GetByApplicationNumAsync(applicationNum)
                       ?? throw new NotFoundException($"Competitor with applicationNum {applicationNum} was not found");

            _competitorRepository.Update(club);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int applicationNum)
        {
            var club = await _competitorRepository.GetByApplicationNumAsync(applicationNum)
                       ?? throw new NotFoundException($"Competitor with applicationNum {applicationNum} was not found");

            _competitorRepository.Delete(club);
            await _context.SaveChangesAsync();
        }
    }
}
