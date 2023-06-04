using BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/competitionLevels")]
public class CompetitionLevelsController: ControllerBase
{
    private readonly ICompetitionLevelService _competitionLevelService;

    public CompetitionLevelsController(ICompetitionLevelService competitionLevelService)
    {
        _competitionLevelService = competitionLevelService;
    }

    [HttpGet("all")]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _competitionLevelService.GetAllAsync());
    }
}