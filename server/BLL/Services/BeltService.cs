using AutoMapper;
using BLL.Models.Belt;
using BLL.Services.Interfaces;
using DAL.Repositories.Interfaces;

namespace BLL.Services;

public class BeltService: IBeltService
{
    private readonly IBeltRepository _beltRepository;
    private readonly IMapper _mapper;

    public BeltService(
        IBeltRepository beltRepository, 
        IMapper mapper)
    {
        _beltRepository = beltRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<BeltModel>> GetAllBeltsAsync()
    {
        var belts = await _beltRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<BeltModel>>(belts);
    }
}