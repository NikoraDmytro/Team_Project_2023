using AutoMapper;
using BLL.Models.JudgeCategory;
using BLL.Services.Interfaces;
using DAL.Repositories.Interfaces;

namespace BLL.Services;

public class JudgeCategoryService: IJudgeCategoryService
{
    private readonly IJudgeCategoryRepository _judgeCategoryRepository;
    private readonly IMapper _mapper;

    public JudgeCategoryService(IJudgeCategoryRepository judgeCategoryRepository, IMapper mapper)
    {
        _judgeCategoryRepository = judgeCategoryRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<JudgeCategoryModel>> GetAllAsync()
    {
        var judgeCategories = await _judgeCategoryRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<JudgeCategoryModel>>(judgeCategories);
    }
}