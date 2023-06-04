using BLL.Models.Competition;
using BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/competitions")]
public class CompetitionsController: ControllerBase
{
    private readonly ICompetitionService _competitionService;

    public CompetitionsController(ICompetitionService competitionService)
    {
        _competitionService = competitionService;
    }

    [HttpGet("all")]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _competitionService.GetAllAsync());
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateCompetitionModel createCompetitionModel)
    {
        var competition = await _competitionService.CreateAsync(createCompetitionModel);
        return Ok(competition);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, UpdateCompetitionModel updateCompetitionModel)
    {
        await _competitionService.UpdateAsync(id, updateCompetitionModel);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _competitionService.DeleteAsync(id);
        return NoContent();
    }
}