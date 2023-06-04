using BLL.Models.Club;
using BLL.Models.Competitor;
using BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;

namespace Api.Controllers;

[ApiController]
[Route("api/competitors")]
public class CompetitorsController : ControllerBase
{
    private readonly ICompetitorService _competitorService;

    public CompetitorsController(ICompetitorService competitorService)
    {
        _competitorService = competitorService;
    }

    [HttpGet("all")]
    public async Task<IActionResult> Get()
    {
        var competitors = await _competitorService.GetAllAsync();
        return Ok(competitors);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllWithFilter([FromQuery] SieveModel sieveModel)
    {
        var competitors = await _competitorService.GetAllWithFilterAsync(sieveModel);
        return Ok(competitors);
    }

    [HttpGet("{applicationNum}", Name = nameof(GetByApplicationNum))]
    public async Task<IActionResult> GetByApplicationNum(int applicationNum)
    {
        var competitor = await _competitorService.GetByApplicationNumAsync(applicationNum);
        return Ok(competitor);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateCompetitorModel createCompetitorModel)
    {
        var competitor = await _competitorService.CreateAsync(createCompetitorModel);
        return CreatedAtRoute(nameof(GetByApplicationNum), new { applicationNum = competitor.ApplicationNum }, competitor);
    }

    [HttpPut("{applicationNum}")]
    public async Task<IActionResult> Put(int applicationNum, UpdateCompetitorModel updateCompetitorModel)
    {
        await _competitorService.UpdateAsync(applicationNum, updateCompetitorModel);
        return NoContent();
    }

    [HttpDelete("{applicationNum}")]
    public async Task<IActionResult> Delete(int applicationNum)
    {
        await _competitorService.DeleteAsync(applicationNum);
        return NoContent();
    }
}
