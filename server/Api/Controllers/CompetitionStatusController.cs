using BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/competitionStatuses")]
public class CompetitionStatusController: ControllerBase
{
    private readonly ICompetitionStatusService _competitionStatusService;

    public CompetitionStatusController(ICompetitionStatusService competitionStatusService)
    {
        _competitionStatusService = competitionStatusService;
    }

    [HttpGet("all")]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _competitionStatusService.GetAllAsync());
    }
}