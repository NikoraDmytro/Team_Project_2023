using BLL.Models.Coach;
using BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;

namespace Api.Controllers;

[ApiController]
[Route("api/coaches")]
public class CoachesController: ControllerBase
{
    private readonly ICoachService _coachService;

    public CoachesController(ICoachService coachService)
    {
        _coachService = coachService;
    }

    [HttpGet("all")]
    public async Task<IActionResult> Get()
    {
        var coaches = await _coachService.GetAllAsync();
        return Ok(coaches);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllWithFilter([FromQuery] SieveModel sieveModel)
    {
        var coaches = await _coachService.GetAllWithFilterAsync(sieveModel);
        return Ok(coaches);
    }

    [HttpGet("{cardNum}", Name = nameof(GetCoachByMembershipCardNum))]
    public async Task<IActionResult> GetCoachByMembershipCardNum(int cardNum)
    {
        var coach = await _coachService.GetByMembershipCardNumAsync(cardNum);
        return Ok(coach);
    }

    [HttpPost]
    public async Task<IActionResult> Post(CreateCoachModel createCoachModel)
    {
        var coach = await _coachService.CreateAsync(createCoachModel);
        return CreatedAtRoute(nameof(GetCoachByMembershipCardNum), new { cardNum = coach.MembershipCardNum }, coach);
    }

    [HttpPut("{cardNum}")]
    public async Task<IActionResult> Put(int cardNum, UpdateCoachModel updateCoachModel)
    {
        await _coachService.UpdateAsync(cardNum, updateCoachModel);
        return NoContent();
    }

    [HttpDelete("{cardNum}")]
    public async Task<IActionResult> Delete(int cardNum)
    {
        await _coachService.DeleteAsync(cardNum);
        return NoContent();
    }
}