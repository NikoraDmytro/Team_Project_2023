using AutoMapper;
using BLL.Models.InstructorCategory;
using BLL.Services.Interfaces;
using DAL;
using DAL.Repositories.Interfaces;

namespace BLL.Services;

public class InstructorCategoryService: IInstructorCategoryService
{
    private readonly IInstructorCategoryRepository _instructorCategoryRepository;
    private readonly IMapper _mapper;
    private readonly AppDbContext _context;

    public InstructorCategoryService(
        IInstructorCategoryRepository instructorCategoryRepository, 
        IMapper mapper, 
        AppDbContext context)
    {
        _instructorCategoryRepository = instructorCategoryRepository;
        _mapper = mapper;
        _context = context;
    }

    public async Task<IEnumerable<InstructorCategoryModel>> GetAllAsync()
    {
        var categories = await _instructorCategoryRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<InstructorCategoryModel>>(categories);
    }
}