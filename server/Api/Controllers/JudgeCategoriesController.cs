using BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/judgeCategories")]
public class JudgeCategoriesController: ControllerBase
{
    private readonly IJudgeCategoryService _judgeCategoryService;

    public JudgeCategoriesController(IJudgeCategoryService judgeCategoryService)
    {
        _judgeCategoryService = judgeCategoryService;
    }

    [HttpGet("all")]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _judgeCategoryService.GetAllAsync());
    }
}