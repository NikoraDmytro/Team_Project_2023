using BLL.Models.Sportsman;
using BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;

namespace Api.Controllers;

[ApiController]
[Route("api/sportsmen")]
public class SportsmanController: ControllerBase
{
    private readonly ISportsmanService _sportsmanService;

    public SportsmanController(ISportsmanService sportsmanService)
    {
        _sportsmanService = sportsmanService;
    }
    
    [HttpGet("all")]
    public async Task<IActionResult> Get()
    {
        var clubs = await _sportsmanService.GetAllAsync();
        return Ok(clubs);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllWithFilter([FromQuery] SieveModel sieveModel)
    {
        var sportsmen = await _sportsmanService.GetAllWithFilterAsync(sieveModel);
        return Ok(sportsmen);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var sportsman = await _sportsmanService.GetByIdAsync(id);
        return Ok(sportsman);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateSportsmanModel createSportsmanModel)
    {
        await _sportsmanService.CreateAsync(createSportsmanModel);
        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, UpdateSportsmanModel updateSportsmanModel)
    {
        await _sportsmanService.UpdateAsync(id, updateSportsmanModel);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _sportsmanService.DeleteAsync(id);
        return NoContent();
    }
}