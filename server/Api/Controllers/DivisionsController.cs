using BLL.Models.Division;
using BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;

namespace Api.Controllers;

[ApiController]
[Route("api/divisions")]
public class DivisionsController : ControllerBase
{
    private readonly IDivisionService _divisionService;

    public DivisionsController(IDivisionService divisionService)
    {
        _divisionService = divisionService;
    }

    [HttpGet("all")]
    public async Task<IActionResult> Get()
    {
        var divisions = await _divisionService.GetAllAsync();
        return Ok(divisions);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllWithFilter([FromQuery] SieveModel sieveModel)
    {
        var divisions = await _divisionService.GetAllWithFilterAsync(sieveModel);
        return Ok(divisions);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var division = await _divisionService.GetByDivisionIdAsync(id);
        return Ok(division);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateDivisionModel createDivisionModel)
    {
        var division = await _divisionService.CreateAsync(createDivisionModel);
        return Ok(division);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, UpdateDivisionModel updateDivisionModel)
    {
        await _divisionService.UpdateAsync(id, updateDivisionModel);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _divisionService.DeleteAsync(id);
        return NoContent();
    }
}
