using BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/instructorCategories")]
public class InstructorCategoriesController: ControllerBase
{
    private readonly IInstructorCategoryService _instructorCategoryService;

    public InstructorCategoriesController(IInstructorCategoryService instructorCategoryService)
    {
        _instructorCategoryService = instructorCategoryService;
    }

    [HttpGet("all")]
    public async Task<IActionResult> Get()
    {
        var categories = await _instructorCategoryService.GetAllAsync();
        return Ok(categories);
    }
}