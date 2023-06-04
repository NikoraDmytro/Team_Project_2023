using AutoMapper;
using BLL.Models.Sportsman;
using BLL.Services.Interfaces;
using Core.Shared;
using DAL.Repositories.Interfaces;
using DAL;
using Sieve.Models;
using Core.Entities;
using Core.Exceptions;
using BLL.Models.Coach;
using DAL.Repositories;

namespace BLL.Services
{
    public class SportsmanService : ISportsmanService
    {
        private readonly ISportsmanRepository _sportsmanRepository;
        private readonly IUserRepository _userRepository;
        private readonly ICoachRepository _coachRepository;
        private readonly IBeltRepository _beltRepository;
        private readonly IClubRepository _clubRepository;
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;

        public SportsmanService(
            ISportsmanRepository sportsmanRepository,
            IUserRepository userRepository,
            ICoachRepository coachRepository,
            IBeltRepository beltRepository,
            IClubRepository clubRepository,
            IMapper mapper,
            AppDbContext context)
        {
            _sportsmanRepository = sportsmanRepository;
            _userRepository = userRepository;
            _coachRepository = coachRepository;
            _beltRepository = beltRepository;
            _clubRepository = clubRepository;
            _mapper = mapper;
            _context = context;
        }
        
        public async Task<SportsmanModel> CreateAsync(CreateSportsmanModel createSportsmanModel)
        {
            var sportsman = new Sportsman();

            sportsman.Sex = createSportsmanModel.Sex == "Ч" ? Sex.M : Sex.F;

            var userName = createSportsmanModel.User.Split(' ');
            var firstName = userName[0];
            var lastName = userName[1];

            var user = await _userRepository.GetByNameAsync(firstName, lastName)
                       ?? throw new NotFoundException("User was not found");

            sportsman.User = user;

            var belt = await _beltRepository.GetByNameAsync(createSportsmanModel.Belt)
                       ?? throw new NotFoundException("Belt was not found");

            sportsman.Belt = belt;
            
            var coachName = createSportsmanModel.Coach.Split(' ');
            var coachFirstName = coachName[0];
            var coachLastName = coachName[1];

            var coach = await _coachRepository.GetByNameAsync(coachFirstName, coachLastName)
                        ?? throw new NotFoundException("Coach was not found");

            sportsman.Coach = coach;
            
            await _sportsmanRepository.CreateAsync(sportsman);
            await _context.SaveChangesAsync();

            return _mapper.Map<SportsmanModel>(sportsman);
        }

        public async Task DeleteAsync(int cardNum)
        {
            var sportsman = await _sportsmanRepository.GetByMembershipCardNumAsync(cardNum)
                    ?? throw new NotFoundException($"Sportsman with membership card num {cardNum} was not found");

            _sportsmanRepository.Delete(sportsman);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<SportsmanModel>> GetAllAsync()
        {
            var sportsmen = await _sportsmanRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<SportsmanModel>>(sportsmen);
        }

        public async Task<PagedList<SportsmanModel>> GetAllWithFilterAsync(SieveModel sieveModel)
        {
            var pagedList = await _sportsmanRepository.GetAllWithFilterAsync(sieveModel);
            var sportsmanModels = _mapper.Map<IEnumerable<SportsmanModel>>(pagedList.Items);

            var updatedPagedList = PagedList<SportsmanModel>.Copy(pagedList, sportsmanModels);

            return updatedPagedList;
        }

        public async Task<SportsmanModel> GetByMembershipCardNumAsync(int cardNum)
        {
            var sportsman = await _sportsmanRepository.GetByMembershipCardNumAsync(cardNum)
                    ?? throw new NotFoundException($"Sportsman with membership card num {cardNum} was not found");

            return _mapper.Map<SportsmanModel>(sportsman);
        }

        public async Task UpdateAsync(int cardNum, UpdateSportsmanModel updateSportsmanModel)
        {
            var sportsman = await _sportsmanRepository.GetByMembershipCardNumAsync(cardNum)
                    ?? throw new NotFoundException($"Coach with membership card num {cardNum} was not found");
            
            sportsman.Sex = updateSportsmanModel.Sex == "Ч" ? Sex.M : Sex.F;

            var userName = updateSportsmanModel.User.Split(' ');
            var firstName = userName[0];
            var lastName = userName[1];

            var user = await _userRepository.GetByNameAsync(firstName, lastName)
                       ?? throw new NotFoundException("User was not found");

            sportsman.User = user;

            var belt = await _beltRepository.GetByNameAsync(updateSportsmanModel.Belt)
                       ?? throw new NotFoundException("Belt was not found");

            sportsman.Belt = belt;
            
            var coachName = updateSportsmanModel.Coach.Split(' ');
            var coachFirstName = coachName[0];
            var coachLastName = coachName[1];

            var coach = await _coachRepository.GetByNameAsync(coachFirstName, coachLastName)
                        ?? throw new NotFoundException("Coach was not found");

            sportsman.Coach = coach;

            _sportsmanRepository.Update(sportsman);
            await _context.SaveChangesAsync();
        }
    }
}
