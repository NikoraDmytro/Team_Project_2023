using BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/belts")]
public class BeltsController: ControllerBase
{
    private readonly IBeltService _beltService;

    public BeltsController(IBeltService beltService)
    {
        _beltService = beltService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var belts = await _beltService.GetAllBeltsAsync();
        return Ok(belts);
    }
}