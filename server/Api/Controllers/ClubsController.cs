using BLL.Models.Club;
using BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/clubs")]
public class ClubsController: ControllerBase
{
    private readonly IClubService _clubService;

    public ClubsController(IClubService clubService)
    {
        _clubService = clubService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var clubs = await _clubService.GetAllAsync();
        return Ok(clubs);
    }

    [HttpGet("{id}", Name = nameof(GetById))]
    public async Task<IActionResult> GetById(int id)
    {
        var club = await _clubService.GetByIdAsync(id);
        return Ok(club);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateClubModel createClubModel)
    {
        var club = await _clubService.CreateAsync(createClubModel);
        return CreatedAtRoute(nameof(GetById), new { id = club.Id }, club);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, UpdateClubModel updateClubModel)
    {
        await _clubService.UpdateAsync(id, updateClubModel);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _clubService.DeleteAsync(id);
        return NoContent();
    }
}