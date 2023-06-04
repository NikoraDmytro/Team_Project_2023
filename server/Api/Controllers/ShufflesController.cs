using BLL.Models.Shuffle;
using BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;

namespace Api.Controllers;

public class ShufflesController : ControllerBase
{
    private readonly IShuffleService _shuffleService;

    public ShufflesController(IShuffleService shuffleService)
    {
        _shuffleService = shuffleService;
    }

    [HttpGet("all")]
    public async Task<IActionResult> Get()
    {
        var shuffles = await _shuffleService.GetAllAsync();
        return Ok(shuffles);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllWithFilter([FromQuery] SieveModel sieveModel)
    {
        var shuffles = await _shuffleService.GetAllWithFilterAsync(sieveModel);
        return Ok(shuffles);
    }

    [HttpGet("{id}", Name = nameof(GetByShuffleId))]
    public async Task<IActionResult> GetByShuffleId(int id)
    {
        var shufle = await _shuffleService.GetByShuffleIdAsync(id);
        return Ok(shufle);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateShuffleModel createShuffleModel)
    {
        var shuffle = await _shuffleService.CreateAsync(createShuffleModel);
        return CreatedAtRoute(nameof(GetByShuffleId), new { id = shuffle.ShuffleId }, shuffle);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, UpdateShuffleModel updateShuffleModel)
    {
        await _shuffleService.UpdateAsync(id, updateShuffleModel);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _shuffleService.DeleteAsync(id);
        return NoContent();
    }
}
