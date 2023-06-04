using BLL.Models.Dayang;
using BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;

namespace Api.Controllers;

[ApiController]
[Route("api/dayangs")]
public class DayangsController : ControllerBase
{
    private readonly IDayangService _dayangService;

    public DayangsController(IDayangService dayangService)
    {
        _dayangService = dayangService;
    }

    [HttpGet("all")]
    public async Task<IActionResult> Get()
    {
        var dayangs = await _dayangService.GetAllAsync();
        return Ok(dayangs);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllWithFilter([FromQuery] SieveModel sieveModel)
    {
        var dayangs = await _dayangService.GetAllWithFilterAsync(sieveModel);
        return Ok(dayangs);
    }

    [HttpGet("{id}", Name = nameof(GetByDayangId))]
    public async Task<IActionResult> GetByDayangId(int id)
    {
        var dayang = await _dayangService.GetByDayangIdAsync(id);
        return Ok(dayang);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateDayangModel createDayangModel)
    {
        var dayang = await _dayangService.CreateAsync(createDayangModel);
        return CreatedAtRoute(nameof(GetByDayangId), new { id = dayang.DayangId }, dayang);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, UpdateDayangModel updateDayangModel)
    {
        await _dayangService.UpdateAsync(id, updateDayangModel);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _dayangService.DeleteAsync(id);
        return NoContent();
    }
}

