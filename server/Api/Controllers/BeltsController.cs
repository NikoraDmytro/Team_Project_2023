using BLL.Models.Belt;
using BLL.Models.Club;
using BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;

namespace Api.Controllers;

[ApiController]
[Route("api/belts")]
public class BeltsController : ControllerBase
{
    private readonly IBeltService _beltService;

    public BeltsController(IBeltService beltService)
    {
        _beltService = beltService;
    }

    [HttpGet("all")]
    public async Task<IActionResult> Get()
    {
        var belts = await _beltService.GetAllAsync();
        return Ok(belts);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllWithFilter([FromQuery] SieveModel sieveModel)
    {
        var belts = await _beltService.GetAllWithFilterAsync(sieveModel);
        return Ok(belts);
    }

    [HttpGet("{id}", Name = nameof(GetById))]
    public async Task<IActionResult> GetById(int id)
    {
        var belt = await _beltService.GetByIdAsync(id);
        return Ok(belt);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateBeltModel createBeltModel)
    {
        var belt = await _beltService.CreateAsync(createBeltModel);
        return CreatedAtRoute(nameof(GetById), new { id = belt.Id }, belt);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, UpdateBeltModel updateBeltModel)
    {
        await _beltService.UpdateAsync(id, updateBeltModel);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _beltService.DeleteAsync(id);
        return NoContent();
    }
}
