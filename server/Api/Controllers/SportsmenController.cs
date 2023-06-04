using BLL.Models.Sportsman;
using BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;

namespace Api.Controllers;

[ApiController]
[Route("api/sportsmen")]
public class SportsmenController : ControllerBase
{
    private readonly ISportsmanService _sportsmanService;

    public SportsmenController(ISportsmanService sportsmanService)
    {
        _sportsmanService = sportsmanService;
    }

    [HttpGet("all")]
    public async Task<IActionResult> Get()
    {
        var sportsmen = await _sportsmanService.GetAllAsync();
        return Ok(sportsmen);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllWithFilter([FromQuery] SieveModel sieveModel)
    {
        var sportsmen = await _sportsmanService.GetAllWithFilterAsync(sieveModel);
        return Ok(sportsmen);
    }

    [HttpGet("{cardNum}", Name = nameof(GetSportsmanByMembershipCardNum))]
    public async Task<IActionResult> GetSportsmanByMembershipCardNum(int cardNum)
    {
        var sportsman = await _sportsmanService.GetByMembershipCardNumAsync(cardNum);
        return Ok(sportsman);
    }

    [HttpPost]
    public async Task<IActionResult> Post(CreateSportsmanModel createSportsmanModel)
    {
        var sportsman = await _sportsmanService.CreateAsync(createSportsmanModel);
        return CreatedAtRoute(nameof(GetSportsmanByMembershipCardNum), new { cardNum = sportsman.MembershipCardNum }, sportsman);
    }

    [HttpPut("{cardNum}")]
    public async Task<IActionResult> Put(int cardNum, UpdateSportsmanModel updateSportsmanModel)
    {
        await _sportsmanService.UpdateAsync(cardNum, updateSportsmanModel);
        return NoContent();
    }

    [HttpDelete("{cardNum}")]
    public async Task<IActionResult> Delete(int cardNum)
    {
        await _sportsmanService.DeleteAsync(cardNum);
        return NoContent();
    }
}
